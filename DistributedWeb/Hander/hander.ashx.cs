using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedBLL.User;
using DistributedDict;
using System.Text;
using DistributedBLL;
using DistributedBLL.Mongodb.User;

namespace DistributedWeb.Hander
{
    /// <summary>
    /// hander 的摘要说明
    /// </summary>
    public class hander : IHttpHandler
    {
        delegate void myFunc(HttpContext context);
        static Dictionary<string, myFunc> dict = new Dictionary<string, myFunc>();
        static UserBLL userbll = new UserBLL();
        static LoginUserBLL loginbll = new LoginUserBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string act = context.Request["act"];
            if (!string.IsNullOrWhiteSpace(act))
            {
                if (dict.ContainsKey(act))
                {
                    dict[act](context);
                }
            }
        }
        static hander()
        {
            dict.Add("del", context =>
            {
                string jsonback = context.Request.Params["jsoncallback"];
                string id = context.Request["id"];
                if (userbll.DeleteById(id) > 0 && loginbll.DeleteById(id) > 0)
                {
                    context.Response.Write(jsonback + "({\"html\":\"删除成功！\",\"status\":\"1\"})");
                }
                else
                {
                    context.Response.Write(jsonback + "({\"html\":\"发生了异常！\",\"status\":\"0\"})");
                }
            });
            dict.Add("mgdel", context =>
            {
                string jsonback = context.Request.Params["jsoncallback"];
                string id = context.Request["id"];
                UserBLL_MG userbll_mg = new UserBLL_MG();
                LoginUserBLL_MG loginbll_mg = new LoginUserBLL_MG();
                if (userbll_mg.DeleteById(id).Ok && loginbll_mg.DeleteByID(id).Ok)
                {
                    context.Response.Write(jsonback + "({\"html\":\"删除成功！\",\"status\":\"1\"})");
                }
                else
                {
                    context.Response.Write(jsonback + "({\"html\":\"发生了异常！\",\"status\":\"0\"})");
                }
            });
            dict.Add("address", context =>
            {
                string jsonback = context.Request["jsoncallback"];
                string proid = context.Request["proid"];
                int pId = 0;
                if (!int.TryParse(proid, out pId))
                {
                    context.Response.Write(jsonback + "({\"html\":\"参数错误！\",\"status\":\"0\"})");
                    return;
                }
                List<Item> CityList = Area.Dict[pId].Children.Values.ToList();
                StringBuilder strJson = new StringBuilder();
                foreach (Item item in CityList)
                {
                    if (!string.IsNullOrWhiteSpace(strJson.ToString()))
                    {
                        strJson.Append(",");
                    }
                    strJson.Append("{");
                    strJson.AppendFormat("\"ID\":\"{0}\",", item.ID);
                    strJson.AppendFormat("\"Name\":\"{0}\",", item.Name);
                    strJson.Append("}");
                }
                context.Response.Write(jsonback + "({\"html\":[" + strJson + "],\"status\":\"1\"})");
            });
            dict.Add("logout", context => {
                LoginUser.Logout();
                context.Response.Redirect("/login.aspx");
                context.Response.ContentType = "text/plain";
                context.Response.Write("1;");
            });
            dict.Add("getUserName", context => {
                string userName = string.Empty;
                string userid = LoginUser.GetLoginUserID();
                if (!string.IsNullOrWhiteSpace(userid))
                {
                    userName = loginbll.GetLoginName(userid);
                }
                context.Response.Write(userName);
            });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}