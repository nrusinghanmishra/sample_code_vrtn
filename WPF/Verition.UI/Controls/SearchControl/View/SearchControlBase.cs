using System;
using System.Diagnostics;
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
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Popups;

namespace Controls.SearchControl.View
{
    public class SearchControlBase : PopupBaseEdit
    {
        private FrameworkElement _RootParent;
        private AccordionControl accordionSearch;
        private AccordionControl accordionSearchFav;
        private EditorPopupBase popup;
        public event EventHandler ItemDoubleClicked;

        public SearchControlBase()
        {
            this.AllowDefaultButton = false;
            this.PopupClosing += SearchControlBase_PopupClosing;
            this.PreviewMouseDown += SearchControlBase_PreviewMouseDown;
            this.PopupOpened += SearchControlBase_PopupOpened;
            
        }

        private void SearchControlBase_PopupOpened(object sender, RoutedEventArgs e)
        {
            var edit = (PopupBaseEdit)e.Source;
            var popup = PopupBaseEditHelper.GetPopup(edit);
        }

        private void SearchControlBase_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Inside SearchControlBase_PreviewMouseDown");
        }

        private void SearchControlBase_PopupClosing(object sender, ClosingPopupEventArgs e)
        {
            Debug.WriteLine("Inside SearchControlBase_PopupClosing");

            //if(_clickedInside)
            //{
            //    e.Cancel = true;    
            //    e.Handled = true;
            //    _clickedInside = false;
            //}
        }

        protected override void ClosePopupOnClick()
        {
            Debug.WriteLine("Inside ClosePopupOnClick");

            //base.ClosePopupOnClick();
        }
        bool _clickedInside = true;
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _clickedInside = true;
            if (!IsPopupOpen)
            {
               // _clickedInside = false;
                this.ShowPopup();
            }
            
            base.OnMouseLeftButtonDown(e);
            Debug.WriteLine("Inside OnPreviewMouseLeftButtonDown");
        }
        //void PopupBaseEdit_PopupOpened(object sender, RoutedEventArgs e)
        //{
        //    var edit = (PopupBaseEdit)e.Source;
        //    var popup = PopupBaseEditHelper.GetPopup(edit);
        //    var container = LayoutTreeHelper.GetLogicalChildren(popup).OfType<PopupContentContainer>().First();
        //    popup.Placement = PlacementMode.Relative;
        //    var diff = container.ActualWidth - edit.ActualWidth;
        //    if (diff > 0)
        //        popup.HorizontalOffset = -diff;
        //    popup.VerticalOffset = edit.ActualHeight;
        //}

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {           
            if (!IsPopupOpen)
                this.ShowPopup();
            base.OnPreviewKeyDown(e);
        }
        protected override void OnPopupOpened()
        {
            base.OnPopupOpened();
            _RootParent = this.GetRootParent();
            if (_RootParent != null)
                _RootParent.PreviewMouseDown += _RootParent_PreviewMouseDown;

            var accordionSearchTab = LayoutHelper.FindElementByName(((IPopupContentOwner)this).Child, "PART_SearchContentTab") as DXTabControl;
            if(accordionSearchTab != null && accordionSearchTab.Items.Count > 1)
            {
                var gridElements = ((accordionSearchTab.Items[0] as DXTabItem).Content as Grid).Children;
                
                if(gridElements.Count > 2)
                {
                    accordionSearch = gridElements[0] as AccordionControl;
                    if (accordionSearch != null)
                        accordionSearch.MouseDoubleClick += AccordionSearch_MouseDoubleClick;

                    accordionSearchFav = gridElements[2] as AccordionControl;
                    if (accordionSearchFav != null)
                        accordionSearchFav.MouseDoubleClick += AccordionSearch_MouseDoubleClick;
                }
                   
            }

            
            var popup = PopupBaseEditHelper.GetPopup(this);
            if(popup != null)
                popup.PreviewMouseDown += Popup_PreviewMouseDown;
            //Mouse.Capture(null);

        }

        private void Popup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Inside Popup_PreviewMouseDown");
            Point pt = e.GetPosition((UIElement)this);

            
            // Perform the hit test against a given portion of the visual object tree.
            HitTestResult result_editor = VisualTreeHelper.HitTest(this, pt);
            pt = e.GetPosition(((System.Windows.Controls.Primitives.Popup)sender).Child);
            HitTestResult result_popup = VisualTreeHelper.HitTest(((System.Windows.Controls.Primitives.Popup)sender).Child, pt);

            Debug.WriteLine("Inside Editor" + pt.ToString());

            if (result_editor != null  || result_popup != null)
            {
                Debug.WriteLine("Inside Editor");
                this.Focus();
                // Perform action on hit visual object.
            }
            else
            {
                this.IsPopupOpen = false;
            }

            //if (((DevExpress.Xpf.Editors.PopupBaseEdit)sender).get_Child() != null)
            //{
            //    Rect val = default(Rect);
            //    ((Rect)(ref val))._002Ector(0.0, 0.0, ((FrameworkElement)((Popup)this).get_Child()).get_ActualWidth(), ((FrameworkElement)((Popup)this).get_Child()).get_ActualHeight());
            //    if (!((Rect)(ref val)).Contains(GetMousePointerPosition((MouseEventArgs)(object)e, (IInputElement)(object)((Popup)this).get_Child())))
            //    {

            //    }
            //}
        }

        private void AccordionSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var itemClickedEventArg = new ItemDoubleClickedEventArg(((AccordionControl)sender).SelectedItem);
             ItemDoubleClicked?.Invoke(this, itemClickedEventArg);            
        }

        
        
       
        protected override void OnPopupClosed()
        {
            base.OnPopupClosed();
            if (_RootParent != null)
                _RootParent.PreviewMouseDown -= _RootParent_PreviewMouseDown;

            //accordionSearch = LayoutHelper.FindElementByName(((IPopupContentOwner)this).Child, "PART_SearchContent") as AccordionControl;
            if (accordionSearch != null)
                accordionSearch.MouseDoubleClick -= AccordionSearch_MouseDoubleClick;

            //accordionSearchFav = LayoutHelper.FindElementByName(((IPopupContentOwner)this).Child, "PART_SearchContent") as AccordionControl;
            if (accordionSearchFav != null)
                accordionSearchFav.MouseDoubleClick -= AccordionSearch_MouseDoubleClick;

            if(popup != null)
                popup.PreviewMouseDown -= Popup_PreviewMouseDown;
        }

        public void Search(string searchText)
        {
            if(accordionSearch != null)
                accordionSearch.SearchText = searchText;
            if (accordionSearchFav != null)
                accordionSearchFav.SearchText = searchText;
        }


        private void _RootParent_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Inside _RootParent_PreviewMouseDown");
            if (!LayoutTreeHelper.GetVisualParents((DependencyObject)e.OriginalSource).Contains(this))
                this.ClosePopup();
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
