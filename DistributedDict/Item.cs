using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedDict
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EName { get; set; }
        public Dictionary<int, Item> Children { get; set; }
        public Item Parent { get; set; }

        public List<string > DominList { get; set; }

        public void AddChild(Item child)
        {
            Children.Add(child.ID, child);
            child.Parent = this;
        }

        public override string ToString()
        {
            var str = "ID:" + ID;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                str += ", Name:\"" + Name + "\"";
            }
            if (!string.IsNullOrWhiteSpace(EName))
            {
                str += ", EName:\"" + EName + "\"";
            }
            if (Children != null && Children.Count > 0)
            {
                str += ", Children:" + Children.Count;
            }
            return str;
        }
    }
}
