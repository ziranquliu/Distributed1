using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Func;

namespace DistributedDAL.Func
{
    //RoleFunction
    public partial class RoleFunctionDAL : BaseDAL<RoleFunctionInfo>
    {
        protected override string ConnName
        {
            get { return DbConfig.DefaultConnection; }
        }

        protected override RoleFunctionInfo FillModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            return ModelFromReader(reader, fields);
        }

        protected RoleFunctionInfo ModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            var info = new RoleFunctionInfo();
            if (UtilDAL.HasFields("RoleID", fields)) info.RoleID = (int)reader["RoleID"];
            if (UtilDAL.HasFields("FunctionID", fields)) info.FunctionID = (int)reader["FunctionID"];

            return info;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="rolefunc"></param>
        /// <returns></returns>
        public int AddRoleFunc(RoleFunctionInfo rolefunc)
        {
            var sql = "insert into RoleFunction(RoleID,FunctionID) values(@RoleID,@FunctionID) ";
            return Execute(sql, UtilDAL.CreateParameter("RoleID", rolefunc.RoleID),
                UtilDAL.CreateParameter("FunctionID", rolefunc.FunctionID));
        }
        /// <summary>
        /// 根据roleId和functionId查找是否存在该记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="funcId"></param>
        /// <returns></returns>
        public int FindRoleFunc(int roleId, int funcId)
        {
            var sql = "select count(*) from RoleFunction where RoleID=@RoleID and FunctionID=@FunctionID";
            object obj=GetScalar(sql, UtilDAL.CreateParameter("RoleID", roleId),
                UtilDAL.CreateParameter("FunctionID", funcId));
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 通过roleId查找该用户的所有功能列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleFunctionInfo> FindListByRoleId(int roleId)
        {
            var sql = "select * from RoleFunction where RoleID=@RoleID";
            return FindList(sql, UtilDAL.CreateParameter("RoleID", roleId));
        }
        public int DeleteByIds(string funcIds, int roleId)
        {
            var sql = "delete from RoleFunction where RoleID={0} and FunctionID in ({1})";
            sql = string.Format(sql, roleId, funcIds);
            return Execute(sql);
        }
        public List<RoleFunctionInfo> FindAll()
        {
            var sql = "select * from RoleFunction ";
            return FindList(sql);
        }
    }
}
