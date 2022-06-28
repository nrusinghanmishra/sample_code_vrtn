using Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.SampleModules
{
    public  class GenericGridViewViewModel : INotifyPropertyChanged
    {

        public GenericGridViewViewModel()
        {
            ItemsSource = SampleData.GenerateVehicleOrders(10000);
            QueryVM = new GenericQueryViewViewModel();

        }
       

        public event PropertyChangedEventHandler PropertyChanged;


        private GenericQueryViewViewModel queryVM;
        public GenericQueryViewViewModel QueryVM
        {
            get { return queryVM; }
            set { queryVM = value; }
        }


        private IList itemsSource;

        public IList ItemsSource
        {
            get { return itemsSource; }
            set { itemsSource = value; Notify(nameof(ItemsSource)); }
        }


        void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }




    }
}
