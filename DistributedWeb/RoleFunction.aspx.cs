using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedBLL.Func;
using DistributedModel.Func;
using DistributedBLL;

namespace DistributedWeb
{
    public partial class RoleFunction : System.Web.UI.Page
    {
        //记录总数
        public int totalcounts = 0;
        //页码大小
        public int pageSize = 100;
        //总页数
        public int totalPage = 0;
        //上一页
        public int previosPgIndex = 1;
        //下一页
        public int nextPgIndex = 1;
        //页数
        public int pgindex = 1;
        protected FunctionBLL fucbll = new FunctionBLL();
        protected RoleFunctionBLL rfbll = new RoleFunctionBLL();
        public List<FunctionInfo> funclist = new List<FunctionInfo>();
        public List<int> funids = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            //验证权限
            if (!AuthHepler.IsAuth(15))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;
            }
            if (!IsPostBack)
            {
                GetData();
            }
            GetRoleIds();
        }
        protected void GetRoleIds()
        {
            if (!string.IsNullOrWhiteSpace(Request["roleId"]))
            {
                string str = Request["roleId"];
                int roleid = 0;
                if (!int.TryParse(str, out roleid))
                {
                    return;
                }
                //获取角色所拥有的所有权限list
                List<RoleFunctionInfo> rflist = rfbll.FindListByRoleId(roleid);
                //获取角色所拥有的权限id list<int>
                funids = rflist.Select(rf => rf.FunctionID).ToList(); 
            }
        }
        protected void GetData()
        {

            if (string.IsNullOrWhiteSpace(Request["roleId"]))
            {
                return;
            }
            if (Request["pageIndex"] != null)
            {
                string pageIndex = Request["pageIndex"];
                if (!int.TryParse(pageIndex, out pgindex))
                {
                    return;
                }
            }
            //获取所有父级权限list
            funclist = fucbll.FindTopFuncList(pgindex, pageSize, out totalcounts);
           
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取权限idlist
            if (!AuthHepler.IsAuth(15))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;
            }
            if (!string.IsNullOrWhiteSpace(Request["roleId"]))
            {
                string str=Request["roleId"];
                int roleId = 0;
                if (int.TryParse(str, out roleId))
                {
                    string ck = Request["ck"];
                    if (!string.IsNullOrWhiteSpace(ck))
                    {
                        var ids = ck.Split(',');
                        foreach (var id in ids)
                        {
                            if (!string.IsNullOrWhiteSpace(id))
                            {
                                RoleFunctionInfo rolefuc = new RoleFunctionInfo
                                {
                                    RoleID = roleId,
                                    FunctionID = int.Parse(id)
                                };
                                rfbll.AddRoleFunc(rolefuc);
                            }
                        }
                    }

                    if (funids.Any())
                    {
                        //checked已有的权限ids
                        var cked = Request["cked"];
                        //要删除的权限ids
                        string delids = string.Empty;
                        if (string.IsNullOrWhiteSpace(cked))
                        {
                            delids = string.Join(",", funids);
                        }
                        else
                        {
                            var ckedids = cked.Split(',');
                            //遍历已有权限列表
                            foreach (var funid in funids)
                            {
                                //checked已有的权限ids如果不包含了该id，则拼接到删除字符串中
                                if (!ckedids.Contains(funid.ToString()))
                                {
                                    delids += funid + ",";
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
                            rfbll.DeleteByIds(delids,roleId);
                        }
                    }
                }
            }
            Response.Redirect("AddListRole.aspx");
        }

        
    }
}