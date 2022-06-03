using Controls.SearchControl.Model;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Accordion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Controls.SearchControl.ViewModel
{
    public class SearchControlViewModel
    {
       public SearchControlViewModel()
        {
            PopulateMenuItems();
        }
        public ObservableCollection<MenuItem> Items { get; set; }
        public ObservableCollection<MenuItem> FavItems { get; set; }
        public ObservableCollection<MenuItem> MRUItems { get; set; }
       

        public MenuItem SelectedRootItem { get; set; }


        private MenuItem selectedItem;
        public MenuItem SelectedItem
        {
            get { return selectedItem; }
            set { 
               
                selectedItem = value;
                
            }
        }

        private DelegateCommand<MenuItem> favouriteClickedCommand;
        public ICommand FavouriteClickedCommand
        {
            get
            {
                if (favouriteClickedCommand == null)
                {
                    favouriteClickedCommand = new DelegateCommand<MenuItem>(OnFavouriteClicked);
                }
                return favouriteClickedCommand;
            }
        }

        private void OnFavouriteClicked(MenuItem menuItem)
        {
            menuItem.IsFavourite = true;
            if(!this.FavItems.Contains(menuItem))
                this.FavItems.Insert(0, menuItem);
        }
        void UpdateMRUItems(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                menuItem.IsMRU = true;
                if (!MRUItems.Contains(menuItem))
                    MRUItems.Insert(0, menuItem);
            }
        }
        public void OnItemDoubleClicked(MenuItem item)
        {
            UpdateMRUItems(item);
        }
        void PopulateMenuItems()
        {
            CreateTestViewsItems();

        }
        public MenuItem CreateTestViewsItems()
        {
            var allMenuItems = GetMenuItems();
            var menuItemViews = new MenuItem("Views", MenuItemType.RootViewHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>());

            menuItemViews.MenuItems.AddRange(allMenuItems);
            //menuItemViews.MenuItems.Add(GetSeperatorMenuItem());
            //menuItemViews.MenuItems.AddRange(GetMRUMenuItems(allMenuItems));


            var menuItemFavs =  new MenuItem("Favourites", MenuItemType.RootFavHeader, showInCollapsedMode: true, menuItems: GetFavouriteMenuItems(allMenuItems));

            Items = new ObservableCollection<MenuItem>(menuItemViews.MenuItems);
            FavItems = new ObservableCollection<MenuItem>(menuItemFavs.MenuItems);
            MRUItems = new ObservableCollection<MenuItem>(GetMRUMenuItems(allMenuItems));
            return menuItemViews;



            //var result = new List<MenuItem>();
            //result.Add(MenuItem.Create("Views", MenuItemType.ViewHeader,  showInCollapsedMode: true, menuItems: new List<MenuItem>() {
            //    MenuItem.Create("View", MenuItemType.SubItem),
            //    MenuItem.Create("View 1", MenuItemType.SubItem),
            //    MenuItem.Create("View 2", MenuItemType.SubItem),
            //    MenuItem.Create("View 3", MenuItemType.SubItem),
            //    MenuItem.Create("GridTest", MenuItemType.SubItem),
            //    MenuItem.Create("TestData", MenuItemType.SubItem)
            //}));
            //result.Add(MenuItem.Create("History",MenuItemType.MRUHeader, isCustomView: true, menuItems: new List<MenuItem>() {
            //    MenuItem.Create("View", MenuItemType.SubItem)
            //}));
            
            //return result;
        }

        //public MenuItem CreateTestFavItems()
        //{
        //    return MenuItem.Create("Favourites", MenuItemType.RootFavHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>() {
        //        MenuItem.Create("View 1", MenuItemType.SubItem),
        //        MenuItem.Create("View 2", MenuItemType.SubItem)
        //    });
        //}

        public List<MenuItem> GetMRUMenuItems(IEnumerable<MenuItem> menuItems)
        {
            return menuItems.Where(x => x.IsMRU).ToList();
        }

        public List<MenuItem> GetFavouriteMenuItems(IEnumerable<MenuItem> menuItems)
        {
            return menuItems.Where(x => x.IsFavourite).ToList();
        }
        public MenuItem GetSeperatorMenuItem()
        {
            return new MenuItem() { Header = "", MenuItemType = MenuItemType.Seperator };
        }
        public List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>() {
                new MenuItem(){ Header = "View", MenuItemType = MenuItemType.SubItem, IsMRU = false },
                new MenuItem(){ Header = "View 1", MenuItemType = MenuItemType.SubItem, IsMRU = false },
                new MenuItem(){ Header = "View 2", MenuItemType = MenuItemType.SubItem, IsMRU = false },
                new MenuItem(){ Header = "View 3", MenuItemType = MenuItemType.SubItem, IsFavourite = false },
                new MenuItem(){ Header = "View 4", MenuItemType = MenuItemType.SubItem, IsFavourite = false },
                new MenuItem(){ Header = "View 5", MenuItemType = MenuItemType.SubItem, IsFavourite = false },
                new MenuItem(){ Header = "GridTest", MenuItemType = MenuItemType.SubItem, IsMRU = false },
                new MenuItem(){ Header = "TestData", MenuItemType = MenuItemType.SubItem, IsMRU = false },
                
                };
        }
       

    }
 
}
