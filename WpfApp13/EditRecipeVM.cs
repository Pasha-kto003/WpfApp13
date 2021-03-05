using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp13
{
    public class EditRecipeVM : Mvvm1125.MvvmNotify, IPageVM
    {
        Model model;
        RecipeBook recipeBook;
        public List<Recipe> Recipes { get => model.Recipes; set => model.Recipes = value; }
        public Mvvm1125.MvvmCommand BackToList { get; set; }
        public Mvvm1125.MvvmCommand CreateRecipe { get; set; }
        public Mvvm1125.MvvmCommand RemoveRecipe { get; set; }

        public Recipe SelectedRecipe { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            recipeBook = model.recipeBook;
            model.RecipesChanged += Model_RecipesChanged;
            BackToList = new Mvvm1125.MvvmCommand(
                () => PageContainer.ChangePageTo(PageType.ListItems),
                () => true);
            CreateRecipe = new Mvvm1125.MvvmCommand(
                () => model.AddRecipe(),
                () => true);
            RemoveRecipe = new Mvvm1125.MvvmCommand(
                () => model.RemoveRecipe(SelectedRecipe),
                () => true);
        }

        private void Model_RecipesChanged(object sender, EventArgs e)
        {
            Recipes = model.GetRecipes();
            NotifyPropertyChanged("Recipes");
        }
    }
}
