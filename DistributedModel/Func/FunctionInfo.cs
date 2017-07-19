using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedModel.Func
{
    //功能
    public class FunctionInfo
    {
        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>		
        public string FunctionName { get; set; }
        /// <summary>
        /// 功能路径
        /// </summary>		
        public string FunctionPath { get; set; }
        /// <summary>
        /// 图标地址
        /// </summary>		
        public string Icon { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>		
        public bool IsEnable { get; set; }
        /// <summary>
        /// 父类id
        /// </summary>		
        public int ParentId { get; set; }

    }
}
