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
        public DataTemplate SubTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Model.MenuItem) return RootTemplate;
            if (item is Model.MenuItem) return SubTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
