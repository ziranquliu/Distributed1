using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedDict;
using DistributedBLL.Func;
using DistributedModel.Func;
namespace DistributedBLL
{
    /// <summary>
    /// 角色对应权限实体关系集合处理类
    /// </summary>
   public  class RoleFuncRelation
    {
       //程序启动时加载List集合
       private static List<Roles> roleslist = new List<Roles>();
     
       //Roles对象继承RoleInfo
       public class Roles:RoleInfo
       {
           //一个角色对象对应的权限集合
           public  List<FunctionInfo> functions { get; set; }

       }
        static RoleFuncRelation()
        {
            Init();
        }
        /// <summary>
        /// 根据roleIds查找所有Roles对象
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static List<Roles> GetByRoleIds(string  roleIds)
        {
            var rids=roleIds.Split(',');
            List<Roles> list = roleslist.Where(r => rids.Contains(r.ID.ToString())).ToList(); 
            return list;
        }
        
       /// <summary>
       /// 初始化该静态集合
       /// </summary>
        private static void Init()
        {
            RoleBLL rolebll = new RoleBLL();
            RoleFunctionBLL rolefuncbll = new RoleFunctionBLL();
            FunctionBLL funcbll = new FunctionBLL();
            //获取所有角色
            var rolelist = rolebll.FindList();
            //获取所有角色权限关系
            var rolefunclist = rolefuncbll.FindAll();
            //获取所有权限
            var funclist = funcbll.FindALL();
            //遍历角色
            foreach (var role in rolelist)
            {
                //根据roleid获取该角色所有权限关系
                var rolefunc =rolefunclist.Where(rf=>rf.RoleID==role.ID);
                if (rolefunc.Any())
                {
                    //获取该角色所有权限ids
                    var funcids = rolefunc.Select(rf => rf.FunctionID);
                    //根据权限ids查找对象
                    var funcs = funclist.Where(f=>funcids.Contains(f.ID)).ToList();
                    //实例化当前角色Roles
                    Roles roles = new Roles
                    {
                        ID = role.ID,
                        RoleName = role.RoleName,
                        functions = funcs
                    };
                    //添加到静态集合中
                    roleslist.Add(roles);
                }
            }
        }
    }
}
