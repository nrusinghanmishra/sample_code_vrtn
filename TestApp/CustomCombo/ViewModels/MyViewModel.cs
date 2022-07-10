using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ComboBoxEdit_CreatingCheckedComboBox.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Customer> selectedCustomers;
        public MyViewModel() {
            Customers = Customer.GetList();
            SelectedCustomers = new ObservableCollection<Customer>() { Customers[1], Customers[2] };
        }

        
        private List<Customer> _customers;

        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; RaisePropertyChanged(nameof(Customers)); }
        }

        public ObservableCollection<Customer> SelectedCustomers {
            get { return selectedCustomers; }
            set {
                if (selectedCustomers == value) {
                    return;
                }
                if (selectedCustomers != null)
                {
                    foreach (var customer in selectedCustomers)
                    {
                        customer.IsChecked = false;
                    }
                }

               
                selectedCustomers = value;
                foreach (var customer in selectedCustomers)
                {
                    customer.IsChecked = true;
                }
                //ReOrderItemSource();
                RaisePropertyChanged("SelectedCustomers");
            }
        }

        public void ReOrderItemSource()
        {
            
            Customers = Customers.OrderByDescending(x => x.IsChecked).ToList();

            
            

        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
