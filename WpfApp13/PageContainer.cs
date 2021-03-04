using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp13
{
    public class PageContainer
    {
        static Dictionary<PageType, Page> pages = new Dictionary<PageType, Page>();
        static Dictionary<PageType, (Type, Type)> pageTypes = new Dictionary<PageType, (Type, Type)>();

        static Model model;

        public static event EventHandler<PageType> CurrentPageChanged;

        public static void RegisterPageType(PageType type, Type pageType, Type VmType)
        {
            if (pageTypes.ContainsKey(type))
                throw new Exception("Заданный тип страницы уже существует.");
            pageTypes.Add(type, (pageType, VmType));
        }

        public static Page GetPageByType(PageType type)
        {
            if (pages.ContainsKey(type))
                return pages[type];
            var page = (Page)Activator.CreateInstance(pageTypes[type].Item1);
            var vm = (IPageVM)Activator.CreateInstance(pageTypes[type].Item2);
            vm.SetModel(model);
            ((IPage)page).SetVM(vm);
            pages.Add(type, page);
            return page;
        }

        public static void ChangePageTo(PageType type)
        {
            CurrentPageChanged?.Invoke(null, type);
        }

        public static void SetModel(Model model)
        {
            PageContainer.model = model;
        }

        static PageContainer()
        {
            RegisterPageType(PageType.ListItems, typeof(ListItems), typeof(ListItemsVM));
            RegisterPageType(PageType.CreateItem, typeof(CreateItem), typeof(CreateItemVM));
            RegisterPageType(PageType.EditRecipe, typeof(EditRecipe), typeof(EditRecipeVM));
        }
    }
}
