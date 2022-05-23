using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shell
{
    internal interface IViewPresenter
    {
        bool AllowDrag { get; set; }
        string  Caption { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequest;
        System.Windows.FrameworkElement Control { get; set; }
        bool IsActive { get; set; }
        bool ShowCloseButton { get; set; }
        int ViewIndex { get; set; }
        MenuItem MenuInfo { get; set; }
        bool IsClosing { get; set; }
    }
}
