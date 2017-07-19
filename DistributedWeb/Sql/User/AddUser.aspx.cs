using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistributedDict;
using DistributedModel.User;
using DistributedUtil.Helper;
using DistributedBLL.User;
using DistributedModel.Enum;
using System.Web.UI.HtmlControls;
using DistributedBLL;
namespace DistributedWeb
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserBLL userbll=new UserBLL();
        LoginUserBLL loginbll=new LoginUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否登陆
            LoginUser.IsLogin();
            if (!IsPostBack)
            {
                BindSelect();
                DoUpdate();
            }
        }

        /// <summary>
        /// 初始化下拉控件
        /// </summary>
        public void BindSelect()
        {
            List<Item> ProvList = Area.Dict.Values.ToList();
            List<Item> CityList = Area.Dict[3].Children.Values.ToList();
            List<Item> GenderList = Gender.Dict.Values.ToList();
            List<Item> ZodiacList = Zodiac.Dict.Values.ToList();
            List<Item> ConstellationList = Constellation.Dict.Values.ToList();
            List<Item> DegreeList = Degree.Dict.Values.ToList();
            List<Item> NationList = Nation.Dict.Values.ToList();
            GetOptions(ddlProv, ProvList);
            GetOptions(ddlCity, CityList);
            GetOptions(ddlGender, GenderList);
            GetOptions(ddlZodiac, ZodiacList);
            GetOptions(ddlConstellation, ConstellationList);
            GetOptions(ddlDegree, DegreeList);
            GetOptions(ddlNation, NationList);
           
        }


        public void GetOptions(HtmlSelect select,List<Item> list)
        {
            foreach (Item item in list)
            {
                select.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
           
        }
        public void DoUpdate()
        {
            //修改操作初始化
            if (Request["id"] != null)
            {
                string userId = Request["id"];
                //通过userId获取当前LoginUserInfo对象和UserInfo对象
                LoginUserInfo loginuser = loginbll.FindById(userId);
                UserInfo user = userbll.FindById(userId);
                if (loginuser == null || user == null)
                {
                    return;
                }
                //赋权限id
                btnOk.CommandArgument = "2";
                //以下是页面初始化操作
               txtUserName.Value=user.Name;
               ddlGender.Value=user.Sex.ToString();
               txtPhone.Value=user.Phone;
               ddlZodiac.Value=user.ZodiacId.ToString();
               ddlProv.Value=user.ProvinceId.ToString();

               ddlCity.Items.Clear();
               GetOptions(ddlCity, Area.Dict[user.ProvinceId].Children.Values.ToList());
               ddlCity.Value=user.CityId.ToString();


               ddlConstellation.Value=user.ConstellationId.ToString();
               ddlDegree.Value=user.DegreeId.ToString();
               ddlNation.Value=user.NationId.ToString();
               
               txtLoginUserName.Value=loginuser.UserName;
               ddlUserStatus.Value = Convert.ToInt32(loginuser.UserStatus).ToString();
               //txtPwd.Value=loginuser.UserPwd;
               ddlLoginType.Value = Convert.ToInt32(loginuser.LoginType).ToString();
                
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Add();
                Update();
            }
        }

        public void Add()
        {
            if (Request["id"] == null)
            {
                //从页面输入信息组织UserInfo对象
                UserInfo user = GetUser();
                //添加成功返回当前对象的唯一标识ID
                int ret = userbll.AddUserInfo(user);
                if (ret > 0)
                {
                    //从页面输入信息组织LoginUserInfo对象（传递唯一标识ID）
                    LoginUserInfo loginuser = GetLoginUser(user.ID);
                    //添加LoginUserInfo对象
                    loginbll.AddLoginUserInfo(loginuser);
                    Response.Redirect("list.aspx");
                }
            }
        }
        public void Update()
        {
            if (Request["id"] != null)
            {
                string userId = Request["id"];
                //从页面输入信息组织UserInfo对象
                UserInfo user = GetUser();
                user.ID = userId;
                //从页面输入信息组织LoginUserInfo对象（传递唯一标识ID）
                LoginUserInfo loginuser = GetLoginUser(userId);
                //更新
                loginbll.UpdateLoginUserInfo(loginuser);
                //更新
                userbll.UpdateUserInfo(user);
                Response.Redirect("list.aspx");
            }
        }
        /// <summary>
        /// 获取UserInfo对象 通过页面 此时返回的对象ID未赋值  修改操作时需赋ID值
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUser()
        {
            string name = txtUserName.Value;
            string phone = txtPhone.Value.Trim(); ;
            string sex = ddlGender.Value;
            string zodiac = ddlZodiac.Value;
            string constellation = ddlConstellation.Value;
            string degree = ddlDegree.Value;
            string nation = ddlNation.Value;
            string provice = ddlProv.Value;
            string city = ddlCity.Value;
            UserInfo user = new UserInfo
            {
                ID=Guid.NewGuid().ToString("N"),
                Name = name,
                Phone = phone,
                Sex = InputHelper.GetInputInt(sex),
                ZodiacId = InputHelper.GetInputInt(zodiac),
                ConstellationId = InputHelper.GetInputInt(constellation),
                DegreeId = InputHelper.GetInputInt(degree),
                NationId = InputHelper.GetInputInt(nation),
                ProvinceId = InputHelper.GetInputInt(provice),
                CityId = InputHelper.GetInputInt(city)
            };
            return user;
        }
        /// <summary>
        /// 获取LoginUserInfo对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public LoginUserInfo GetLoginUser(string userId)
        {
            string loginUser = txtLoginUserName.Value;
            string userStatus = ddlUserStatus.Value;
            string pwd = EncryptHelper.MD5(txtPwd.Value);
            string loginType = ddlLoginType.Value;
            string loginIP = Request.UserHostAddress;
            LoginUserInfo loginuser = new LoginUserInfo
            {
                ID = userId,
                UserName = loginUser,
                UserPwd = pwd,
                LoginIp = loginIP,
                UserStatus = (UserStatus)int.Parse(userStatus),
                LoginType = (LoginType)int.Parse(loginType)
            };
            return loginuser;
        }

    }
}