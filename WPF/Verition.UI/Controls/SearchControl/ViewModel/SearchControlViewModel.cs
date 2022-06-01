using Controls.SearchControl.Model;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls.SearchControl.ViewModel
{
    public class SearchControlViewModel
    {
       public SearchControlViewModel()
        {
            PopulateMenuItems();
            SelectedRootItem = Items[0];
        }
        public List<MenuItem> Items { get; set; }
        public List<MenuItem> FavItems { get; set; }


        private MenuItem selectedItem;

        public MenuItem SelectedRootItem { get; set; }
        public virtual MenuItem SelectedItem { get; set; }

        void PopulateMenuItems()
        {
            Items = new List<MenuItem>()
            {
                CreateTestViewsItems(),
                CreateTestFavItems(),
            };

        }
        public MenuItem CreateTestViewsItems()
        {
            var menuItemViews =  MenuItem.Create("Views", MenuItemType.RootViewHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>());
            var menuItemAllViews = MenuItem.Create("", MenuItemType.ViewHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>());
            var menuItemMRUViews =  MenuItem.Create("Views", MenuItemType.MRUHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>());

            menuItemViews.MenuItems.Add(menuItemAllViews);
            menuItemViews.MenuItems.Add(menuItemMRUViews);

            menuItemAllViews.MenuItems.AddRange(
                new List<MenuItem>() {
                 MenuItem.Create("View", MenuItemType.SubItem),
                MenuItem.Create("View 1", MenuItemType.SubItem),
                MenuItem.Create("View 2", MenuItemType.SubItem),
                MenuItem.Create("View 3", MenuItemType.SubItem),
                MenuItem.Create("GridTest", MenuItemType.SubItem),
                MenuItem.Create("TestData", MenuItemType.SubItem)
                });


            menuItemMRUViews.MenuItems.AddRange(
                new List<MenuItem>() {
                 MenuItem.Create("View", MenuItemType.SubItem),
                MenuItem.Create("View 1", MenuItemType.SubItem),
                
                });

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

        public MenuItem CreateTestFavItems()
        {
            return MenuItem.Create("Favourites", MenuItemType.RootFavHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View 1", MenuItemType.SubItem),
                MenuItem.Create("View 2", MenuItemType.SubItem)
            });
        }
       

    }
 
}
