using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.User;
using DistributedModel.User;

namespace DistributedBLL.User
{
    public class UserBLL
    {
        UserDAL dal=new UserDAL();
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="user">UserInfo对象</param>
        /// <returns>添加成功返回1，否则0</returns>
        public int AddUserInfo(UserInfo user)
        {
            return dal.AddUserInfo(user);
        }
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserInfo(UserInfo user)
        {
            return dal.UpdateUserInfo(user);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteById(string userId)
        {
            return dal.DeleteById(userId);
        }
        /// <summary>
        /// 获取列表 根据userIdlist
        /// </summary>
        /// <param name="userIdlist"></param>
        /// <returns></returns>
        public List<UserInfo> FindList(List<string> userIdlist)
        {
            return dal.FindList(userIdlist);
        }
        /// <summary>
        /// 获取一个对象根据userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfo FindById(string userId)
        {
            return dal.FindById(userId);
        }
    }
}
