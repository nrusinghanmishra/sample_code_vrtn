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
        public DataTemplate MRURootTemplate { get; set; }
        public DataTemplate FAVSRootTemplate { get; set; }
        public DataTemplate ViewsRootTemplate { get; set; }
        public DataTemplate SubTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Model.MenuItem menuItem)
            {
                if(menuItem.MenuItemType == Model.MenuItemType.MRUHeader)
                    return MRURootTemplate;
                if (menuItem.MenuItemType == Model.MenuItemType.ViewHeader)
                    return ViewsRootTemplate;
                if (menuItem.MenuItemType == Model.MenuItemType.FAVHeader)
                    return FAVSRootTemplate;
                return SubTemplate;
            }            
            return base.SelectTemplate(item, container);
        }
    }
}
