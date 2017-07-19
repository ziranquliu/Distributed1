using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using DistributedUtil.Helper;

namespace DistributedWeb
{
    public class Global : System.Web.HttpApplication
    {
        bool ischeck = true;
        #region 白名单
        public static List<string> Whitelist = new List<string>();
        #endregion

        #region 黑名单
        public static List<string> BlackList = new List<string>();
        #endregion
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

            //添加白名单 白名单不做处理  这里可以添加多个白名单
            Whitelist.Add("www.sufeinet.com".ToLower());
            //添加黑名单  黑名单直接拉黑 这里可以添加多个黑名单
            BlackList.Add("xiaomi.com".ToLower());
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            //处理非法字符串
            try
            {
                //首先判断该url是否在白名单中
                string url = (Request.Url.DnsSafeHost + Request.Url.AbsolutePath).ToLower();
                foreach (string item in Whitelist)
                {
                    if (url.Contains(item))
                    {
                        //白名单中的字符串不做检查
                        ischeck = false;
                        break;
                    }
                }
                if (ischeck)
                {
                    if (Request.QueryString != null && (!string.IsNullOrWhiteSpace(Request.QueryString.ToString())))
                    {
                        //检测字符串
                        CheckHtml(Request.QueryString.ToString());
                    }
                    if (Request.Form != null && (!string.IsNullOrWhiteSpace(Request.Form.ToString())))
                    {
                        //检测字符串
                        CheckHtml(Request.Form.ToString());
                    }
                }
            }
            catch { }
        }

        #region 非法字符处理方法
        /// <summary>
        /// 检查是否存在Html标签
        /// </summary>
        /// <param name="str">html字符串</param>
        private void CheckHtml(string str)
        {
            str = str.ToLower();
            //首先判断黑名单 如在黑名单中直接跳到错误页
            foreach (var black in BlackList)
            {
                if (str.Contains(black))
                {
                    Redirect_Error();
                    break;
                }
            }
            //如不在黑名单中则判断是否包含非法字符串
            if (FilterHelper.CheckHtml(str))
            {
                Redirect_Error();
            }
        }
        private void Redirect_Error()
        {
            Response.Redirect("/Error/BanError.html");
        } 
        #endregion
    }
}
