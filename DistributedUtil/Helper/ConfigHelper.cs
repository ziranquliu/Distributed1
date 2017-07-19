using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DistributedUtil.Helper
{
    /// <summary>
    /// 读取配置文件的方法
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 根据Key获取AppSetting_Value值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string As_GetValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch { }
            return string.Empty;
        }
        /// <summary>
        /// 根据Key获取AppSetting_Value值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string Cs_GetValue(string key)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch { }
            return string.Empty;
        }
    }
}
