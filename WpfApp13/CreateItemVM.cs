using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp13
{
    public class CreateItemVM : Mvvm1125.MvvmNotify, IPageVM
    {

        public ObservableCollection<Item> Items { get; set; }
        public Item FirstItem { get; set; }
        public Item SecondItem { get; set; }
        public Mvvm1125.MvvmCommand CreateItem { get; set; }
        public List<BaseItem> BaseItems { get; set; }
        Model model;

        public void SetModel(Model model)
        {
            this.model = model;
            CreateItem = new Mvvm1125.MvvmCommand(
                () => { 
                    if(model.TryJoin(FirstItem, SecondItem)) 
                        PageContainer.ChangePageTo(PageType.ListItems); }, 
                () => FirstItem != null && SecondItem != null);
            BaseItems = new List<BaseItem>();
            BaseItems.Add(new BaseItem { 
                Name = "Корень имбиря", 
                CreateBaseItem = new Mvvm1125.MvvmCommand(
                    () => model.AddItem(new Item { Name = "Корень имбиря"}),
                    () => true)
            });
            BaseItems.Add(new BaseItem
            {
                Name = "Хлеб",
                CreateBaseItem = new Mvvm1125.MvvmCommand(
                    () => model.AddItem(new Item { Name = "Хлеб" }),
                    () => true)
            });
            BaseItems.Add(new BaseItem
            {
                Name = "Шерсть",
                CreateBaseItem = new Mvvm1125.MvvmCommand(
                    () => model.AddItem(new Item { Name = "Шерсть" }),
                    () => true)
            });
            model.ItemsChanged += Model_ItemsChanged;
        }

        private void Model_ItemsChanged(object sender, EventArgs e)
        {
            Items = model.GetItems();
            NotifyPropertyChanged("Items");
        }

        public class BaseItem
        {
            public string Name { get; set; }
            public Mvvm1125.MvvmCommand CreateBaseItem { get; set; }
        }
    }
}
