using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shell
{
    internal class ViewLauncher
    {
        static object block = new object();
        private static PanelHostController controller;

        static ViewLauncher()
        {
            controller = PanelHostController.Instance;
        }

        public static IViewPresenter GetSpecialViewPresenter(string caption)
        {
            var presenter = controller.DocumentPanels.FirstOrDefault(p => string.Equals(p.Caption.Trim(), caption.Trim()));

            return presenter;
        }

        public static bool IsLoaded(string caption)
        {
            return controller.Contains(caption);
        }
        public static void SelectedTab(string caption)
        {
            controller.SelectedTab(caption);
        }

        static void Load(string name, bool closeButton, bool allowDrag, FrameworkElement view, MenuItem menuInfo)
        {
            if (view == null)
                throw new ApplicationException("View is empty");

            lock (block)
            {
                ViewPresenter vp = null;
                if(!closeButton & !allowDrag)
                {
                    vp = new ViewPresenter()
                    {
                        Caption = name,
                        ShowCloseButton = closeButton,
                        AllowContextMenu = false,
                        AllowClose = false,
                        AllowDrag = allowDrag,
                        MenuInfo = menuInfo

                    };
                }
                else
                {
                    vp = new ViewPresenter()
                    {
                        Caption = name,
                        ShowCloseButton = closeButton,              
                        AllowDrag = allowDrag,
                        MenuInfo = menuInfo

                    };

                }
                vp.Control = view;
                controller.AddPresenter(vp);
            }
        }
        static void Load(string name, bool showCloseButton, FrameworkElement view, MenuItem menuInfo)
        {
            Load(name, showCloseButton, true, view, menuInfo);
        }
        public static void Load(string name, FrameworkElement view, MenuItem menuInfo)
        {
            Load(name, true, view, menuInfo);
        }


    }
}
