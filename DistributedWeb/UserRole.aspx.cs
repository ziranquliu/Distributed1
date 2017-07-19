using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedModel.Func;
using DistributedBLL.Func;
using DistributedBLL;
using DistributedBLL.User;

namespace DistributedWeb
{
    public partial class UserRole : System.Web.UI.Page
    {
        protected List<int> roleids = new List<int>();
        protected List<RoleInfo> rlist=new List<RoleInfo>();
        UserRoleBLL urbll = new UserRoleBLL();
        RoleBLL rbll = new RoleBLL();
        LoginUserBLL loginbll = new LoginUserBLL();
        protected string userName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            //验证权限
            if (!AuthHepler.IsAuth(9))
            { 
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                 return;
                 
            }
            if (!IsPostBack)
            {
                
                rlist = rbll.FindList();
            }
            GetData();
           
        }
        private void GetData()
        {
            var userId = Request["userId"];
            if (!string.IsNullOrWhiteSpace(userId))
            {
                userName = loginbll.FindById(userId).UserName;
                List<UserRoleInfo> urlist = urbll.FindListByUserId(userId);
                roleids = urlist.Select(ur => ur.RoleID).ToList();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //验证权限
            if (!AuthHepler.IsAuth(9))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;

            }
            var userId = Request["userId"];
            if (!string.IsNullOrWhiteSpace(userId))
            {
                var ck = Request["ck"];
                if (!string.IsNullOrWhiteSpace(ck))
                {
                    var ids = ck.Split(',');
                    foreach (var id in ids)
                    {
                        if (!string.IsNullOrWhiteSpace(id))
                        {
                            UserRoleInfo urinfo = new UserRoleInfo
                            {
                                UserID = userId,
                                RoleID = int.Parse(id)
                            };
                            urbll.AddUserRole(urinfo);
                        }
                    }
                }

                if (roleids.Any())
                {
                    //checked已有的角色ids
                    var cked = Request["cked"];
                    //要删除的角色ids
                    string delids = string.Empty;
                    if (string.IsNullOrWhiteSpace(cked))
                    {
                        delids = string.Join(",", roleids);
                    }
                    else
                    {
                        var ckedids = cked.Split(',');
                        //遍历已有角色列表
                        foreach (var roleid in roleids)
                        {
                            //checked已有的角色ids如果不包含了该id，则拼接到删除字符串中
                            if (!ckedids.Contains(roleid.ToString()))
                            {
                                delids += roleid + ",";
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(delids))
                    {
                        if (delids.Contains(","))
                        {
                            //删除前处理掉末尾的,
                            delids = delids.Substring(0, delids.Length - 1);
                        }
                        //删除处理
                        urbll.DeleteByIds(delids,userId);
                    }
                }

            }
            Response.Redirect("/list.aspx");
        }

        
    }
}