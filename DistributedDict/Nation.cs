using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedDict
{
    public class Nation
    {
        public static Dictionary<int, Item> Dict
        {
            get { return dict; }
        }
        private static Dictionary<int, Item> dict = new Dictionary<int, Item>();

        static Nation()
        {
            dict.Add(1, new Item { ID = 1, Name = "汉族" });
            dict.Add(2, new Item { ID = 2, Name = "蒙古族" });
            dict.Add(3, new Item { ID = 3, Name = "回族" });
            dict.Add(4, new Item { ID = 4, Name = "藏族" });
            dict.Add(5, new Item { ID = 5, Name = "维吾尔族" });
            dict.Add(6, new Item { ID = 6, Name = "苗族" });
            dict.Add(7, new Item { ID = 7, Name = "彝族" });
            dict.Add(8, new Item { ID = 8, Name = "壮族" });
            dict.Add(9, new Item { ID = 9, Name = "布依族" });
            dict.Add(10, new Item { ID = 10, Name = "朝鲜族" });
            dict.Add(11, new Item { ID = 11, Name = "满族" });
            dict.Add(12, new Item { ID = 12, Name = "侗族" });
            dict.Add(13, new Item { ID = 13, Name = "瑶族" });
            dict.Add(14, new Item { ID = 14, Name = "白族" });
            dict.Add(15, new Item { ID = 15, Name = "土家族" });
            dict.Add(16, new Item { ID = 16, Name = "哈尼族" });
            dict.Add(17, new Item { ID = 17, Name = "哈萨克族" });
            dict.Add(18, new Item { ID = 18, Name = "傣族" });
            dict.Add(19, new Item { ID = 19, Name = "黎族" });
            dict.Add(20, new Item { ID = 20, Name = "傈僳族" });
            dict.Add(21, new Item { ID = 21, Name = "佤族" });
            dict.Add(22, new Item { ID = 22, Name = "畲族" });
            dict.Add(23, new Item { ID = 23, Name = "高山族" });
            dict.Add(24, new Item { ID = 24, Name = "拉祜族" });
            dict.Add(25, new Item { ID = 25, Name = "水族" });
            dict.Add(26, new Item { ID = 26, Name = "东乡族" });
            dict.Add(27, new Item { ID = 27, Name = "纳西族" });
            dict.Add(28, new Item { ID = 28, Name = "景颇族" });
            dict.Add(29, new Item { ID = 29, Name = "柯尔克孜族" });
            dict.Add(30, new Item { ID = 30, Name = "土族" });
            dict.Add(31, new Item { ID = 31, Name = "达斡尔族" });
            dict.Add(32, new Item { ID = 32, Name = "仫佬族" });
            dict.Add(33, new Item { ID = 33, Name = "羌族" });
            dict.Add(34, new Item { ID = 34, Name = "布朗族" });
            dict.Add(35, new Item { ID = 35, Name = "撒拉族" });
            dict.Add(36, new Item { ID = 36, Name = "毛南族" });
            dict.Add(37, new Item { ID = 37, Name = "仡佬族" });
            dict.Add(38, new Item { ID = 38, Name = "锡伯族" });
            dict.Add(39, new Item { ID = 39, Name = "阿昌族" });
            dict.Add(40, new Item { ID = 40, Name = "普米族" });
            dict.Add(41, new Item { ID = 41, Name = "塔吉克族" });
            dict.Add(42, new Item { ID = 42, Name = "怒族" });
            dict.Add(43, new Item { ID = 43, Name = "乌孜别克族" });
            dict.Add(44, new Item { ID = 44, Name = "俄罗斯族" });
            dict.Add(45, new Item { ID = 45, Name = "鄂温克族" });
            dict.Add(46, new Item { ID = 46, Name = "德昂族" });
            dict.Add(47, new Item { ID = 47, Name = "保安族" });
            dict.Add(48, new Item { ID = 48, Name = "裕固族" });
            dict.Add(49, new Item { ID = 49, Name = "京族" });
            dict.Add(50, new Item { ID = 50, Name = "塔塔尔族" });
            dict.Add(51, new Item { ID = 51, Name = "独龙族" });
            dict.Add(52, new Item { ID = 52, Name = "鄂伦春族" });
            dict.Add(53, new Item { ID = 53, Name = "赫哲族" });
            dict.Add(54, new Item { ID = 54, Name = "门巴族" });
            dict.Add(55, new Item { ID = 55, Name = "珞巴族" });
            dict.Add(56, new Item { ID = 56, Name = "基诺族" });
        }

        public static Item GetItem(int id)
        {
            Item Item;
            if (dict.TryGetValue(id, out Item))
            {
                return Item;
            }
            return new Item { ID = id, Name = null };
        }
    }
}
