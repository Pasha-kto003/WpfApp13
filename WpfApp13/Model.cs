using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp13
{
    public class Model
    {
        Inventory inventory = new Inventory();
        public event EventHandler ItemsChanged;
        RecipeBook recipeBook = new RecipeBook();

        internal ObservableCollection<Item> GetItems()
        {
            return new ObservableCollection<Item>(inventory.Items);
        }

        internal bool TryJoin(Item firstItem, Item secondItem)
        {
            if(recipeBook.CanJoin(firstItem, secondItem))
            {
                inventory.DecrementItem(firstItem);
                inventory.DecrementItem(secondItem);
                Item newItem = recipeBook.Join(firstItem, secondItem);
                AddItem(newItem);
                return true;
            }
            return false;
        }

        internal void AddItem(Item item)
        {
            inventory.IncrementItem(item);
            ItemsChanged?.Invoke(this, null);
        }
    }
}