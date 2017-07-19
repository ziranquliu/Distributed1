using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.User;
using System.Data.Common;
using DistributedModel.Enum;
using DistributedUtil.Helper;

namespace DistributedDAL.User
{
    public class LoginUserDAL : BaseDAL<LoginUserInfo>
    {
        /// <summary>
        /// 数据库连接字符串名称
        /// </summary>
        protected override string ConnName
        {
            get { return DbConfig.LoginUserConnection; }
        }
        /// <summary>
        /// 组织对象
        /// </summary>
        /// <param name="reader">Reader对象</param>
        /// <param name="fields">字段集合</param>
        /// <returns></returns>
        protected override LoginUserInfo FillModelFromReader(DbDataReader reader, params string[] fields)
        {
            return ModelFromReader(reader, fields);
        }

        /// <summary>
        /// 组织对象
        /// </summary>
        /// <param name="reader">Reader对象</param>
        /// <param name="fields">字段集合</param>
        /// <returns></returns>
        protected LoginUserInfo ModelFromReader(DbDataReader reader, params string[] fields)
        {
            var info = new LoginUserInfo();
            if (UtilDAL.HasFields("ID", fields)) info.ID = reader["ID"].ToString();
            if (UtilDAL.HasFields("UserName", fields)) info.UserName = reader["UserName"].ToString();
            if (UtilDAL.HasFields("UserPwd", fields)) info.UserPwd = reader["UserPwd"].ToString();
            if (UtilDAL.HasFields("UserStatus", fields)) info.UserStatus = (UserStatus)(int)reader["UserStatus"];
            if (UtilDAL.HasFields("LoginIp", fields)) info.LoginIp = reader["LoginIp"].ToString();
            if (UtilDAL.HasFields("LoginType", fields)) info.LoginType = (LoginType)(int)reader["LoginType"];

            return info;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">LoginUserInfo对象</param>
        /// <returns></returns>
        public int AddLoginUserInfo(LoginUserInfo info)
        {
            var sql = "INSERT INTO [LoginUser]([ID],[UserName],[UserPwd],[UserStatus],[LoginIp],[LoginType])"
             + "VALUES(@Id,@UserName,@UserPwd,@UserStatus,@LoginIp,@LoginType)";
            return Execute(sql, UtilDAL.CreateParameter("@Id", info.ID),
                UtilDAL.CreateParameter("@UserName", info.UserName),
                UtilDAL.CreateParameter("@UserPwd", info.UserPwd),
                UtilDAL.CreateParameter("@UserStatus", info.UserStatus),
                UtilDAL.CreateParameter("@LoginIp", info.LoginIp),
                UtilDAL.CreateParameter("@LoginType", info.LoginType));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info">LoginUserInfo对象</param>
        /// <returns></returns>
        public int UpdateLoginUserInfo(LoginUserInfo info)
        {
            var sql = "UPDATE [LoginUser] SET [UserName]=@UserName,[UserPwd]=@UserPwd,[UserStatus]=@UserStatus,[LoginType]=@LoginType"
             + " WHERE ID=@Id";
            return Execute(sql,UtilDAL.CreateParameter("@UserName", info.UserName),
                UtilDAL.CreateParameter("@UserPwd", info.UserPwd),
                UtilDAL.CreateParameter("@UserStatus", info.UserStatus),
                UtilDAL.CreateParameter("@LoginType", info.LoginType),
                UtilDAL.CreateParameter("@Id", info.ID));
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="field">查询字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">记录总数</param>
        /// <returns></returns>
        public List<LoginUserInfo> FindListPage(string strWhere, string field, int pageIndex, int pageSize, out int totalCount)
        {

            return FindPage("LoginUser", field, strWhere, "ID desc", pageIndex, pageSize, out totalCount);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId">ID</param>
        /// <returns></returns>
        public int DeleteById(string userId)
        {
            var sql = "delete from [LoginUser] where ID=@ID";
            return Execute(sql, UtilDAL.CreateParameter("@ID", userId));
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="userId">ID</param>
        /// <returns></returns>
        public LoginUserInfo FindById(string userId)
        {
            var sql = "select * from [LoginUser] where ID=@ID";
            return FindOne(sql, UtilDAL.CreateParameter("@ID", userId));
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName">输入用户名称</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns></returns>
        public string UserLogin(string userName, string userPwd)
        {
            var sql = "select ID from LoginUser where UserName=@UserName and UserPwd=@UserPwd";
            var obj = GetScalar(sql, UtilDAL.CreateParameter("UserName", userName),
                UtilDAL.CreateParameter("UserPwd", userPwd));
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取登陆用户名称
        /// </summary>
        /// <param name="userId">登录用户id</param>
        /// <returns></returns>
        public string GetLoginName(string userId)
        {
            var sql = "select UserName from LoginUser where ID=@ID";
            var obj = GetScalar(sql, UtilDAL.CreateParameter("ID", userId));
            if (obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }
    }
}
