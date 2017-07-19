using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedUtil.Helper
{
    public class ConvertHelper
    {
        /// <summary>
        /// 根据传入的字符串验证是否可转为Int类型的数组，空串也为false;
        /// </summary>
        /// <param name="strArray">要验证的字符串</param>
        /// <returns></returns>
        public static bool IsIntArray(string strArray)
        {
            try
            {
                int[] list = Array.ConvertAll<string, int>(strArray.Split(','), s => int.Parse(s));
                return false;
            }
            catch { }
            return true;
        }
        /// <summary>
        /// 根据传入的List验证是否可转为Int类型的数组，空串也为false;
        /// </summary>
        /// <param name="List">要验证的List</param>
        /// <returns></returns>
        public static bool IsIntArray(List<string> List)
        {
            try
            {
                string strArray = string.Join(",", List);
                int[] list = Array.ConvertAll<string, int>(strArray.Split(','), s => int.Parse(s));
                return false;
            }
            catch { }
            return true;
        }
    }
}
