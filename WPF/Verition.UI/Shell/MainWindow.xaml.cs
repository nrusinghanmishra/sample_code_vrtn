using System;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.DemoCenterBase;

namespace Shell {
    public partial class MainWindow : ThemedWindow {
        static void ShowSplashScreen() {
           
        }
        public MainWindow() {
            ApplicationThemeHelper.ApplicationThemeName = Theme.VS2019Dark.Name;
            Theme.CachePaletteThemes = true;
            DemoRunner.SubscribeThemeChanging();
            Theme.RegisterPredefinedPaletteThemes();
            InitializeComponent();
        }

        private void SearchControl_ItemDoubleClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
  }
