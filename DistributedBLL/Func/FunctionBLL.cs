using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDAL.Func;
using DistributedModel.Func;

namespace DistributedBLL.Func
{
    public class FunctionBLL
    {
        FunctionDAL dal = new FunctionDAL();
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="info">FunctionInfo对象</param>
        /// <returns></returns>
        public int AddFunctionInfo(FunctionInfo info)
        {
            return dal.AddFunctionInfo(info);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="info">FunctionInfo对象</param>
        /// <returns></returns>
        public int UpdateFunctionInfo(FunctionInfo info)
        {
            return dal.UpdateFunctionInfo(info);
        }
        /// <summary>
        /// 删除一条数据 根据ID
        /// </summary>
        /// <param name="ID">FunctionInfo对象ID</param>
        /// <returns></returns>
        public int DeleteById(int ID)
        {
            //先判断该条数据是否存在子类，先删除子类后再删除该条数据
            List<FunctionInfo> list = GetListByParentId(ID);
            if (list.Any())
            {
                List<int> idlist = new List<int>();
                foreach (var func in list)
                {
                    //将子类id add到idlist
                    idlist.Add(func.ID);
                }
                //删除该功能下所有子类功能
                dal.DeleteByIds(idlist);
            }
            return dal.DeleteById(ID);
        }
        /// <summary>
        /// 获取功能列表 根据parentId 值为0时获取根目录菜单
        /// </summary>
        /// <param name="parentId">父类id</param>
        /// <returns></returns>
        public List<FunctionInfo> GetListByParentId(int parentId)
        {
            return dal.GetListByParentId(parentId);
        }
        /// <summary>
        /// 查找一条数据 根据ID
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public FunctionInfo FindById(int ID)
        {
            return dal.FindById(ID);
        }
        /// <summary>
        /// 分页显示列表 获取所有一级菜单项列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="field">查询字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">记录总数</param>
        /// <returns></returns>
        public List<FunctionInfo> FindTopFuncList(int pageIndex, int pageSize, out int totalCount)
        {
            string strWhere = "ParentId=0";
            return dal.FindListPage(strWhere, "*", pageIndex, pageSize, out totalCount);
        }
        /// <summary>
        /// 查找所有
        /// </summary>
        /// <returns></returns>
        public List<FunctionInfo> FindALL()
        {
            return dal.FindALL();
        }
    }
}
