using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedUtil.Helper
{
    public class RequestHelper
    {
        /// <summary>
        /// 根据字符串返回相应值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串</returns>
        public static string GetStringValue(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            return str.Trim();
        }

        /// <summary>
        /// 根据字符串返回相应的整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>整数</returns>
        public static int GetIntValue(string str)
        {
            //loogn 修改 2014-04-23
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            int i;
            int.TryParse(str.Trim(), out i);
            return i;
        }

        /// <summary>
        /// 根据字符串返回相应对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象</returns>
        public static object GetObjValue(object obj)
        {
            if (obj != null)
            {
                return null;
            }
            return obj;
        }
    }
}
