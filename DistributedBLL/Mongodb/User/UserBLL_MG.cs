using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.User;
using DistributedModel.User;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace DistributedBLL.User
{
    public class UserBLL_MG
    {
        UserDAL_MG dal = new UserDAL_MG();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public WriteConcernResult AddUserInfo(UserInfo_MG user)
        {
            return dal.AddUserInfo(user);
        }
        /// <summary>
        /// 查找 根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo_MG FindById(string id)
        {
            //组织查询条件
            IMongoQuery query = Query.EQ("UID", id);//相当于sql的UID=uid
            return dal.FindById(query);
        }
        /// <summary>
        /// 修改 UserInfo_MG的ID为默认修改依据 需要赋值
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public WriteConcernResult UpdateUserInfo(UserInfo_MG user)
        {
            return dal.UpdateUserInfo(user);
        }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public WriteConcernResult DeleteById(string uid)
        {
            //组织查询条件 
            IMongoQuery query = Query.EQ("UID", uid);//相当于sql的UID=uid
            return dal.Delete(query);
        }
        /// <summary>
        /// 获取列表 根据userIdlist
        /// </summary>
        /// <param name="userIdlist"></param>
        /// <returns></returns>
        public List<UserInfo_MG> FindList(List<string> userIdlist)
        {
            //组织查询条件
            IMongoQuery query = Query.In("UID", new BsonArray(userIdlist));//相当于sql的UID in(1,2,3,...)
            return dal.FindList(query);
        }
    }
}
