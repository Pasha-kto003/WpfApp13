using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp13
{
    public class EditRecipeVM : Mvvm1125.MvvmNotify, IPageVM
    {
        Model model;
        public Dictionary<(string, string), string> Recipes { get; set; }
        public Mvvm1125.MvvmCommand BackToList { get; set; }
        public Mvvm1125.MvvmCommand CreateRecipe { get; set; }
        public Mvvm1125.MvvmCommand RemoveRecipe { get; set; }

        public ((string, string), string) SelectedRecipe { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            BackToList = new Mvvm1125.MvvmCommand(
                () => PageContainer.ChangePageTo(PageType.ListItems),
                () => true);
        }
    }
}
