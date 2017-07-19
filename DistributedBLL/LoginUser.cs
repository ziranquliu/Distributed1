using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DistributedUtil.Helper;
using DistributedBLL.User;

namespace DistributedBLL
{
   public class LoginUser
    {
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUserID()
        {
            string LoginUserID =string.Empty;
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies[BLLConfig.UserCookieName];
            if (loginCookie != null)
            {
                var cookieValue = loginCookie.Values.Get("x");
                var cookieExpires = loginCookie.Values.Get("y");
                LoginUserID = CheckCredential(cookieValue, cookieExpires);
            }
            return LoginUserID;
        }
        /// <summary>
        /// 判断是否登陆(带跳转)
        /// </summary>
        /// <param name="redirect"></param>
        /// <returns></returns>
        public static bool IsLogin(bool redirect = true)
        {
            if (string.IsNullOrWhiteSpace(GetLoginUserID()))
            {
                if (redirect)
                {
                    var url = "~/Login.aspx";
                    if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Url.AbsoluteUri))
                    {
                        url += "?redirect_url=" + HttpContext.Current.Request.Url.AbsoluteUri;
                    }
                    HttpContext.Current.Response.Redirect(url);
                    HttpContext.Current.Response.End();
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取当前用户名
        /// </summary>
        /// <returns></returns>
        public static string GetMyName()
        {
            string LoginUserID = GetLoginUserID();
            string cacheKey = "UserInfo-" + LoginUserID;
            //首先判断集合和缓存中是否存在该用户名 存在则直接返回
            if (HttpContext.Current.Items[cacheKey] != null)
                return HttpContext.Current.Items[cacheKey].ToString();
            if (HttpRuntime.Cache[cacheKey] != null)
                return HttpRuntime.Cache[cacheKey].ToString();
            //不存在 从数据库中通过userId读取用户名称
            LoginUserBLL loginuserbll = new LoginUserBLL();
            string myName =loginuserbll.GetLoginName(LoginUserID);
            if (string.IsNullOrWhiteSpace(myName))
            {
                //将用户名称存入集合、缓存中
                HttpContext.Current.Items.Add(cacheKey, myName);
                HttpRuntime.Cache.Insert(cacheKey, myName, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero);
                return myName;
            }
            return string.Empty;
        }
       
       private static void Login(string x, string y, string domain = ".sufeinet.com")
        {
            if (!string.IsNullOrWhiteSpace(CheckCredential(x, y)))
            {
                var expires = DateTime.Now.AddMinutes(BLLConfig.UserCookieExpires);
                HttpCookie loginCookie = new HttpCookie(BLLConfig.UserCookieName);
                loginCookie.Values.Add("x", x);
                loginCookie.Values.Add("y", y);
                loginCookie.Expires = expires;
                loginCookie.Path = "/";
               // loginCookie.Domain = domain;
                HttpContext.Current.Response.Cookies.Add(loginCookie);
            }
        }

        public static void Login(object userId, string domain = ".sufeinet.com")
        {
            var expires = DateTime.Now.AddHours(4);//设置过期时间
            var cookieValue = EncryptHelper.Encrypt(userId.ToString(),BLLConfig.UserCookieKey);//加密当前cookie名称
            var cookieExpires = EncryptHelper.Encrypt(expires.ToString("yyyy-MM-dd HH:mm:ss"), BLLConfig.UserCookieKey);//将过期时间加密
            Login(cookieValue, cookieExpires, domain);
        }

       /// <summary>
       /// 获取登陆用户id 通过x、y
       /// </summary>
       /// <param name="x"></param>
       /// <param name="y"></param>
       /// <returns></returns>
        public static string CheckCredential(string x, string y)
        {
            var userid =string.Empty;
            if (!string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
            {
                DateTime expires;
                //首先判断该过期时间是否超时
                if (DateTime.TryParse(EncryptHelper.Decrypt(y, BLLConfig.UserCookieKey), out expires) && expires > DateTime.Now)
                {
                    //解密x得到登陆用户id
                    userid = EncryptHelper.Decrypt(x, BLLConfig.UserCookieKey);
                }
            }
            return userid;
        }
       /// <summary>
        /// 移除cacheKey并退出登陆
       /// </summary>
       /// <param name="domain"></param>
        public static void Logout(string domain = ".sufeinet.com")
        {
            var loginCookie = HttpContext.Current.Request.Cookies[BLLConfig.UserCookieName];
            if (loginCookie != null)
            {
                string LoginUserID = GetLoginUserID();
                string cacheKey = "UserInfo-" + LoginUserID;
                // 从当前items集合中移除cacheKey
                if (HttpContext.Current.Items[cacheKey] != null)
                    HttpContext.Current.Items.Remove(cacheKey);
                // 从当前应用缓存中移除cacheKey
                if (HttpRuntime.Cache[cacheKey] != null)
                    HttpRuntime.Cache.Remove(cacheKey);
                string rolecacheKey = "RoleInfo-" + LoginUserID;
                // 从当前items集合中移除rolecacheKey
                if (HttpContext.Current.Items[rolecacheKey] != null)
                    HttpContext.Current.Items.Remove(rolecacheKey);
                // 从当前应用缓存中移除rolecacheKey
                if (HttpRuntime.Cache[rolecacheKey] != null)
                    HttpRuntime.Cache.Remove(rolecacheKey);
                 
                //清除cookie
                loginCookie.Expires = DateTime.Now.AddDays(-30);
                loginCookie.Path = "/";
                loginCookie.Value = "";
                //loginCookie.Domain = domain;
                HttpContext.Current.Response.AppendCookie(loginCookie);


            }
        }

    }
}
