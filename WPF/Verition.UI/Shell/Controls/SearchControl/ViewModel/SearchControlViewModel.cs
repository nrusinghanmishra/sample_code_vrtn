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

        Random random;
        public SearchControlViewModel()
        {
            random = new Random();
            Items = CreateTestItems();
            SelectedItem = Items[0].MenuItems[0];
        }
        public List<MenuItem> Items { get; set; }
        public virtual MenuItem SelectedItem { get; set; }

        public List<MenuItem> CreateTestItems()
        {
            var result = new List<MenuItem>();
            result.Add(MenuItem.Create("Views", showInCollapsedMode: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View 1"),
                MenuItem.Create("View 2"),
                MenuItem.Create("View 3")
            }));
            result.Add(MenuItem.Create("History", isCustomView: true, menuItems: new List<MenuItem>() {
                MenuItem.Create("View")
            }));
            result.Add(MenuItem.Create("Favourites", menuItems: new List<MenuItem>() {
                MenuItem.Create("View 1"),
                MenuItem.Create("View 2", showInCollapsedMode:true, isCustomView: true)
            }));
            return result;
        }
        public virtual void UpdateCustomItems()
        {
            foreach (var flattenItem in Flatten(Items))
                flattenItem.IsCustomView = random.Next(0, 100) < 30;
        }
        IEnumerable<MenuItem> Flatten(IEnumerable<MenuItem> e)
        {
            return e == null ? Enumerable.Empty<MenuItem>() : e.SelectMany(c => Flatten(c.MenuItems)).Concat(e);
        }



    }


 
}
