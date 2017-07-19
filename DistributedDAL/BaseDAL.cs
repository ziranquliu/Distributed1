using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DistributedDAL
{
    /// <summary>
    /// dal 基类   
    /// 作者：苏飞
    /// 时间：2014-10-10
    /// 官网: http://fenbu.sufeinet.com
    /// </summary>
    /// <typeparam name="T">任意类型</typeparam>
    public abstract class BaseDAL<T>
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected abstract string ConnName
        {
            get;
        }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnStr()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[ConnName].ConnectionString;
        }
        /// <summary>
        /// 获取一个集合
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">指定如何解释命令字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected List<T> FindList(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (var reader = SqlHelper.ExecuteReader(GetConnStr(), type, sql, parameters))
            {
                List<T> list = new List<T>();
                var fields = UtilDAL.GetReaderFieldNames(reader);
                while (reader.Read())
                {
                    list.Add(FillModelFromReader(reader, fields));
                }
                return list;
            }
        }
        /// <summary>
        /// 获取一个集合 Sql语句专用
        /// </summary>
        /// <param name="sql">SQl语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected List<T> FindList(string sql, params SqlParameter[] parameters)
        {
            return FindList(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">指定如何解释命令字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected T FindOne(string sql, CommandType type, params SqlParameter[] parameters)
        {
            return FindList(sql, type, parameters).FirstOrDefault();
        }
        /// <summary>
        /// 获取一个对象 Sql语句专用
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected T FindOne(string sql, params SqlParameter[] parameters)
        {
            return FindOne(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// 获取一个集合带分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段名</param>
        /// <param name="query">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">行数</param>
        /// <param name="isTotal">是否返回总数</param>
        /// <param name="totalCount">总数</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        private List<T> FindPage(string tableName, string fields, string query, string orderby, int pageIndex, int pageSize, bool isTotal, out int totalCount, params SqlParameter[] parameters)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentException("pageIndex参数应>1");
            }

            StringBuilder sb = new StringBuilder();
            SqlParameter[] newPs;
            if (isTotal)
            {
                sb.AppendFormat("select count(0) from [{0}]", tableName);
                if (!string.IsNullOrWhiteSpace(query))
                {
                    sb.AppendFormat(" where {0}", query);
                }
                totalCount = GetCount(sb.ToString(), parameters);
                sb.Clear();
                newPs = SqlHelper.CopyParameters(parameters);
            }
            else
            {
                newPs = parameters;
                totalCount = 0;
            }

            if (string.IsNullOrWhiteSpace(orderby))
            {
                throw new ArgumentException("orderby参数不应为空");
            }

            var fs = string.IsNullOrWhiteSpace(fields) ? "*" : string.Join(",", fields);
            sb.AppendFormat("select {0} from (", fs);
            sb.AppendFormat(" select top {0} {1},ROW_NUMBER() over(order by {2}) rowid from [{3}]", pageIndex * pageSize, fs, orderby, tableName);
            if (!string.IsNullOrWhiteSpace(query))
            {
                sb.AppendFormat(" where {0}", query);
            }
            sb.AppendFormat(")t where t.rowid>{0} and t.rowid<={1}", (pageIndex - 1) * pageSize, pageIndex * pageSize);

            return FindList(sb.ToString(), CommandType.Text, newPs);
        }
        /// <summary>
        /// 获取一个集合带分页 带总数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段名</param>
        /// <param name="query">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">行数</param>
        /// <param name="totalCount">总数</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected List<T> FindPage(string tableName, string fields, string query, string orderby, int pageIndex, int pageSize, out int totalCount, params SqlParameter[] parameters)
        {
            return FindPage(tableName, fields, query, orderby, pageIndex, pageSize, true, out totalCount, parameters);
        }
        /// <summary>
        ///  获取一个集合带分页 不带总数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段名</param>
        /// <param name="query">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">行数</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected List<T> FindPage(string tableName, string fields, string query, string orderby, int pageIndex, int pageSize, params SqlParameter[] parameters)
        {
            int totalCount;
            return FindPage(tableName, fields, query, orderby, pageIndex, pageSize, false, out totalCount, parameters);
        }
        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">指定如何解释命令字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected object GetScalar(string sql, CommandType type, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteScalar(GetConnStr(), type, sql, parameters);
        }
        /// <summary>
        /// 获取一个对象  Sql语句专用
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected object GetScalar(string sql, params SqlParameter[] parameters)
        {
            return GetScalar(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// 统计总数
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">指定如何解释命令字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected int GetCount(string sql, CommandType type, params SqlParameter[] parameters)
        {
            var obj = GetScalar(sql, type, parameters);
            if (obj == null) return -1;
            return (int)obj;
        }
        /// <summary>
        /// 统计总数  Sql语句专用
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected int GetCount(string sql, params SqlParameter[] parameters)
        {
            return GetCount(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// 返回影响的行数
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="type">指定如何解释命令字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected int Execute(string sql, CommandType type, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(GetConnStr(), type, sql, parameters);
        }
        /// <summary>
        /// 返回影响的行数  Sql语句专用
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected int Execute(string sql, params SqlParameter[] parameters)
        {
            return Execute(sql, CommandType.Text, parameters);
        }
        /// <summary>
        /// 生成对象的方法，在每个子类中实现
        /// </summary>
        /// <param name="reader">DbDataReader对象</param>
        /// <param name="fields">字段数组</param>
        /// <returns></returns>
        protected abstract T FillModelFromReader(DbDataReader reader, params string[] fields);
    }
}
