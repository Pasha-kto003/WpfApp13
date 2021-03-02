﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для ListItems.xaml
    /// </summary>
    public partial class ListItems : Page, IPage
    {
        public ListItems()
        {
            InitializeComponent();
        }

        public void SetVM(IPageVM vm)
        {
            DataContext = vm;
        }
    }
}
