using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Verition.UI.Component.Models;

namespace Verition.UI.Component.Helper
{
    public class QueryItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate DateTemplate { get; set; }
        public DataTemplate ComboTemplate { get; set; }



        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is QueryTextItem)
                return TextTemplate;
            if (item is QueryDateItem)
                return DateTemplate;           
            if (item is QueryComboItem)
                return ComboTemplate;

            return TextTemplate;

        }

       

    }
}
