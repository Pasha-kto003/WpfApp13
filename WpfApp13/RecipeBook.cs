using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp13
{
    public class RecipeBook
    {
        Dictionary<(string, string), string> recipes = new Dictionary<(string, string), string>();

        internal bool CanJoin(Item firstItem, Item secondItem)
        {
            if (firstItem == secondItem && firstItem.Count < 2)
                return false;
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            return recipes.ContainsKey(key1) || recipes.ContainsKey(key2);
        }

        internal Item Join(Item firstItem, Item secondItem)
        {
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            if (recipes.ContainsKey(key1))
                return new Item { Name = recipes[key1] };
            else
                return new Item { Name = recipes[key2] };
        }

        public RecipeBook()
        {
            recipes.Add(("Корень имбиря","Шерсть"), "Меч +1");
            recipes.Add(("Меч +1", "Меч +1"), "Меч +2");
            recipes.Add(("Меч +2", "Меч +1"), "Меч +3");


        }
    }
}
