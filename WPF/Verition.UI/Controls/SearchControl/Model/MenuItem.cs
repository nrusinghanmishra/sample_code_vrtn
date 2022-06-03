using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Controls.SearchControl.Model
{
    public class MenuItem : INotifyPropertyChanged
    {

        public MenuItem()
        {

        }
        public MenuItem(string header, MenuItemType menuItemType, bool showInCollapsedMode,  List<MenuItem> menuItems)
        {
            Header = header;
            ShowInCollapsedMode = showInCollapsedMode;
            MenuItems = menuItems;
            Index = counter;
            counter++;
            MenuItemType = menuItemType;
        }
        static int counter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Header { get; set; }
        public bool ShowInCollapsedMode { get; set; }
        public virtual bool IsCustomView { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public int Index { get; set; }

        public MenuItemType MenuItemType { get; set; }
        //public bool IsFavourite { get; set; }

        private bool isFavourite;

        public bool IsFavourite
        {
            get { return isFavourite; }
            set { isFavourite = value;  Notify(nameof(IsFavourite)); }
        }


        private bool isMRU;

        public bool IsMRU
        {
            get { return isMRU; }
            set { 
                isMRU = value;  
                Notify(nameof(IsMRU));
            }
        }
        void Notify(string name)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public override string ToString()
        {
            return Header;
        }
    }

    public enum MenuItemType
    {
        ViewHeader = 0,
        FAVHeader,
        RootViewHeader,
        RootFavHeader,
        MRUHeader,
        SubItem,
        Seperator
    }
}
