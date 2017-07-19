using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedUtil.Helper;

namespace DistributedDAL
{
    /// <summary>
    /// 所有表的连接字符串都写在这里，方法统一修改
    /// </summary>
    public static class DbConfig
    {
        /// <summary>
        /// 默认的连接字符串
        /// </summary>
        public readonly static string DefaultConnection ="DefaultConnection";
        /// <summary>
        /// User表的连接字符串
        /// </summary>
        public static readonly string UserConnection ="UserConnection";
        /// <summary>
        /// LoginUser表的连接字符串
        /// </summary>
        public static readonly string LoginUserConnection = "LoginUserConnection";
        /// <summary>
        /// Mongodb数据库连接字符串
        /// </summary>
        public static readonly string MongodbConn = "MongodbConn";
        /// <summary>
        /// Mongodb数据库名称
        /// </summary>
        public static readonly string MongodbDatabaseName = "DistributedDB";
        /// <summary>
        /// Mongodb数据库User集合名称
        /// </summary>
        public static readonly string MongodbUserCollectionName = "User";
        /// <summary>
        /// Mongodb数据库LoginUser集合名称
        /// </summary>
        public static readonly string MongodbLoginUserCollectionName = "LoginUser";
        ///// <summary>
        ///// Function表的连接字符串
        ///// </summary>
        //public static readonly string FunctionConnection = "FunctionConnection";
        ///// <summary>
        ///// RoleFunction表的连接字符串
        ///// </summary>
        //public static readonly string RoleFunctionConnection = "RoleFunctionConnection";
        ///// <summary>
        ///// UserRole表的连接字符串
        ///// </summary>
        //public static readonly string UserRoleConnection = "UserRoleConnection";
    }
}
