using DevExpress.XtraRichEdit.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Shell
{
    public class ViewPresenter : DependencyObject, IViewPresenter //, IMVVMDockingProperties
    {

        public ViewPresenter()
        {

            TargetName = "DocumentHost";
            IsActive = true;
        }

        public ViewPresenter(string documentGrpName)
        {
            TargetName = documentGrpName;
        }


        public static readonly DependencyProperty AllowContextMenuProperty =
              DependencyProperty.Register("AllowContextMenu", typeof(bool), typeof(ViewPresenter), new UIPropertyMetadata(true));

        public static readonly DependencyProperty AllowCloseProperty =
              DependencyProperty.Register("AllowClose", typeof(bool), typeof(ViewPresenter), new UIPropertyMetadata(true));


        public bool AllowDrag
        {
            get { return (bool)GetValue(AllowDragProperty); }
            set { SetValue(AllowDragProperty, value); }
        }

        public bool AllowContextMenu
        {
            get { return (bool)GetValue(AllowContextMenuProperty); }
            set { SetValue(AllowContextMenuProperty, value); }
        }

        #region IViewPresenter

        public event EventHandler CloseRequest;
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(ViewPresenter), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ControlProperty =
            DependencyProperty.Register("Control", typeof(FrameworkElement), typeof(ViewPresenter), new UIPropertyMetadata(null));


        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(ViewPresenter), new UIPropertyMetadata(false, OnIsActivePropertyChanged));

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(ViewPresenter), new UIPropertyMetadata(true));


        public static readonly DependencyProperty InitialIndexProperty = DependencyProperty.Register("ViewIndex", typeof(int), typeof(ViewPresenter));

        public static readonly DependencyProperty AllowDragProperty =
            DependencyProperty.Register("AllowDrag", typeof(bool), typeof(ViewPresenter), new UIPropertyMetadata(true));

        public bool AllowClose
        {
            get { return (bool)GetValue(AllowCloseProperty); }
            set { SetValue(AllowCloseProperty, value); }
        }

        public int ViewIndex
        {
            get { return (int)GetValue(InitialIndexProperty); }
            set { SetValue(InitialIndexProperty, value); }
        }


        public bool ShowCloseButton
        {
            get { return (bool)GetValue(ShowCloseButtonProperty); }
            set { SetValue(ShowCloseButtonProperty, value); }
        }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public FrameworkElement Control
        {
            get { return (FrameworkElement)GetValue(ControlProperty); }
            set { SetValue(ControlProperty, value); }
        }


        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        /// <summary>
        /// This is to store View Metadata
        /// </summary>
        public MenuItem MenuInfo { get; set; }

        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new DelegateCommand(ExecuteViewCloseCommand);

                return closeCommand;
            }
        }

        #endregion 

        private static void OnIsActivePropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue != e.OldValue)
                {
                    IViewPresenter presenter = target as IViewPresenter;
                    if (presenter.Control != null)
                    {
                        var av = presenter.Control.DataContext as IActiveView;
                        if (av != null)
                        {
                            av.IsActive = (bool)e.NewValue;
                        }

                        if (presenter.IsActive)
                        {
                            IWorkspaceModel wsm = presenter.Control.DataContext as IWorkspaceModel;
                            if (wsm != null)
                            {
                                IViewModel bm = presenter.Control.DataContext as IViewModel;
                                if (bm != null)
                                {
                                    wsm.StatusBar.StatusMessageCenter = string.Empty;
                                    wsm.StatusBar.StatusMessageLeft = bm.Title;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual void ExecuteViewCloseCommand()
        {
            if (!ShowCloseButton) return;
            WorkspaceCloseEventArg arg = new WorkspaceCloseEventArg();
            IViewCloseCommand closeRequest = Control.DataContext as IViewCloseCommand;
            if (closeRequest != null) { closeRequest.CloseCommand.Execute(arg); }
            if (!arg.Cancel) { RequestForClose(); }
            arg = null;
        }

        protected virtual void RequestForClose()
        {
            EventHandler handle = CloseRequest;
            if (handle != null)
                handle(this, new EventArgs());
        }


        public bool IsClosing
        {
            get;
            set;
        }

        public string TargetName
        {
            get;
            set;
        }

    }
}
