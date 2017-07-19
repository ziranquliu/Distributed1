using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedModel.Enum
{
    /// <summary>
    /// 登录用户类型
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// 超级用户
        /// </summary>
        Default = 0,
        /// <summary>
        /// Web端登录用户
        /// </summary>
        Web = 1,
        /// <summary>
        /// 客户端登录用户
        /// </summary>
        Custom = 2,
        /// <summary>
        /// 服务端用户
        /// </summary>
        Server = 3,
        /// <summary>
        /// 移动端用户
        /// </summary>
        Mobile = 4
    }
}
