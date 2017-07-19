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
namespace DistributedWeb
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
        public List<Item> ProvList;
        public List<Item> CityList;
        public List<Item> GenderList;
        public List<Item> ZodiacList;
        public List<Item> ConstellationList;
        public List<Item> DegreeList;
        public List<Item> NationList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetList();
            }
        }
        public void GetList()
        {
            ProvList = Area.Dict.Values.ToList();
            CityList = Area.Dict[3].Children.Values.ToList();
            GenderList = Gender.Dict.Values.ToList();
            ZodiacList = Zodiac.Dict.Values.ToList();
            ConstellationList = Constellation.Dict.Values.ToList();
            DegreeList = Degree.Dict.Values.ToList();
            NationList = Nation.Dict.Values.ToList();
        }
       
        public string GetOptions(List<Item> list)
        {
            string options = "";
            foreach (Item item in list)
            {
                options += string.Format("<option value=\"{0}\">{1}</option>", item.ID, item.Name);
            }
            return options;
        }
       
    }
}