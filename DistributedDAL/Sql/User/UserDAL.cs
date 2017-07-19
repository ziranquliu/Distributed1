using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.User;
using System.Data.Common;

namespace DistributedDAL.User
{
   public class UserDAL:BaseDAL<UserInfo>
    {
        /// <summary>
        /// 数据库连接字符串名称
        /// </summary>
       protected override string ConnName
       {
           get { return DbConfig.UserConnection; }
       }
       /// <summary>
       /// 组织对象
       /// </summary>
       /// <param name="reader">Reader对象</param>
       /// <param name="fields">字段集合</param>
       /// <returns></returns>
       protected override UserInfo FillModelFromReader(DbDataReader reader, params string[] fields)
       {
           return ModelFromReader(reader, fields);
       }
       /// <summary>
       /// 组织对象
       /// </summary>
       /// <param name="reader">Reader对象</param>
       /// <param name="fields">字段集合</param>
       /// <returns></returns>
       protected UserInfo ModelFromReader(DbDataReader reader, params string[] fields)
       {
           var info = new UserInfo();
           if (UtilDAL.HasFields("ID", fields)) info.ID = reader["ID"].ToString();
           if (UtilDAL.HasFields("ZodiacId", fields)) info.ZodiacId = (int)reader["ZodiacId"];
           if (UtilDAL.HasFields("Name", fields)) info.Name = reader["Name"].ToString();
           if (UtilDAL.HasFields("Sex", fields)) info.Sex = (int)reader["Sex"];
           if (UtilDAL.HasFields("Phone", fields)) info.Phone = reader["Phone"].ToString();
           if (UtilDAL.HasFields("ProvinceId", fields)) info.ProvinceId = (int)reader["ProvinceId"];
           if (UtilDAL.HasFields("CityId", fields)) info.CityId = (int)reader["CityId"];
           if (UtilDAL.HasFields("ConstellationId", fields)) info.ConstellationId = (int)reader["ConstellationId"];
           if (UtilDAL.HasFields("DegreeId", fields)) info.DegreeId = (int)reader["DegreeId"];
           if (UtilDAL.HasFields("NationId", fields)) info.NationId = (int)reader["NationId"];
           if (UtilDAL.HasFields("AddTime", fields)) info.AddTime = (DateTime)reader["AddTime"];

           return info;
       }
       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="user">UserInfo对象</param>
       /// <returns>返回当前插入的对象ID</returns>
       public int AddUserInfo(UserInfo user)
       {
           var sql = "INSERT INTO [User] ([ID],[Name] ,[Sex] ,[Phone] ,[ProvinceId] ,[CityId] ,[ConstellationId] ,[DegreeId] ,[NationId] ,[ZodiacId] ) "
               + "VALUES (@ID,@Name,@Sex,@Phone,@ProvinceId,@CityId,@ConstellationId,@DegreeId,@NationId,@ZodiacId)";
          return Execute(sql,UtilDAL.CreateParameter("@ID",user.ID),
              UtilDAL.CreateParameter("@Name", user.Name),
               UtilDAL.CreateParameter("@Sex",user.Sex),
               UtilDAL.CreateParameter("@Phone",user.Phone),
               UtilDAL.CreateParameter("@ProvinceId",user.ProvinceId),
               UtilDAL.CreateParameter("@CityId",user.CityId),
               UtilDAL.CreateParameter("@ConstellationId",user.ConstellationId),
               UtilDAL.CreateParameter("@DegreeId",user.DegreeId),
               UtilDAL.CreateParameter("@NationId",user.NationId),
               UtilDAL.CreateParameter("@ZodiacId",user.ZodiacId));
            
       }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="user">UserInfo对象</param>
       /// <returns></returns>
       public int UpdateUserInfo(UserInfo user)
       {
           var sql = "update [User] set [Name] = @Name,[Sex] = @Sex,[Phone] = @Phone,[ProvinceId] = @ProvinceId,[CityId] = @CityId,"
           +"[ConstellationId] = @ConstellationId,[DegreeId] = @DegreeId,[NationId] = @NationId,[ZodiacId] = @ZodiacId where [ID] = @ID";
           int ret = Execute(sql, UtilDAL.CreateParameter("@Name", user.Name),
               UtilDAL.CreateParameter("@Sex", user.Sex),
               UtilDAL.CreateParameter("@Phone", user.Phone),
               UtilDAL.CreateParameter("@ProvinceId", user.ProvinceId),
               UtilDAL.CreateParameter("@CityId", user.CityId),
               UtilDAL.CreateParameter("@ConstellationId", user.ConstellationId),
               UtilDAL.CreateParameter("@DegreeId", user.DegreeId),
               UtilDAL.CreateParameter("@NationId", user.NationId),
               UtilDAL.CreateParameter("@ZodiacId", user.ZodiacId),
               UtilDAL.CreateParameter("@ID", user.ID));
           return ret;
       }
       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="userId">ID</param>
       /// <returns></returns>
       public int DeleteById(string userId)
       {
           var sql = "delete from [User] where ID=@ID";
           return Execute(sql, UtilDAL.CreateParameter("@ID", userId));
       }
      /// <summary>
      /// 查找
      /// </summary>
      /// <param name="userId">ID</param>
      /// <returns></returns>
       public UserInfo FindById(string userId)
       {
           var sql = "select * from [User] where ID=@ID";
           return FindOne(sql, UtilDAL.CreateParameter("@ID", userId));
       }
       /// <summary>
       /// 查询
       /// </summary>
       /// <param name="userIdlist">Id列表</param>
       /// <returns></returns>
       public List<UserInfo> FindList(List<string> userIdlist)
       {
           var sql = string.Format("SELECT * FROM [User] WHERE ID in({0})", string.Join(",", userIdlist));

           return FindList(sql);
       }
    }
}
