using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using DistributedModel.User;

namespace DistributedDAL.User
{
    public class UserDAL_MG:MongoBaseDAL<UserInfo_MG>       
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected override string MongodbConn
        {
            get { return DbConfig.MongodbConn; }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        protected override string MongodbDatabaseName
        {
            get { return DbConfig.MongodbDatabaseName; }
        }
        /// <summary>
        /// UserInfo的CollectionName集合名称
        /// </summary>
        protected override string CollectionName
        {
            get { return DbConfig.MongodbUserCollectionName; }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public WriteConcernResult AddUserInfo(UserInfo_MG user)
        {
            return Insert(user);
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserInfo_MG FindById(IMongoQuery query)
        {
            return FindOne(query);
        }
       /// <summary>
       /// 修改
       /// </summary>
        /// <param name="user">UserInfo_MG对象</param>
       /// <returns></returns>
        public WriteConcernResult UpdateUserInfo(UserInfo_MG user)
        {
            return Save(user);
        }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="query"></param>
       /// <returns></returns>
        public WriteConcernResult Delete(IMongoQuery query)
        {
            return Remove(query);
        }
        /// <summary>
        /// 查找 根据query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<UserInfo_MG> FindList(IMongoQuery query)
        {
            return Find(query).ToList();
        }
    }
}
