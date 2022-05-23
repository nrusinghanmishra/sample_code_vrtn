using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shell
{
    internal class PanelHostController : DependencyObject
    {
        static private PanelHostController hostController = new PanelHostController();
        public static PanelHostController Instance
        {
            get
            {
                return hostController;
            }
        }

        public PanelHostController()
        {
            DocumentPanels = new ObservableCollection<IViewPresenter>();
        }
        public ObservableCollection<IViewPresenter>   DocumentPanels { get; set; }




        public object SelectedDocumentPanel
        {
            get { return (object)GetValue(SelectedDocumentPanelProperty); }
            set { SetValue(SelectedDocumentPanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDocumentPanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDocumentPanelProperty =
            DependencyProperty.Register("SelectedDocumentPanel", typeof(object), typeof(PanelHostController), new PropertyMetadata(null, OnSelecteDocumentPanelChanged));




        public int SelectedDocumentIndex
        {
            get { return (int)GetValue(SelectedDocumentIndexProperty); }
            set { SetValue(SelectedDocumentIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDocumentIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDocumentIndexProperty =
            DependencyProperty.Register("SelectedDocumentIndex", typeof(int), typeof(PanelHostController), new PropertyMetadata(0, OnSelectedDocumentIndexChanged));




        public Visibility Visibility
        {
            get { return (Visibility)GetValue(VisibilityProperty); }
            set { SetValue(VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityProperty =
            DependencyProperty.Register("Visibility", typeof(Visibility), typeof(PanelHostController), new PropertyMetadata(Visibility.Collapsed));
        static void OnSelectedDocumentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
        static void OnSelecteDocumentPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var presenter = e.NewValue as IViewPresenter;
            if(presenter != null)
            {
                presenter.IsActive = true;
                ActiveViewPresenter = presenter;
            }
        }


        private static void SetPanelToActive(DocumentPanel panel, PanelHostController controller)
        {
            var presenter = panel.Content as IViewPresenter;
            if(presenter != null)
            {
                presenter.IsActive = true;
                panel.IsActive = true;
                panel.Caption = presenter.Caption;
                ActiveViewPresenter = presenter;
            }
        }

        public void CloseOpenDucuments()
        {
            foreach(var open in DocumentPanels.ToArray())
            {
                open.CloseCommand.Execute(null);
            }
        }

        public static IViewPresenter ActiveViewPresenter
        {
            get; set;
        }
        public bool Contains(string caption)
        {
            if (DocumentPanels.Where(d => d.Caption.Trim() == caption.Trim()).Count() > 0)
                return true;
            else return false;
            
        }

        public void SelectedTab(string caption)
        {
            var vp = DocumentPanels.Where(d => d.Caption.Trim() == caption.Trim()).FirstOrDefault();
            if (vp != null)
                vp.IsActive = true;
        }

        public void AddPresenter(IViewPresenter presenter)
        {
            try
            {
                DocumentPanels.Add(presenter);
                presenter.ViewIndex = SelectedDocumentIndex;
                presenter.CloseRequest += Presenter_CloseRequest;
                Visibility = System.Windows.Visibility.Visible;
            }
            catch(Exception ex)
            {

            }
        }

        public void UpdateViewPresenterMenuItem(MenuItem curItem, MenuItem newItem)
        {
            var panels = DocumentPanels.Where(x => x.MenuInfo != null);

            var viewPresenter = panels.FirstOrDefault(x => x.IsActive && x.MenuInfo.Code == curItem.Code);

            if(viewPresenter != null)
            {
                viewPresenter.Caption = newItem.Name;
                viewPresenter.MenuInfo = newItem;
            }
        }

        public bool IsActive(string viewcode)
        {
            var panels = DocumentPanels.Where(x => x.MenuInfo != null);
            var vp =  panels.FirstOrDefault(x => x.MenuInfo.Code == viewcode);

            return vp != null ? vp.IsActive : false;
        }

        protected void Presenter_CloseRequest(object sender, EventArgs e)
        {
            try
            {
                var vp = sender as IViewPresenter;
                vp.CloseRequest -= Presenter_CloseRequest;
                //Dispise view code

            }catch(Exception ex)
            {

            }
        }

        private void AdjustPresenterViewIndex(int removedTabIndex)
        {
            foreach(var vp in DocumentPanels)
            {
                if (vp.ViewIndex > removedTabIndex)
                    vp.ViewIndex--;
            }
        }


    }
}
