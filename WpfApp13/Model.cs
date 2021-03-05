using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WpfApp13
{
    public class Model
    {
        Inventory inventory = new Inventory();
        public event EventHandler ItemsChanged;
        public event EventHandler RecipesChanged;
        public RecipeBook recipeBook = new RecipeBook();
        public List<Recipe> Recipes { get => GetRecipes(); set => Recipes = value; }

        internal ObservableCollection<Item> GetItems()
        {
            return new ObservableCollection<Item>(inventory.Items);
        }

        internal List<Recipe> GetRecipes()
        {
            return recipeBook.GetRecipes();
        }

        public bool TryJoin(Item firstItem, Item secondItem)
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

        internal void RemoveRecipe(Recipe selectedRecipe)
        {
            Recipes.Remove(selectedRecipe);
            RecipesChanged?.Invoke(this, null);
        }

        internal void AddRecipe()
        {
            throw new NotImplementedException();
            RecipesChanged?.Invoke(this, null);
        }

        internal void AddItem(Item item)
        {
            inventory.IncrementItem(item);
            ItemsChanged?.Invoke(this, null);
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(inventory.Items, typeof(List<Item>));
            File.WriteAllText("items.db", json);

            //using (StreamWriter sw = new StreamWriter("recipes.txt"))
            //{
            //    string text;
            //    var recipes = recipeBook.Recipes;
            //    foreach (((string,string)string)recipe in recipes)
            //    sw.Write("");
            //}
        }

        public void Load()
        {
            string file = "items.db";
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                inventory.Items = new List<Item>();
                return;
            }
            string json = File.ReadAllText(file);
            inventory.Items = (List<Item>)JsonSerializer.Deserialize(json, typeof(List<Item>));
            ItemsChanged?.Invoke(this, null);
        }
    }
}