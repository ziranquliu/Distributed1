using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.Func;
using DistributedModel.Func;

namespace DistributedBLL.Func
{
   public class RoleBLL
    {
       RoleDAL dal = new RoleDAL();
       /// <summary>
       /// 添加数据
       /// </summary>
       /// <param name="info">RoleInfo对象</param>
       /// <returns></returns>
       public int AddRoleInfo(RoleInfo info)
       {
           return dal.AddRoleInfo(info);
       }
       /// <summary>
       /// 修改数据
       /// </summary>
       /// <param name="info">RoleInfo对象</param>
       /// <returns></returns>
       public int UpdateRoleInfo(RoleInfo info)
       {
           return dal.UpdateRoleInfo(info);
       }
       /// <summary>
       /// 删除一条数据 根据ID
       /// </summary>
       /// <param name="ID">ID</param>
       /// <returns></returns>
       public int DeleteById(int ID)
       {
           return dal.DeleteById(ID);
       }
       /// <summary>
       /// 查找一条数据 根据ID
       /// </summary>
       /// <param name="ID">ID</param>
       /// <returns>返回RoleInfo对象</returns>
       public RoleInfo FindById(int ID)
       {
           return dal.FindById(ID);
       }
       /// <summary>
       /// 分页显示列表
       /// </summary>
       /// <param name="strWhere">查询条件</param>
       /// <param name="field">查询字段</param>
       /// <param name="pageIndex">页码</param>
       /// <param name="pageSize">页数</param>
       /// <param name="totalCount">记录总数</param>
       /// <returns></returns>
       public List<RoleInfo> FindListPage( int pageIndex, int pageSize, out int totalCount)
       {
           string strWhere = string.Empty;
           return dal.FindListPage(strWhere, "*", pageIndex, pageSize, out totalCount);
       }
       /// <summary>
       /// 查找所有
       /// </summary>
       /// <returns></returns>
       public List<RoleInfo> FindList()
       {
           return dal.FindList();
       }
    }
}
