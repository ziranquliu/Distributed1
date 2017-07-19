using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedDict
{
    public class Constellation
    {
        public static Dictionary<int, Item> Dict
        {
            get { return dict; }
        }
        private static Dictionary<int, Item> dict = new Dictionary<int, Item>();

        static Constellation()
        {
            dict.Add(1, new Item { ID = 1, Name = "魔羯座" });
            dict.Add(2, new Item { ID = 2, Name = "水瓶座" });
            dict.Add(3, new Item { ID = 3, Name = "双鱼座" });
            dict.Add(4, new Item { ID = 4, Name = "白羊座" });
            dict.Add(5, new Item { ID = 5, Name = "金牛座" });
            dict.Add(6, new Item { ID = 6, Name = "双子座" });
            dict.Add(7, new Item { ID = 7, Name = "巨蟹座" });
            dict.Add(8, new Item { ID = 8, Name = "狮子座" });
            dict.Add(9, new Item { ID = 9, Name = "处女座" });
            dict.Add(10, new Item { ID = 10, Name = "天秤座" });
            dict.Add(11, new Item { ID = 11, Name = "天蝎座" });
            dict.Add(12, new Item { ID = 12, Name = "射手座" });
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

        public static Item GetItem(DateTime dt)
        {
            return GetItem(dt.Month, dt.Day);
        }

        public static Item GetItem(int month, int day)
        {
            int id = 0;
            if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                id = 1;
            }
            {
                int num = month * 100 + day;
                if (num >= 120 && num <= 218)
                {
                    id = 2;
                }
                else if (num >= 219 && num <= 320)
                {
                    id = 3;
                }
                else if (num >= 321 && num <= 419)
                {
                    id = 4;
                }
                else if (num >= 420 && num <= 520)
                {
                    id = 5;
                }
                else if (num >= 521 && num <= 621)
                {
                    id = 6;
                }
                else if (num >= 622 && num <= 722)
                {
                    id = 7;
                }
                else if (num >= 723 && num <= 822)
                {
                    id = 8;
                }
                else if (num >= 823 && num <= 922)
                {
                    id = 9;
                }
                else if (num >= 923 && num <= 1023)
                {
                    id = 10;
                }
                else if (num >= 1024 && num <= 1122)
                {
                    id = 11;
                }
                else if (num >= 1123 && num <= 1221)
                {
                    id = 12;
                }
            }

            return GetItem(id);
        }
    }
}
