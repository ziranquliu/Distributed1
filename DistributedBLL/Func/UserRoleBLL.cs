using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.Func;
using DistributedDAL.Func;
using DistributedBLL.User;

namespace DistributedBLL.Func
{
   public class UserRoleBLL
    {
       UserRoleDAL dal = new UserRoleDAL();
       /// <summary>
       /// 插入一条记录
       /// </summary>
       /// <param name="userrole"></param>
       /// <returns></returns>
       public int AddUserRole(UserRoleInfo userrole)
       {
           //判断userId是否存在
           LoginUserBLL ubll = new LoginUserBLL();
           if (string.IsNullOrWhiteSpace(ubll.FindById(userrole.UserID).ID))
           {
               return -1;
           }
           //如存在该条记录就返回-1 不做处理
           int counts = dal.FindUserRole(userrole.UserID, userrole.RoleID);
           if (counts > 0)
           {
               return -1;
           }
           return dal.AddUserRole(userrole);
       }
       /// <summary>
       /// 通过userId查找该用户的所有角色列表
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public List<UserRoleInfo> FindListByUserId(string userId)
       {
           return dal.FindListByUserId(userId);
       }
       /// <summary>
       /// 查找所有
       /// </summary>
       /// <returns></returns>
       public List<UserRoleInfo> FindList()
       {
           return dal.FindList();
       }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="roleIds">拼接的roleIds</param>
       /// <returns></returns>
       public int DeleteByIds(string roleIds,string userId)
       {
           return dal.DeleteByIds(roleIds,userId);
       }
    }
}
