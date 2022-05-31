using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Controls.SearchControl
{
    public class SearchControlTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeadNaviItemTemplate { get; set; }
        public DataTemplate ChildNaviItemTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var selectedTemplate = ChildNaviItemTemplate;
            var lookupItem = item as SearchControl.ViewModel.SearchControlViewModel;
            //var displayMember = lookupItem.DisplayMember;

            //// TODO: Changed to select based on level in Hierarchy
            //if (displayMember == "Projects" || displayMember == "Systems" || displayMember == "Drawings" || displayMember == "Lists")
            //{
            //    selectedTemplate = HeadNaviItemTemplate;
            //    return selectedTemplate;
            //}

            return selectedTemplate;
        }
    }
}
