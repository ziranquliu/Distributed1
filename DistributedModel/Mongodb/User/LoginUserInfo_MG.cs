using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DistributedModel.Mongodb.User
{
    /// <summary>
    /// 登录用户
    /// </summary>
    public class LoginUserInfo_MG:ModelBase
    {
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID { get; set; }     
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [BsonElement("UserStatus")]
        public UserStatus UserStatus { get; set; }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string LoginIp { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        [BsonElement("LoginType")]
        public LoginType LoginType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterBy { get; set; }
    }
}
