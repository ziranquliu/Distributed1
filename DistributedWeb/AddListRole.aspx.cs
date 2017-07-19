using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedBLL.Func;
using DistributedModel.Func;
using DistributedUtil.Helper;
using DistributedBLL;

namespace DistributedWeb
{
    public partial class AddListRole : System.Web.UI.Page
    {
        //记录总数
        public int totalcounts = 0;
        //页码大小
        public int pageSize = 30;
        //总页数
        public int totalPage = 0;
        //上一页
        public int previosPgIndex = 1;
        //下一页
        public int nextPgIndex = 1;
        //页数
        public int pgindex = 1;
        public RoleBLL bll = new RoleBLL();
        public List<RoleInfo> rlist=new List<RoleInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            //验证权限
            if (!AuthHepler.IsAuth(16))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;
            }
            if (!IsPostBack)
            {
                rlist = bll.FindListPage(pgindex, pageSize, out totalcounts);
                DoInit();
                //计算出总页数
                totalPage = (totalcounts + pageSize - 1) / pageSize;
                //计算上一页 页数
                if (pgindex - 1 > 0)
                {
                    previosPgIndex = pgindex - 1;
                }
                //计算下一页 页数
                if (pgindex + 1 <= totalPage)
                {
                    nextPgIndex = pgindex + 1;
                }
                if (pgindex == totalPage)
                {
                    nextPgIndex = pgindex;
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string roleName = InputHelper.CleanInputString(txtRoleName.Value);
            RoleInfo role = new RoleInfo
            {
                RoleName = roleName
            };
            string id = Request["id"];
            //修改时操作
            if (!string.IsNullOrWhiteSpace(id))
            {
                //验证权限
                if (!AuthHepler.IsAuth(13))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                    return;
                }
                if (btnOk.CommandName.Equals("update"))
                {
                   role.ID = int.Parse(id);
                   bll.UpdateRoleInfo(role);
                }
            }
            else//此处为添加
            {
                //验证权限
                if (!AuthHepler.IsAuth(12))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                    return;
                }
                bll.AddRoleInfo(role);
            }
            Response.Redirect("AddListRole.aspx");
        }

        #region 修改 页面初始化
        private void DoInit()
        {

            string id = Request["id"];
            if (!string.IsNullOrWhiteSpace(id))
            {
                id = InputHelper.CleanInputString(id);
                int funcId = 0;
                if (int.TryParse(id, out funcId))
                {
                    var role = bll.FindById(funcId);
                    if (role != null)
                    {
                        txtRoleName.Value = role.RoleName;
                        btnOk.CommandName = "update";
                    }
                }
            }

        }
        #endregion
        
         
    }
}