using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DistributedDAL
{
    public static class SqlHelper
    {
        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            var conn = new SqlConnection(connString);
            var cmd = new SqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //cmd.Parameters.Clear();
            return rdr;
        }

        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            using (var conn = new SqlConnection(connString))
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                var obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj;
            }
        }

        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            using (var conn = new SqlConnection(connString))
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                var count = cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                return count;
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (trans != null)
                cmd.Transaction = trans;

            if (cmdParams != null)
            {
                foreach (var parm in cmdParams)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        public static SqlParameter[] CopyParameters(params SqlParameter[] parames)
        {
            SqlParameter[] ps = new SqlParameter[parames.Length];
            for (int i = 0; i < parames.Length; i++)
            {
                ps[i] = (SqlParameter)((ICloneable)parames[i]).Clone();
            }
            return ps;
        }

    }
}
