using Controls.SearchControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls.SearchControl.View
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        SearchControlViewModel searchControlViewModel;
        public event RoutedEventHandler ItemDoubleClicked
        {
            add { AddHandler(ItemDoubleClickedEvent, value); }
            remove { RemoveHandler(ItemDoubleClickedEvent, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly RoutedEvent ItemDoubleClickedEvent =
            EventManager.RegisterRoutedEvent("ItemDoubleClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchControl));

        public SearchControl()
        {            
            InitializeComponent();
            initDataContext();
            ViewSearchPanel.ItemDoubleClicked += ViewSearchPanel_ItemDoubleClicked;
        }

        private void ViewSearchPanel_ItemDoubleClicked(object sender, EventArgs e)
        {
            searchControlViewModel.OnItemDoubleClicked(((ItemDoubleClickedEventArg)e).Data as Controls.SearchControl.Model.MenuItem);
            RaiseEvent(new ItemDoubleClickedRoutedEventArg(ItemDoubleClickedEvent, ((ItemDoubleClickedEventArg)e).Data));
        }

        private void initDataContext()
        {
            searchControlViewModel = new SearchControlViewModel();
            this.DataContext = searchControlViewModel;
        }

        private void SearchControlBase_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            ViewSearchPanel.Search(Convert.ToString(e.NewValue));
        }
    }

    public class ItemDoubleClickedRoutedEventArg : RoutedEventArgs
    {
        // Property variable
        private readonly object p_EventData;

        // Constructor
        public ItemDoubleClickedRoutedEventArg(RoutedEvent routedEvent,  object data)
        {
            p_EventData = data;
            this.RoutedEvent = routedEvent;

        }

        // Property for EventArgs argument
        public object Data
        {
            get { return p_EventData; }
        }
    }


}
