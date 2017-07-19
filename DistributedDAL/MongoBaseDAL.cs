using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace DistributedDAL
{
    public abstract class MongoBaseDAL<T>
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected abstract string MongodbConn
        {
            get;
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        protected abstract string MongodbDatabaseName
        {
            get;
        }
        /// <summary>
        /// CollectionName 集合 可以理解为表名
        /// </summary>
        protected abstract string CollectionName
        {
            get;
        }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnStr()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[MongodbConn].ConnectionString;
        }
        /// <summary>
        /// MongoCollection对象
        /// </summary>
        protected MongoCollection<T> coll
        {
            get { return GetMongoCollection(); }
        }
        /// <summary>
        /// 获取MongoCollection集合
        /// </summary>
        /// <returns></returns>
        protected MongoCollection<T> GetMongoCollection()
        {
            MongoDatabase mongodb = MongoHelper.GetDatabase(GetConnStr(), MongodbDatabaseName);
            return mongodb.GetCollection<T>(CollectionName);
        }
        /// <summary>
        /// 添加T对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected WriteConcernResult Insert(T t)
        {
            return coll.Insert(t);
        }
        /// <summary>
        /// 查找 根据query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>返回T对象</returns>
        protected T FindOne(IMongoQuery query)
        {
            return coll.FindOne(query);
        }
        /// <summary>
        /// 查找 根据query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>返回MongoCursor<T>对象</returns>
        protected MongoCursor<T> Find(IMongoQuery query)
        {
            return coll.Find(query);
        }
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected WriteConcernResult Save(T t)
        {
            return coll.Save(t);
        }
        /// <summary>
        /// 删除操作 根据query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected WriteConcernResult Remove(IMongoQuery query)
        {
            return coll.Remove(query);
        }
        /// <summary>
        /// 根据query得到记录总数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected long Count(IMongoQuery query)
        {
            return coll.Count(query);
        }
    }
}
