using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp13
{
    public class RecipeBook
    {
        public Dictionary<(string, string), string> Recipes { get; set; }

        internal bool CanJoin(Item firstItem, Item secondItem)
        {
            if (firstItem == secondItem && firstItem.Count < 2)
                return false;
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            return Recipes.ContainsKey(key1) || Recipes.ContainsKey(key2);
        }

        internal Item Join(Item firstItem, Item secondItem)
        {
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            if (Recipes.ContainsKey(key1))
                return new Item { Name = Recipes[key1] };
            else
                return new Item { Name = Recipes[key2] };
        }

        public RecipeBook()
        {
            Recipes = new Dictionary<(string, string), string>();
            Recipes.Add(("Корень имбиря","Шерсть"), "Меч +1");
            Recipes.Add(("Меч +1", "Меч +1"), "Меч +2");
            Recipes.Add(("Меч +2", "Меч +1"), "Меч +3");
        }

        public List<Recipe> GetRecipes()
        {
            List<Recipe> result = new List<Recipe>();
            foreach(var key in Recipes.Keys)
            {
                result.Add(new Recipe { FirstItem = key.Item1, SecondItem = key.Item2, Result = Recipes[key] });
            }
            return result;
        }
    }
}
