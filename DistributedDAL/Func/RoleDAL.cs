using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Func;

namespace DistributedDAL.Func
{
    //Role
    public partial class RoleDAL : BaseDAL<RoleInfo>
    {
        protected override string ConnName
        {
            get { return DbConfig.DefaultConnection; }
        }

        protected override RoleInfo FillModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            return ModelFromReader(reader, fields);
        }

        protected RoleInfo ModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            var info = new RoleInfo();
            if (UtilDAL.HasFields("ID", fields)) info.ID = (int)reader["ID"];
            if (UtilDAL.HasFields("RoleName", fields)) info.RoleName = reader["RoleName"].ToString();

            return info;
        }
        public int AddRoleInfo(RoleInfo info)
        {
            var sql = @"insert into [Role]([RoleName]) 
                         values(@RoleName)";
            return Execute(sql, UtilDAL.CreateParameter("@RoleName", info.RoleName));
        }
        public int UpdateRoleInfo(RoleInfo info)
        {
            var sql = "update [Role] set [RoleName]=@RoleName where ID=@ID";
            return Execute(sql, UtilDAL.CreateParameter("@RoleName", info.RoleName),
                                UtilDAL.CreateParameter("@ID", info.ID));
        }
        public int DeleteById(int ID)
        {
            var sql = "delete from [Role] where ID=@ID";
            return Execute(sql, UtilDAL.CreateParameter("@ID", ID));
        }
        public RoleInfo FindById(int ID)
        {
            var sql = "select * from [Role] where ID=@ID";
            return FindOne(sql, UtilDAL.CreateParameter("@ID", ID));
        }
        public List<RoleInfo> FindListPage(string strWhere, string field, int pageIndex, int pageSize, out int totalCount)
        {

            return FindPage("Role", field, strWhere, "ID desc", pageIndex, pageSize, out totalCount);
        }
        public List<RoleInfo> FindList()
        {
            var sql = "select * from [Role]";
            return FindList(sql);
        }
    }
}
