using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls.SearchControl.Model
{
    public class MenuItem
    {
        public static MenuItem Create(string header, bool showInCollapsedMode = false, bool isCustomView = false, List<MenuItem> menuItems = null)
        {
            var factory = ViewModelSource.Factory<string, bool, bool, List<MenuItem>, MenuItem>((s, collapseMode, customView, children) => new MenuItem(s, collapseMode, customView, children));
            return factory(header, showInCollapsedMode, isCustomView, menuItems);
        }
        protected MenuItem(string header, bool showInCollapsedMode, bool isCustomView, List<MenuItem> menuItems)
        {
            Header = header;
            ShowInCollapsedMode = showInCollapsedMode;
            IsCustomView = isCustomView;
            MenuItems = menuItems;
            Index = counter;
            counter++;
        }
        static int counter;
        public string Header { get; private set; }
        public bool ShowInCollapsedMode { get; private set; }
        public virtual bool IsCustomView { get; set; }
        public List<MenuItem> MenuItems { get; private set; }
        public int Index { get; private set; }
    }
}
