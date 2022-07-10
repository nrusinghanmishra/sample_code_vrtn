using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Verition.UI.Component.ViewModels;

namespace Verition.UI.Component.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        ReportViewModel reportVM;
        public ReportView()
        {
            InitializeComponent();
            reportVM = new ReportViewModel();
            this.DataContext = reportVM;
        }

        private void dockLayoutManager_DockItemClosing(object sender, DevExpress.Xpf.Docking.Base.ItemCancelEventArgs e)
        {

        }
    }
}
