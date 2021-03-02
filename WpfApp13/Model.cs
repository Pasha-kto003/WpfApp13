using System;
using System.Collections.ObjectModel;

namespace WpfApp13
{
    public class Model
    {
        Inventory inventory = new Inventory();
        public event EventHandler ItemsChanged;

        internal ObservableCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        internal void TryJoin(Item firstItem, Item secondItem)
        {
            throw new NotImplementedException();
        }
    }
}