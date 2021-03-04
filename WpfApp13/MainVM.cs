using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp13
{
    public class MainVM : Mvvm1125.MvvmNotify
    {
        Model model;

        public Page CurrentPage { get; set; }

        public MainVM()
        {
            model = new Model();
            PageContainer.SetModel(model);
            CurrentPage = PageContainer.GetPageByType(PageType.ListItems);
            PageContainer.CurrentPageChanged += PageContainer_CurrentPageChanged;
            model.Load();
            Application.Current.Exit += (o, e) => model.Save();
        }

        private void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = PageContainer.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}