using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedBLL
{
  public  class BLLConfig
    {
        /// <summary>
        /// 登陆用户cookie过期时间（分钟）
        /// </summary>
        public static readonly int UserCookieExpires = 240;

        /// <summary>
        /// 登陆用户Cookie加密key
        /// </summary>
        public static readonly string UserCookieKey = "usercookiekey";

        /// <summary>
        /// 登陆用户Cookie名
        /// </summary>
        public static readonly string UserCookieName = "DistributedUser";

        /// <summary>
        /// userid加密Key
        /// </summary>
        public static readonly string UserIDKey = "useridkey";
    }
}
