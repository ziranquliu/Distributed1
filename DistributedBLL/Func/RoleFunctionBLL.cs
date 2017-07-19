using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.Func;
using DistributedModel.Func;

namespace DistributedBLL.Func
{
   public class RoleFunctionBLL
    {
       RoleFunctionDAL dal = new RoleFunctionDAL();
       /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="rolefunc"></param>
        /// <returns></returns>
       public int AddRoleFunc(RoleFunctionInfo rolefunc)
       {
           //判断该roleId是否存在
           RoleBLL rolebll = new RoleBLL();
           if (rolebll.FindById(rolefunc.RoleID).ID <= 0)
               return -1;
           //判断该条记录是否重复
           int counts = dal.FindRoleFunc(rolefunc.RoleID, rolefunc.FunctionID);
           if (counts > 0)
           {
               return -1;
           }
           return dal.AddRoleFunc(rolefunc);
       }
       /// <summary>
        /// 通过roleId查找该用户的所有功能列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
       public List<RoleFunctionInfo> FindListByRoleId(int roleId)
       {
           return dal.FindListByRoleId(roleId);
       }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="funcIds">拼接的funcIds</param>
       /// <returns></returns>
       public int DeleteByIds(string funcIds,int roleId)
       {
           return dal.DeleteByIds(funcIds,roleId);
       }
       /// <summary>
       /// 查找所有
       /// </summary>
       /// <returns></returns>
       public List<RoleFunctionInfo> FindAll()
       {
           return dal.FindAll();
       }
    }
}
