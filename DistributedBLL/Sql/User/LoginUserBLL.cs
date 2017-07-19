using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.User;
using DistributedModel.User;
using DistributedUtil.Helper;

namespace DistributedBLL.User
{
  public class LoginUserBLL
    {
      LoginUserDAL dal = new LoginUserDAL();
      /// <summary>
      /// 添加一条记录
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public int AddLoginUserInfo(LoginUserInfo info)
      {
          return dal.AddLoginUserInfo(info);
      }
     

      /// <summary>
      /// 根据条件返回列表 带分页
      /// </summary>
      /// <param name="strWhere">要查询的条件</param>
      /// <param name="pageIndex">页数</param>
      /// <param name="pageSize">页码</param>
      /// <param name="totalCount">记录总数</param>
      /// <returns></returns>
      public List<LoginUserInfo> FindListPage(string strWhere, int pageIndex, int pageSize, out int totalCount)
      {
          List<LoginUserInfo> ulist = dal.FindListPage(strWhere, "", pageIndex, pageSize, out totalCount);
          if (ulist.Count <= 0)
          {
              return null;
          }
          //关联LoginUserInfo 实现两表之间的关系查询
          var userIdlist = ulist.Select(u =>"'"+ u.ID+"'");//这里需要注意
          //从这里解决链表和子查询
          UserBLL userbll = new UserBLL();
          //根据主表关联的ID去数据库查询子表数据，因为是ID，所以速度最快
          List<UserInfo> userList = userbll.FindList(userIdlist.ToList());
          //使用Foreach将数据的关键链接起来
          foreach (LoginUserInfo loginuser in ulist)
          {
              //这是就是数据关联的条件，满足这个条件的就说明是我们链接或者是要子查询的数据
              if (userList.Any(u => u.ID == loginuser.ID))
              {
                  UserInfo loginuserinfo = userList.FirstOrDefault(u => u.ID == loginuser.ID);
                  //将得到的子表数据直接添加的主表。完美解决子查询和链表问题
                  loginuser.AddExData("UserInfo", loginuserinfo);
              }
          }
          return ulist;
      }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="userId"></param>
      /// <returns></returns>
      public int DeleteById(string userId)
      {
          return dal.DeleteById(userId);
      }
      /// <summary>
      /// 根据userId查找对象
      /// </summary>
      /// <param name="userId"></param>
      /// <returns></returns>
      public LoginUserInfo FindById(string userId)
      {
          return dal.FindById(userId);
      }
      /// <summary>
      /// 更新对象
      /// </summary>
      /// <param name="info">LoginUserInfo对象</param>
      /// <returns></returns>
      public int UpdateLoginUserInfo(LoginUserInfo info)
      {
          return dal.UpdateLoginUserInfo(info);
      }
      /// <summary>
      /// 用户登陆  登陆成功返回该用户id 否则返回空字符串
      /// </summary>
      /// <param name="userName">用户名</param>
      /// <param name="userPwd">用户密码</param>
      /// <returns>成功时返回该用户id 失败返回空字符串string.Empty</returns>
      public string UserLogin(string userName, string userPwd)
      {
          userPwd = EncryptHelper.MD5(userPwd);
          return dal.UserLogin(userName, userPwd);
      }
       /// <summary>
        /// 获取登陆用户名称
        /// </summary>
        /// <param name="userId">登录用户id</param>
        /// <returns></returns>
      public string GetLoginName(string userId)
      {
          return dal.GetLoginName(userId);
      }
    }
}
