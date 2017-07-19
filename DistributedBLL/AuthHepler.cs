using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedBLL
{
   public class AuthHepler
    {
       /// <summary>
       /// 判断是否拥有权限  根据权限id
       /// </summary>
       /// <param name="funcId"></param>
       /// <returns></returns>
       public static bool IsAuth(int funcId)
       {
           
           //获取roleds  从服务器缓存中
           string roleIds = LoginUser.GetMyRoleIds();
           if (!string.IsNullOrWhiteSpace(roleIds))
           {
               //根据roleIds获取Roles对象列表  从静态集合中
               var roleslist = RoleFuncRelation.GetByRoleIds(roleIds);
               //遍历roles对象列表 
               foreach (var roles in roleslist)
               {
                   var func = roles.functions.Where(f => f.ID == funcId);
                   if (func.Count() > 0)
                   {
                       return true; 
                   }
               }
           }
           return false;
       }
    }
}
