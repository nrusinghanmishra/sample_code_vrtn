using ComboBoxEdit_CreatingCheckedComboBox.ViewModels;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Editors;
using System.Windows;

namespace ComboBoxEdit_CreatingCheckedComboBox {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            comboEdit.PopupOpened += ComboEdit_PopupOpened;
            comboEdit.PopupClosed += ComboEdit_PopupClosed;
            comboEdit.PopupOpening += ComboEdit_PopupOpening;
        }

        private void ComboEdit_PopupOpening(object sender, OpenPopupEventArgs e)
        {
            var vm = this.DataContext as MyViewModel;
            vm.ReOrderItemSource();
        }

        private void ComboEdit_PopupClosed(object sender, ClosePopupEventArgs e)
        {
            isOPened = false;
            //throw new System.NotImplementedException();
        }

        bool isOPened = false;
        private void ComboEdit_PopupOpened(object sender, RoutedEventArgs e)
        {
            isOPened = true;
            //throw new System.NotImplementedException();
        }

        private void checkEdit_Checked(object sender, RoutedEventArgs e)
        {
            if(isOPened)
            {

            }
        }

        private void checkEdit_Checked_1(object sender, RoutedEventArgs e)
        {
            if (isOPened)
            {

            }

        }
    }

    public class CustomComboboxEdit : ComboBoxEdit
    {
        public CustomComboboxEdit()
        {
            this.PopupOpening += CustomComboboxEdit_PopupOpening;
            this.PopupOpened += CustomComboboxEdit_PopupOpened;
        }

        private void CustomComboboxEdit_PopupOpened(object sender, RoutedEventArgs e)
        {
            //var checkEdit = LayoutHelper.FindElementByName(this.PopupRoot, "checkEdit") as CheckEdit;
            //
            //throw new System.NotImplementedException();
            // checkEdit.Checked += CheckEdit_Checked;

            var checkEdit = LayoutHelper.FindElement(((IPopupContentOwner)sender).Child, el=>el is CheckEdit) as CheckEdit;
            //checkEdit.Checked += CheckEdit_Checked;
        }

        private void CheckEdit_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void CustomComboboxEdit_PopupOpening(object sender, OpenPopupEventArgs e)
        {
            
            
        }
    }
}
