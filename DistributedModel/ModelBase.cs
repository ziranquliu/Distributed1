using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedModel
{
    /// <summary>
    /// 模型层附加数据基类
    /// </summary>
    [Serializable]
    public class ModelBase
    {
        private Dictionary<string, object> _exData = new Dictionary<string, object>();

        public Dictionary<string, object> ExData
        {
            get { return _exData; }
            set { _exData = value; }
        }

        /// <summary>
        /// 得到附加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetExData<T>(string name)
        {
            object data;
            if (_exData.TryGetValue(name, out data))
            {
                return (T)data;
            }
            return default(T);
        }

        /// <summary>
        /// 添加附加数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public void AddExData(string name, object obj)
        {
            _exData.Add(name, obj);
        }


        /// <summary>
        /// 检测附加数据是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistsExData(string name)
        {
            return _exData.ContainsKey(name);
        }
    }
}
