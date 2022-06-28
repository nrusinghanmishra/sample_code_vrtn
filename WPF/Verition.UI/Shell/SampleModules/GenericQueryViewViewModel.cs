using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.SampleModules
{
    public  class GenericQueryViewViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime dateTime;

        public DateTime BusinessDate
        {
            get { return dateTime; }
            set { dateTime = value; Notify(nameof(BusinessDate)); }
        }

        private string filter1;

        public string Filter1
        {
            get { return filter1; }
            set { filter1 = value; Notify(nameof(Filter1)); }
        }

        private string filter2;

        public string FIlter2
        {
            get { return filter2; }
            set { filter2 = value; Notify(nameof(Filter2)); }
        }


        private string filter3;

        public string Filter3
        {
            get { return filter3; }
            set { filter3 = value; Notify(nameof(Filter3)); }

        }

        void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }



    }
}
