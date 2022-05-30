using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Accordion;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Editors;

namespace Shell
{
    
    public class SearchControlBase : PopupBaseEdit
    {
        private FrameworkElement _RootParent;
        private AccordionControl accordionSearch;

        public event EventHandler ItemDoubleClicked;

        public SearchControlBase()
        {
            var button = new ButtonInfo() { GlyphKind = GlyphKind.DropDown };
            button.Click += Button_Click;
            this.AllowDefaultButton = false;
            this.Buttons.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPopupOpen)
                this.ShowPopup();
            else ClosePopup();
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //if (!IsPopupOpen && LayoutTreeHelper.GetVisualParents((DependencyObject)e.OriginalSource).OfType<Button>().FirstOrDefault() == null)
            //    this.ShowPopup();

            if (!IsPopupOpen)
                this.ShowPopup();
        }

        protected override void OnPopupOpened()
        {
            base.OnPopupOpened();
            _RootParent = this.GetRootParent();
            if (_RootParent != null)
                _RootParent.PreviewMouseDown += _RootParent_PreviewMouseDown;

            accordionSearch = LayoutHelper.FindElementByName(((IPopupContentOwner)this).Child, "PART_SearchContent") as AccordionControl;
            if(accordionSearch != null)
                accordionSearch.MouseDoubleClick += AccordionSearch_MouseDoubleClick;
        }

        private void AccordionSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var itemClickedEventArg = new Shell.ItemDoubleClickedEventArg(((AccordionControl)sender).SelectedItem);
             ItemDoubleClicked?.Invoke(this, itemClickedEventArg);            
        }

        private void _RootParent_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!LayoutTreeHelper.GetVisualParents((DependencyObject)e.OriginalSource).Contains(this))
                this.ClosePopup();
            //IsPopupOpen = true;
        }

       
        protected override void OnPopupClosed()
        {
            base.OnPopupClosed();
            if (_RootParent != null)
                _RootParent.PreviewMouseDown -= _RootParent_PreviewMouseDown;

            accordionSearch = LayoutHelper.FindElementByName(((IPopupContentOwner)this).Child, "PART_SearchContent") as AccordionControl;
            if (accordionSearch != null)
                accordionSearch.MouseDoubleClick -= AccordionSearch_MouseDoubleClick;
        }

        public void Search(string searchText)
        {
            if (!IsPopupOpen)
                this.ShowPopup();
            accordionSearch.SearchText = searchText;
        }

 
    }

    public class ItemDoubleClickedEventArg : EventArgs
    {
        // Property variable
        private readonly object p_EventData;

        // Constructor
        public ItemDoubleClickedEventArg(object data)
        {
            p_EventData = data;
        }

        // Property for EventArgs argument
        public object Data
        {
            get { return p_EventData; }
        }
    }

    public class PopupBaseEditStyleSettingsEx : PopupBaseEditStyleSettings
    {
        public override bool ShouldCaptureMouseOnPopup { get { return false; } }
    }
}
