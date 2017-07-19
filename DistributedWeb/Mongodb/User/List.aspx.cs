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
using DistributedModel.Mongodb.User;
using DistributedBLL.Mongodb.User;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DistributedWeb_MG
{
    public partial class List : System.Web.UI.Page
    {
        LoginUserBLL_MG loginbll = new LoginUserBLL_MG();
        UserBLL_MG userbll = new UserBLL_MG();
        //记录总数
        public long totalcounts = 0;
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
        public List<LoginUserInfo_MG> ulist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.IsLogin();
            if (!IsPostBack)
            {
                IMongoQuery query = Query.Null;
                GetData(query);
            }
        }
        public void GetData(IMongoQuery query)
        {
           
            if (Request["pageIndex"] != null)
            {
                string pageIndex = Request["pageIndex"];
                if (!int.TryParse(pageIndex, out pgindex))
                {
                    return;
                }
            }
            ulist = loginbll.FindListPage(query, pgindex, pageSize, out totalcounts);

            //计算出总页数
            totalPage = ((int)totalcounts + pageSize - 1) / pageSize;
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
            if (!string.IsNullOrWhiteSpace(key))
            {
                switch (type)
                {
                    case "1":
                        GetData(Query.EQ("UserName", key));
                        break;
                    case "2":
                        GetData(Query.EQ("UID", key));
                        break;
                }
            }
            //
          
        }
    }
}