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
            Items = CreateTestItems();
            FavItems = CreateTestFavItems();
            //SelectedItem = Items[0].MenuItems[0];
        }
        public List<MenuItem> Items { get; set; }
        public List<MenuItem> FavItems { get; set; }


        private MenuItem selectedItem;

        public MenuItem SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        //public virtual MenuItem SelectedItem { get; set; }

        public List<MenuItem> CreateTestItems()
        {
            var result = new List<MenuItem>();
            result.Add(MenuItem.Create("Views", MenuItemType.ViewHeader,  showInCollapsedMode: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View", MenuItemType.SubItem),
                MenuItem.Create("View 1", MenuItemType.SubItem),
                MenuItem.Create("View 2", MenuItemType.SubItem),
                MenuItem.Create("View 3", MenuItemType.SubItem),
                MenuItem.Create("GridTest", MenuItemType.SubItem),
                MenuItem.Create("TestData", MenuItemType.SubItem)
            }));
            result.Add(MenuItem.Create("History",MenuItemType.MRUHeader, isCustomView: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View", MenuItemType.SubItem)
            }));
            
            return result;
        }

        public List<MenuItem> CreateTestFavItems()
        {
            var result = new List<MenuItem>();
            result.Add(MenuItem.Create("Favourites", MenuItemType.FAVHeader, showInCollapsedMode: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View 1", MenuItemType.SubItem),
                MenuItem.Create("View 2", MenuItemType.SubItem)
            }));
            return result;
        }
       

    }
 
}
