using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedDict
{
    public class Gender
    {
        public static Dictionary<int, Item> Dict
        {
            get { return dict; }
        }
        private static Dictionary<int, Item> dict = new Dictionary<int, Item>();

        static Gender()
        {
            dict.Add(1, new Item { ID = 1, Name = "男", EName = "Male" });
            dict.Add(2, new Item { ID = 2, Name = "女", EName = "Female" });
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
