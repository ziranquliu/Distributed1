using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedBLL.User;
using DistributedModel.User;
using System.Text;
using DistributedUtil.Helper;
using DistributedDict;
using DistributedModel.Enum;

namespace DistributedWeb
{
    /// <summary>
    /// user 的摘要说明
    /// </summary>
    public class user : IHttpHandler
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
        static user()
        {
            dict.Add("list", context => {
                string jsonback = context.Request.Params["jsoncallback"];
                try
                { 
                    string pageIndex = context.Request["pageIndex"];
                    string pageSize = context.Request["pageSize"];
                    int totalcounts=0;
                    List<LoginUserInfo> ulist = loginbll.FindListPage("", int.Parse(pageIndex), int.Parse(pageSize), out totalcounts);
                    if (ulist==null)
                    {
                        context.Response.Write(jsonback + "({\"html\":\"暂无数据！\",\"status\":\"0\",\"total\":\"0\"})");
                        return;
                    }
                  
                    context.Response.Write(jsonback + "({\"html\":" + JsonHelper.json(ulist) + ",\"status\":\"1\",\"total\":\""+totalcounts+"\"})");
                }
                catch 
                {

                    context.Response.Write(jsonback + "({\"html\":\"发生了异常！\",\"status\":\"0\",\"total\":\"0\"})");
                }
            });
            dict.Add("del", context => {
                string jsonback = context.Request.Params["jsoncallback"];
                string id = context.Request["id"];

                if (userbll.DeleteById(id) > 0 && loginbll.DeleteById(id) > 0)
                {
                    context.Response.Write(jsonback+"({\"html\":\"删除成功！\",\"status\":\"1\"})");
                }
                else
                {
                    context.Response.Write(jsonback + "({\"html\":\"发生了异常！\",\"status\":\"0\"})");
                }
            });
            dict.Add("search", context => {
                string jsonback = context.Request.Params["jsoncallback"];
                try
                {
                    string pageIndex = context.Request["pageIndex"];
                    string pageSize = context.Request["pageSize"];
                    string key =RequestHelper.GetStringValue(context.Request["key"]);
                    string type = context.Request["type"];
                    string strWhere = "1=1 ";
                    
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        switch (type)
                        {
                            case "1":
                                strWhere += "and UserName like '%" + key + "%' ";
                                break;
                            case "2":
                                strWhere += "and ID=" + key + " ";
                                break;
                        }
                    }
                    
                    int totalcounts = 0;
                    List<LoginUserInfo> ulist = loginbll.FindListPage(strWhere, int.Parse(pageIndex), int.Parse(pageSize), out totalcounts);
                    if (ulist == null)
                    {
                        context.Response.Write(jsonback + "({\"html\":\"搜索无果！\",\"status\":\"0\",\"total\":\"0\"})");
                        return;
                    }
                    
                    context.Response.Write(jsonback + "({\"html\":" + JsonHelper.json(ulist) + ",\"status\":\"1\",\"total\":\"" + totalcounts + "\"})");
                }
                catch
                {

                    context.Response.Write(jsonback + "({\"html\":\"发生了异常！\",\"status\":\"0\",\"total\":\"0\"})");
                }
            });
            dict.Add("add", context => {
                string jsonback = context.Request.Params["jsoncallback"];
                string name = context.Request["UserName"];
                string phone = context.Request["Phone"];
                string sex = context.Request["Gender"];
                string zodiac = context.Request["Zodiac"];
                string constellation = context.Request["Constellation"];
                string degree = context.Request["Degree"];
                string nation = context.Request["Nation"];
                string provice = context.Request["Prov"];
                string city = context.Request["City"];
                string loginUser = context.Request["LoginUser"];
                string userStatus = context.Request["UserStatus"];
                string pwd = context.Request["Pwd"];
                string loginType = context.Request["LoginType"];
                string loginIP = context.Request.UserHostAddress;
                UserInfo user = new UserInfo
                {
                    ID=Guid.NewGuid().ToString("N"),
                    Name = name,
                    Phone = phone,
                    Sex = InputHelper.GetInputInt(sex),
                    ZodiacId = InputHelper.GetInputInt(zodiac),
                    ConstellationId = InputHelper.GetInputInt(constellation),
                    DegreeId = InputHelper.GetInputInt(degree),
                    NationId = InputHelper.GetInputInt(nation),
                    ProvinceId = InputHelper.GetInputInt(provice),
                    CityId = InputHelper.GetInputInt(city)
                };
                UserBLL userbll = new UserBLL();
                int ret=userbll.AddUserInfo(user);
                if ( ret> 0)
                {
                    LoginUserInfo loginuser = new LoginUserInfo
                    {
                        ID = user.ID,
                        UserName = loginUser,
                        UserPwd = pwd,
                        LoginIp = loginIP,
                        UserStatus = (UserStatus)int.Parse(userStatus),
                        LoginType = (LoginType)int.Parse(loginType)
                    };
                    loginbll.AddLoginUserInfo(loginuser);
                    context.Response.Write(jsonback + "({\"html\":\"添加成功！\",\"status\":\"1\"})");
                }
                else
                {
                    context.Response.Write(jsonback + "({\"html\":\"添加失败！\",\"status\":\"0\"})");
                }
            });
            dict.Add("up", context =>
            {
                string jsonback = context.Request.Params["jsoncallback"];
                string userId = context.Request["id"];
                string name = context.Request["UserName"];
                string phone = context.Request["Phone"];
                string sex = context.Request["Gender"];
                string zodiac = context.Request["Zodiac"];
                string constellation = context.Request["Constellation"];
                string degree = context.Request["Degree"];
                string nation = context.Request["Nation"];
                string provice = context.Request["Prov"];
                string city = context.Request["City"];
                string loginUser = context.Request["LoginUser"];
                string userStatus = context.Request["UserStatus"];
                string pwd = context.Request["Pwd"];
                string loginType = context.Request["LoginType"];
                UserInfo user = new UserInfo
                {
                    ID=userId,
                    Name = name,
                    Phone = phone,
                    Sex = InputHelper.GetInputInt(sex),
                    ZodiacId = InputHelper.GetInputInt(zodiac),
                    ConstellationId = InputHelper.GetInputInt(constellation),
                    DegreeId = InputHelper.GetInputInt(degree),
                    NationId = InputHelper.GetInputInt(nation),
                    ProvinceId = InputHelper.GetInputInt(provice),
                    CityId = InputHelper.GetInputInt(city)
                };
                LoginUserInfo loginuser = new LoginUserInfo
                {
                    ID = userId,
                    UserName = loginUser,
                    UserPwd = pwd,
                    UserStatus = (UserStatus)int.Parse(userStatus),
                    LoginType = (LoginType)int.Parse(loginType)
                };
                loginbll.UpdateLoginUserInfo(loginuser);
                userbll.UpdateUserInfo(user);
                
               context.Response.Write(jsonback + "({\"html\":\"修改成功！\",\"status\":\"1\"})");
            });
            dict.Add("load", context => {
                string jsonback = context.Request["jsoncallback"];
                string userId = context.Request["id"];
                LoginUserInfo loginuser = loginbll.FindById(userId);
                UserInfo user = userbll.FindById(userId);
                if (loginuser==null||user == null)
                {
                    context.Response.Write(jsonback + "({\"html\":\"参数错误！\",\"status\":\"0\"})");
                    return;
                }
                loginuser.AddExData("UserInfo", user);
                context.Response.Write(jsonback + "({\"html\":" + JsonHelper.json(loginuser) + ",\"status\":\"1\"})");
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
                    strJson.AppendFormat("\"Name\":\"{0}\",",item.Name);
                    strJson.Append("}");
                }
                context.Response.Write(jsonback + "({\"html\":[" + strJson + "],\"status\":\"1\"})");
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