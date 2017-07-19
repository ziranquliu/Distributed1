using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedDict
{
  public  class Degree
    {
        public static Dictionary<int, Item> Dict
        {
            get { return dict; }
        }
        private static Dictionary<int, Item> dict = new Dictionary<int, Item>();

        static Degree()
        {
            dict.Add(1, new Item { ID = 1, Name = "初中" });
            dict.Add(2, new Item { ID = 2, Name = "高中" });
            dict.Add(3, new Item { ID = 3, Name = "中技" });
            dict.Add(4, new Item { ID = 4, Name = "中专" });
            dict.Add(5, new Item { ID = 5, Name = "大专" });
            dict.Add(6, new Item { ID = 6, Name = "本科" });
            dict.Add(7, new Item { ID = 7, Name = "硕士" });
            dict.Add(8, new Item { ID = 8, Name = "博士" });
            dict.Add(9, new Item { ID = 9, Name = "博士后" });
        }

        public static Item GetItem(int id)
        {
            Item item;
            if (dict.TryGetValue(id, out item))
            {
                return item;
            }
            return new Item { ID = id, Name = null };
        }
    }
}
