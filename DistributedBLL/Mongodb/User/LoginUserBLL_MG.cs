using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.Mongodb.User;
using DistributedModel.Mongodb.User;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DistributedBLL.User;
using DistributedModel.User;

namespace DistributedBLL.Mongodb.User
{
    public class LoginUserBLL_MG
    {
        LoginUserDAL_MG dal = new LoginUserDAL_MG();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginuser"></param>
        /// <returns></returns>
        public WriteConcernResult AddLoginUserInfo(LoginUserInfo_MG loginuser)
        {
            return dal.AddLoginUserInfo(loginuser);
        }
        /// <summary>
        /// 修改 LoginUserInfo_MG的ID为默认修改依据 需要赋值
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public WriteConcernResult UpdateLoginUserInfo(LoginUserInfo_MG user)
        {
            return dal.UpdateLoginUserInfo(user);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WriteConcernResult DeleteByID(string userId)
        {
            //组织查询条件
            IMongoQuery query = Query.EQ("UID", userId);//相当于sql的UID=userId
            return dal.Delete(query);
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public LoginUserInfo_MG FindById(string userId)
        {
            //组织查询条件
            IMongoQuery query = Query.EQ("UID", userId);//相当于sql的UID=userId
            return dal.FindById(query);
        }
        public List<LoginUserInfo_MG> FindListPage(IMongoQuery query, int pageIndex, int pageSize, out long totalCount)
        {
            List<LoginUserInfo_MG> ulist = dal.FindListPage(query, pageIndex, pageSize, out totalCount);
            if (ulist.Count <= 0)
            {
                return null;
            }
            //关联LoginUserInfo 实现两表之间的关系查询
            var userIdlist = ulist.Select(u =>u.UID);
            //从这里解决链表和子查询
            UserBLL_MG userbll = new UserBLL_MG();
            //根据主表关联的ID去数据库查询子表数据，因为是ID，所以速度最快
            List<UserInfo_MG> userList = userbll.FindList(userIdlist.ToList());
            //使用Foreach将数据的关键链接起来
            foreach (LoginUserInfo_MG loginuser in ulist)
            {
                //这是就是数据关联的条件，满足这个条件的就说明是我们链接或者是要子查询的数据
                if (userList.Any(u => u.UID == loginuser.UID))
                {
                    UserInfo_MG loginuserinfo = userList.FirstOrDefault(u => u.UID == loginuser.UID);
                    //将得到的子表数据直接添加的主表。完美解决子查询和链表问题
                    loginuser.AddExData("UserInfo", loginuserinfo);
                }
            }
            return ulist;
        }
    }
}
