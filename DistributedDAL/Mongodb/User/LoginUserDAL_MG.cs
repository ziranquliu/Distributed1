using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Mongodb.User;
using MongoDB.Driver;

namespace DistributedDAL.Mongodb.User
{
    public class LoginUserDAL_MG:MongoBaseDAL<LoginUserInfo_MG>
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
        /// LoginUserInfo的CollectionName集合名称
        /// </summary>
        protected override string CollectionName
        {
            get { return DbConfig.MongodbLoginUserCollectionName; }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public WriteConcernResult AddLoginUserInfo(LoginUserInfo_MG user)
        {
            return Insert(user);
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public LoginUserInfo_MG FindById(IMongoQuery query)
        {
            return FindOne(query);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user">UserInfo_MG对象</param>
        /// <returns></returns>
        public WriteConcernResult UpdateLoginUserInfo(LoginUserInfo_MG user)
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
        /// 获取列表带分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<LoginUserInfo_MG> FindListPage(IMongoQuery query, int pageIndex, int pageSize, out long totalCount)
        {
            totalCount = Count(query);
            return Find(query).SetSkip((pageIndex - 1) * pageSize).SetLimit(pageSize).ToList() ;
        }
    }
}
