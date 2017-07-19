using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedBLL.User;
using DistributedModel.User;
using DistributedUtil.Helper;
using DistributedBLL;

namespace DistributedWeb
{
    public partial class List : System.Web.UI.Page
    {
        LoginUserBLL loginbll = new LoginUserBLL();
        UserBLL userbll = new UserBLL();
        //记录总数
        public int totalcounts = 0;
        //页码大小
        public int pageSize = 3;
        //总页数
        public int totalPage = 0;
        //上一页
        public int previosPgIndex = 1;
        //下一页
        public int nextPgIndex = 1;
        //页数
        public int pgindex = 1;
        public List<LoginUserInfo> ulist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            if (!IsPostBack)
            {
                GetData("");
            }
        }
        public void GetData(string strWhere)
        {
           
            if (Request["pageIndex"] != null)
            {
                string pageIndex = Request["pageIndex"];
                if (!int.TryParse(pageIndex, out pgindex))
                {
                    return;
                }
            }
            ulist = loginbll.FindListPage(strWhere, pgindex, pageSize, out totalcounts);

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
        
        protected void btnsearch_Click(object sender, EventArgs e)
        {
           
            //接收关键字
            string key = RequestHelper.GetStringValue(txtKey.Value.Trim());
            string type =ddltype.Value;
            //拼接查询语句
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
            //
            GetData(strWhere);
        }
    }
}