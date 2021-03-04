using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp13
{
    public class ListItemsVM : Mvvm1125.MvvmNotify, IPageVM
    { 
        public ObservableCollection<Item> Items { get; set; }
        public Mvvm1125.MvvmCommand CreateItem { get; set; }
        public Mvvm1125.MvvmCommand EditRecipe { get; set; }
        Model model;

        public void SetModel(Model model)
        {
            this.model = model;
            Items = model.GetItems();
            model.ItemsChanged += Model_ItemsChanged;   
            CreateItem = new Mvvm1125.MvvmCommand(
                () => PageContainer.ChangePageTo(PageType.CreateItem), 
                () => true);
            EditRecipe = new Mvvm1125.MvvmCommand(
                () => PageContainer.ChangePageTo(PageType.EditRecipe),
                () => true);
        }

        private void Model_ItemsChanged(object sender, EventArgs e)
        {
            Items = model.GetItems();
            NotifyPropertyChanged("Items");
        }
    }
}
