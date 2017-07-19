using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedUtil.Helper
{
    /// <summary>
    /// 开关类解析算法
    /// </summary>
    public class SwitchHelper
    {
        /// <summary>
        /// 根据整数得到字符串开关长度固定
        /// </summary>
        /// <param name="Switch">整数，数据库取值</param>
        /// <returns></returns>
        public static string GetStringSwitch(int Switch)
        {
            return Switch.ToString().PadLeft(3, '0');
        }
        /// <summary>
        /// 验证开关状态
        /// </summary>
        /// <param name="strSwitch">开关字符串</param>
        /// <param name="index">要验证的开关所在位置 从0开始</param>
        /// <returns>开为True，关为False</returns>
        public static Boolean CheckSwitch(string strSwitch, int index)
        {
            if (strSwitch.Length > index && strSwitch.Length == 3 && strSwitch.Substring(index, 1) == "0")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改开关字符串
        /// </summary>
        /// <param name="strSwitch">开关字符串</param>
        /// <param name="index">要修改的位置</param>
        /// <param name="Switch">要修改为的值</param>
        /// <returns></returns>
        public static SwitchReslt UpdateStrSwitch(string strSwitch, int index, int Switch)
        {
            SwitchReslt result = null;
            try
            {
                string newSwithc = string.Empty;
                for (int i = 0; i < strSwitch.Length; i++)
                {
                    string oneStr = strSwitch.Substring(i, 1);
                    if (i == index)
                    {
                        oneStr = Switch.ToString();
                    }

                    newSwithc += oneStr;
                }
                if (newSwithc != strSwitch)
                {
                    result = new SwitchReslt()
                    {
                        Status = true,
                        StrSwitch = newSwithc,
                        Switch = Convert.ToInt32(newSwithc)
                    };
                }

            }
            catch { }
            return result;
        }
    }

    public class SwitchReslt
    {
        public Boolean Status { get; set; }
        public string StrSwitch { get; set; }
        public int Switch { get; set; }
    }
}
