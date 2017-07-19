using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedModel.User;

namespace DistributedDAL
{
   public class UserDAL:BaseDAL<UserInfo>
    {
       protected override string ConnName
       {
           get { return DbConfig.DefaultConnection; }
       }
       
    }
}
