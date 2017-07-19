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
    public partial class ListFunction : System.Web.UI.Page
    {
        //记录总数
        public int totalcounts = 0;
        //页码大小
        public int pageSize =30;
        //总页数
        public int totalPage = 0;
        //上一页
        public int previosPgIndex = 1;
        //下一页
        public int nextPgIndex = 1;
        //页数
        public int pgindex = 1;
        protected FunctionBLL bll = new FunctionBLL();
        public List<FunctionInfo> funclist=new List<FunctionInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            //验证权限
            if (!AuthHepler.IsAuth(21))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "js", "alert('没有权限！')", true);
                return;
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }
        protected void GetData()
        {
           
            if (Request["pageIndex"] != null)
            {
                string pageIndex = Request["pageIndex"];
                if (!int.TryParse(pageIndex, out pgindex))
                {
                    return;
                }
            }
            funclist = bll.FindTopFuncList(pgindex, pageSize, out totalcounts);

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
}