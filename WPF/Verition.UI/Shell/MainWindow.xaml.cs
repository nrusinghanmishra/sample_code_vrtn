using System;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.DemoCenterBase;

namespace Shell {
    public partial class MainWindow : ThemedWindow {
        static void ShowSplashScreen() {
           
        }
        public MainWindow() {
            Theme.CachePaletteThemes = true;
            Theme.RegisterPredefinedPaletteThemes();
            InitializeComponent();
        }

        private void SearchControl_ItemDoubleClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
  }
