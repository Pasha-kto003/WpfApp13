using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp13
{
    public class Inventory
    {
        public List<Item> Items { get; set; } = new List<Item>();

        internal void IncrementItem(Item item)
        {
            var found = Items.FirstOrDefault(s => s.Name == item.Name);
            if (found == null)
            {
                item.Count = 1;
                Items.Add(item);
            }
            else
            {
                found.Count++;
            }
        }

        internal void DecrementItem(Item item)
        {
            var found = Items.FirstOrDefault(s => s.Name == item.Name);
            if (found != null)
            {
                found.Count--;
                if (found.Count == 0)
                    Items.Remove(found);
            }
        }
    }
}
