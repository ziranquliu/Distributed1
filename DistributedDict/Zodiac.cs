using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedDict
{
    public class Zodiac
    {
        public static Dictionary<int, Item> Dict
        {
            get { return dict; }
        }
        private static Dictionary<int, Item> dict = new Dictionary<int, Item>();

        static Zodiac()
        {
            dict.Add(1, new Item { ID = 1, Name = "鼠" });
            dict.Add(2, new Item { ID = 2, Name = "牛" });
            dict.Add(3, new Item { ID = 3, Name = "虎" });
            dict.Add(4, new Item { ID = 4, Name = "兔" });
            dict.Add(5, new Item { ID = 5, Name = "龙" });
            dict.Add(6, new Item { ID = 6, Name = "蛇" });
            dict.Add(7, new Item { ID = 7, Name = "马" });
            dict.Add(8, new Item { ID = 8, Name = "羊" });
            dict.Add(9, new Item { ID = 9, Name = "猴" });
            dict.Add(0, new Item { ID = 10, Name = "鸡" });
            dict.Add(11, new Item { ID = 11, Name = "狗" });
            dict.Add(12, new Item { ID = 12, Name = "猪" });
        }

        public static Item GetItem(int year)
        {
            if (year > 12)
            {
                year = Math.Abs(year - 1900) % 12 + 1;
            }

            Item item;
            if (dict.TryGetValue(year, out item))
            {
                return item;
            }
            return new Item { ID = year, Name = null };
        }
    }
}
