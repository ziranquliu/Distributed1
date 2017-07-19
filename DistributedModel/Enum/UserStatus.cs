using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedModel.Enum
{
    /// <summary>
    /// 用户登录状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = 3
    }
}
