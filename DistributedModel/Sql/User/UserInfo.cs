using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDict;

namespace DistributedModel.User
{
    /// <summary>
    /// 用户基类
    /// </summary>
    public class UserInfo 
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 获取用户性别汉字
        /// </summary>
        /// <returns>汉字男或者女</returns>
        public string GetSex()
        {
            return Gender.GetItem(Sex).Name;
        }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 所在省
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 获取省汉字
        /// </summary>
        /// <returns></returns>
        public string GetProvince()
        {
            return Area.GetProvince(ProvinceId).Name;
        }
        /// <summary>
        /// 所在市
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 获取城市汉字
        /// </summary>
        /// <returns></returns>
        public string GetCity()
        {
            return Area.GetCity(CityId).Name;
        }
        /// <summary>
        /// 12星座ID
        /// </summary>
        public int ConstellationId { get; set; }
        /// <summary>
        /// 获取星座汉字
        /// </summary>
        /// <returns></returns>
        public string GetConstellation()
        {
            return Constellation.GetItem(ConstellationId).Name;
        }
        /// <summary>
        /// 学历ID
        /// </summary>
        public int DegreeId { get; set; }
        /// <summary>
        /// 获取学历汉字 
        /// </summary>
        /// <returns></returns>
        public string GetDegree()
        {
            return Degree.GetItem(DegreeId).Name;
        }
        /// <summary>
        /// 民族ID
        /// </summary>
        public int NationId { get; set; }
        /// <summary>
        /// 获取民族汉字
        /// </summary>
        /// <returns></returns>
        public string GetNation()
        {
            return Nation.GetItem(NationId).Name;
        }
        /// <summary>
        /// 生肖ID
        /// </summary>
        public int ZodiacId { get; set; }
        /// <summary>
        /// 获取生肖汉字 
        /// </summary>
        /// <returns></returns>
        public string GetZodiac()
        {
            return Zodiac.GetItem(ZodiacId).Name;
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
