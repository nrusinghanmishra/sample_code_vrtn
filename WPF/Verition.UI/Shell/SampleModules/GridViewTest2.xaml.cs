using Modules;
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

namespace Shell.SampleModules
{
    /// <summary>
    /// Interaction logic for GridViewTest2.xaml
    /// </summary>
    public partial class GridViewTest2 : UserControl
    {
        public GridViewTest2()
        {
            InitializeComponent();
            grid.ItemsSource = SampleData.GenerateVehicleOrders(10000);
        }
    }
}
