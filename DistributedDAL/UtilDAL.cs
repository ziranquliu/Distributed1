using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace DistributedDAL
{
    internal static class UtilDAL
    {
        public static string GetParameterName(string name)
        {
            if (name.StartsWith("@"))
            {
                return name;
            }
            return "@" + name;
        }

        public static bool HasFields(string field, params string[] fields)
        {
            if (fields == null || fields.Length == 0)
                return true;
            return fields.Contains(field);
        }

        public static string[] GetReaderFieldNames(DbDataReader reader)
        {
            var fields = new string[reader.FieldCount];
            for (var i = 0; i < reader.FieldCount; i++)
            {
                fields[i] = reader.GetName(i);
            }
            return fields;
        }

        public static SqlParameter CreateParameter(string name, object value)
        {
            name = UtilDAL.GetParameterName(name);
            if (value == null)
            {
                return new SqlParameter(name, DBNull.Value);
            }
            return new SqlParameter(name, value);
        }

        public static SqlParameter CreateOutParameter(string name, SqlDbType dbType)
        {
            name = UtilDAL.GetParameterName(name);
            var p = new SqlParameter(name, dbType);
            p.Direction = ParameterDirection.Output;
            return p;
        }

        public static SqlParameter CreateReturnParameter(SqlDbType dbType)
        {
            return CreateReturnParameter("@ret", dbType);
        }

        public static SqlParameter CreateReturnParameter(string name, SqlDbType dbType)
        {
            name = UtilDAL.GetParameterName(name);
            var p = new SqlParameter(name, dbType);
            p.Direction = ParameterDirection.ReturnValue;
            return p;
        }
    }
}
