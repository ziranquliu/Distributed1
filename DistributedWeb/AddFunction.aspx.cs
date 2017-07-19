using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedModel.Func;
using DistributedBLL.Func;
using DistributedUtil.Helper;
using DistributedBLL;

namespace DistributedWeb
{
    public partial class AddFunction : System.Web.UI.Page
    {
        
        FunctionBLL bll = new FunctionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
           
            if (!IsPostBack)
            {
                BindMenu();
                DoInit();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            
            //验证权限
            if (!AuthHepler.IsAuth(18))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;
            }
            if (Page.IsValid)
            {
                string id = Request["id"];
                //修改时操作
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if (btnOk.CommandName.Equals("update"))
                    {
                        //验证权限
                        if (!AuthHepler.IsAuth(19))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                            return;
                        }
                        var func = GetFunctionInfo();
                        func.ID = int.Parse(id);
                        bll.UpdateFunctionInfo(func);
                    }
                }
                else//此处为添加
                {
                    //验证权限
                    if (!AuthHepler.IsAuth(18))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                        return;
                    }
                    bll.AddFunctionInfo(GetFunctionInfo());
                }
                Response.Redirect("listFunction.aspx");
            }
        }

        #region 菜单项初始化
        /// <summary>
        /// bind menu
        /// </summary>
        protected void BindMenu()
        {
            int parentId = 0;
            List<FunctionInfo> funcList = bll.GetListByParentId(parentId);
            if (funcList.Any())
            {
                foreach (var func in funcList)
                {
                    ddlMenu.Items.Add(new ListItem(func.FunctionName, func.ID.ToString()));
                }
            }
        }
        #endregion

        #region 组织对象
        /// <summary>
        /// 从页面输入信息中组织对象
        /// </summary>
        /// <returns></returns>
        protected FunctionInfo GetFunctionInfo()
        {
            string menuId = ddlMenu.Value;
            string funcName = InputHelper.CleanInputString(txtFuncName.Value);
            //string funcIcon = InputHelper.CleanInputString(txtFuncIcon.Value);
            //string funcPath = InputHelper.CleanInputString(txtFuncPath.Value);
            bool isEnable = ckIsEnable.Checked;
            FunctionInfo func = new FunctionInfo()
            {
                ParentId = int.Parse(menuId),
                FunctionName = funcName,
                //FunctionPath = funcPath,
                IsEnable = isEnable,
                //Icon = funcIcon
            };
            return func;
        }
        #endregion

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
                    var func = bll.FindById(funcId);
                    if (func != null)
                    {
                        ddlMenu.Value = func.ParentId.ToString();
                        txtFuncName.Value = func.FunctionName;
                        //txtFuncPath.Value = func.FunctionPath;
                        //txtFuncIcon.Value = func.Icon;
                        ckIsEnable.Checked = func.IsEnable;
                        btnOk.CommandName = "update";
                    }
                }
            }

        }
        #endregion
    }
}