using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedBLL.User;
using DistributedBLL;

namespace DistributedWeb
{
    public partial class Login : System.Web.UI.Page
    {
        LoginUserBLL loginuserbll = new LoginUserBLL();
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Value.Trim();
            string pwd = txtPwd.Value;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd))
            {
                return;
            }
            name = HttpUtility.HtmlEncode(name);
            pwd = HttpUtility.HtmlEncode(pwd);
            string userid = loginuserbll.UserLogin(name, pwd);
            if (!string.IsNullOrWhiteSpace(userid))
            {
                LoginUser.Login(userid);
                Response.Redirect("index.aspx");
            }
        }
    }
}