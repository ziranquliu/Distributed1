using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Func;

namespace DistributedDAL.Func
{
    //Function
    public partial class FunctionDAL : BaseDAL<FunctionInfo>
    {
        protected override string ConnName
        {
            get { return DbConfig.DefaultConnection; }
        }

        protected override FunctionInfo FillModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            return ModelFromReader(reader, fields);
        }

        protected FunctionInfo ModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            var info = new FunctionInfo();
            if (UtilDAL.HasFields("ID", fields)) info.ID = (int)reader["ID"];
            if (UtilDAL.HasFields("FunctionName", fields)) info.FunctionName = reader["FunctionName"].ToString();
            if (UtilDAL.HasFields("FunctionPath", fields)) info.FunctionPath = reader["FunctionPath"].ToString();
            if (UtilDAL.HasFields("Icon", fields)) info.Icon = reader["Icon"].ToString();
            if (UtilDAL.HasFields("IsEnable", fields)) info.IsEnable = (bool)reader["IsEnable"];
            if (UtilDAL.HasFields("ParentId", fields)) info.ParentId = (int)reader["ParentId"];

            return info;
        }
        public int AddFunctionInfo(FunctionInfo info)
        {
            var sql = @"insert into [Function]([FunctionName],[FunctionPath],[Icon],[IsEnable],[ParentId]) 
                        values(@FunctionName,@FunctionPath,@Icon,@IsEnable,@ParentId)";
            return Execute(sql, UtilDAL.CreateParameter("@FunctionName", info.FunctionName),
                                UtilDAL.CreateParameter("@FunctionPath", info.FunctionPath),
                                UtilDAL.CreateParameter("@Icon", info.Icon),
                                UtilDAL.CreateParameter("@IsEnable", info.IsEnable),
                                UtilDAL.CreateParameter("@ParentId", info.ParentId));
        }
        public int UpdateFunctionInfo(FunctionInfo info)
        {
            var sql = @"update [Function] 
                        set [FunctionName]=@FunctionName,[FunctionPath]=@FunctionPath,[Icon]=@Icon,[IsEnable]=@IsEnable,[ParentId]=@ParentId 
                        where ID=@ID";
            return Execute(sql, UtilDAL.CreateParameter("@FunctionName", info.FunctionName),
                                UtilDAL.CreateParameter("@FunctionPath", info.FunctionPath),
                                UtilDAL.CreateParameter("@Icon", info.Icon),
                                UtilDAL.CreateParameter("@IsEnable", info.IsEnable),
                                UtilDAL.CreateParameter("@ParentId", info.ParentId),
                                UtilDAL.CreateParameter("@ID", info.ID));
        }
        public int DeleteById(int ID)
        {
            var sql = "delete from [Function] where ID=@ID";
            return Execute(sql, UtilDAL.CreateParameter("@ID", ID));
        }
        public int DeleteByIds(List<int> idlist)
        {
            var sql = "delete from [Function] where ID in ({0})";
            sql = string.Format(sql, string.Join(",", idlist));
            return Execute(sql);
        }
        public FunctionInfo FindById(int ID)
        {
            var sql = "select * from [Function] where ID=@ID";
            return FindOne(sql, UtilDAL.CreateParameter("@ID", ID));
        }
        public List<FunctionInfo> GetListByParentId(int parentId)
        {
            var sql = "select * from [Function] where ParentId=@ParentId";
            return FindList(sql, UtilDAL.CreateParameter("@ParentId", parentId));
        }
        public List<FunctionInfo> FindListPage(string strWhere, string field, int pageIndex, int pageSize, out int totalCount)
        {
            return FindPage("Function", field, strWhere, "ID desc", pageIndex, pageSize, out totalCount);
        }
        public List<FunctionInfo> FindALL()
        {
            var sql = "select * from [Function] ";
            return FindList(sql);
        }
    }
}
