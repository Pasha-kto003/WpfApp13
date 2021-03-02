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
            CreateItem = new Mvvm1125.MvvmCommand(() => { model.TryJoin(FirstItem, SecondItem); }, () => FirstItem != null && SecondItem != null);
        }

        public class BaseItem
        {
            public string Name { get; set; }
            public Mvvm1125.MvvmCommand CreateBaseItem { get; set; }
        }
    }
}
