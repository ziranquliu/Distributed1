using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Func;

namespace DistributedDAL.Func
{
    //UserRole
    public partial class UserRoleDAL : BaseDAL<UserRoleInfo>
    {
        protected override string ConnName
        {
            get { return DbConfig.DefaultConnection; }
        }

        protected override UserRoleInfo FillModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            return ModelFromReader(reader, fields);
        }

        protected UserRoleInfo ModelFromReader(System.Data.Common.DbDataReader reader, params string[] fields)
        {
            var info = new UserRoleInfo();
            if (UtilDAL.HasFields("UserID", fields)) info.UserID = reader["UserID"].ToString();
            if (UtilDAL.HasFields("RoleID", fields)) info.RoleID = (int)reader["RoleID"];

            return info;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="userrole"></param>
        /// <returns></returns>
        public int AddUserRole(UserRoleInfo userrole)
        {
            var sql = "insert into UserRole(UserID,RoleID) values(@UserID,@RoleID)";
            return Execute(sql, UtilDAL.CreateParameter("UserID", userrole.UserID),
                UtilDAL.CreateParameter("RoleID", userrole.RoleID));
        }
         /// <summary>
         ///  根据userId和roleId查找是否存在该条记录
         /// </summary>
         /// <param name="userId"></param>
         /// <param name="roleId"></param>
         /// <returns></returns>
        public int FindUserRole(string userId, int roleId)
        {
            var sql = "select count(*) from UserRole where UserID=@UserID and RoleID=@RoleID";
            object obj = GetScalar(sql, UtilDAL.CreateParameter("UserID", userId),
                UtilDAL.CreateParameter("RoleID", roleId)); 
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 通过userId查找该用户的所有角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserRoleInfo> FindListByUserId(string userId)
        {
            var sql = "select * from UserRole where UserID=@UserID";
            return FindList(sql, UtilDAL.CreateParameter("UserID", userId));
        }
        public List<UserRoleInfo> FindList()
        {
            var sql = "select * from UserRole ";
            return FindList(sql);
        }
        public int DeleteByIds(string roleIds, string userId)
        {
            var sql = "delete from UserRole where UserID='{0}' and RoleID in ({1}) ";
            sql = string.Format(sql, userId, roleIds);
            return Execute(sql);
        }
    }
}
