using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DistributedDAL
{
    /// <summary>
    /// Mongodb数据库操作基类
    /// </summary>
    public class MongoHelper
    {
        private static object objLock = new object();
        private static string _MongodbConn;
        /// <summary>
        /// Mongodb数据库连接字符串
        /// </summary>
        private static string MongodbConn
        {
            get
            {
                if (string.IsNullOrEmpty(MongoHelper._MongodbConn))
                {
                    lock (MongoHelper.objLock)
                    {
                        MongoHelper._MongodbConn = MongoHelper.GetConnStr("MongodbConn");
                    }
                }
                return MongoHelper._MongodbConn;
            }
        }
        /// <summary>
        /// 获取Mongodb数据库连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetConnStr(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// 得到一个MongoServer对象
        /// </summary>
        /// <param name="connStr">Mongodb数据库连接字符串</param>
        /// <returns>返回MongoServer对象</returns>
        public static MongoServer GetServer(string connStr)
        {
            MongoClient client = new MongoClient(connStr);
            return client.GetServer();
        }
        /// <summary>
        /// 得到一个MongoDatabase对象
        /// </summary>
        /// <param name="connStr">Mongodb数据库连接字符串</param>
        /// <param name="dbName">Mongodb数据库名称</param>
        /// <returns>返回MongoDatabase对象</returns>
        public static MongoDatabase GetDatabase(string connStr, string dbName)
        {
            return MongoHelper.GetServer(connStr).GetDatabase(dbName);
        }
        /// <summary>
        /// 获取分布式Mongodb数据库的MongoDatabase实例对象
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase GetDistributedMongoDB()
        {
            return MongoHelper.GetDatabase(MongoHelper.MongodbConn, "DistributedDB");
        }
    }
}
