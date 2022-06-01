using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Controls.SearchControl.Helper
{
    public class SearchControlItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RootTemplate { get; set; }
        public DataTemplate MRUHeaderTemplate { get; set; }
        public DataTemplate FAVSHeaderTemplate { get; set; }
        public DataTemplate ViewsHeaderTemplate { get; set; }
        public DataTemplate FAVSRootHeaderTemplate { get; set; }
        public DataTemplate ViewsRootHeaderTemplate { get; set; }
        public DataTemplate SubTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Model.MenuItem menuItem)
            {
                if(menuItem.MenuItemType == Model.MenuItemType.MRUHeader)
                    return MRUHeaderTemplate;
                if (menuItem.MenuItemType == Model.MenuItemType.ViewHeader)
                    return ViewsHeaderTemplate;
                if (menuItem.MenuItemType == Model.MenuItemType.FAVHeader)
                    return FAVSHeaderTemplate;
                return SubTemplate;
            }            
            return base.SelectTemplate(item, container);
        }
    }
}
