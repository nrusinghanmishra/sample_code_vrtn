using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verition.UI.Component.Models;

namespace Verition.UI.Component.ViewModels
{
    public class ReportViewModel
    {
        public ReportViewModel()
        {
            InitQueryItems();
            InitGridData();
        }
        public IEnumerable<QueryItem> QueryItems { get; set; }
        public VWGridViewModel GridVM { get; set; }
        private void InitQueryItems()
        {
            var queryItems = new List<QueryItem>();
            var textQueryItem = new QueryTextItem() { Name = "Test", ItemType = ItemType.Text };
            var textQueryItem1 = new QueryTextItem() { Name = "Test1", ItemType = ItemType.Text };
            queryItems.Add(textQueryItem);
            queryItems.Add(textQueryItem1);

            var comboQueryItem = new QueryComboItem() { Name = "TestCombo1", ItemType = ItemType.Combo };
            comboQueryItem.Lookups = new List<LookupItem>()
            {
                new LookupItem(){Id = 0, Name= "Ttest", Description="tewasgfsagas"},
                new LookupItem(){Id = 1, Name= "Ttestfsagd", Description="tewasgfsagas  fagsadgasd"}
            };
            queryItems.Add(comboQueryItem);
            var dateQueryItem = new QueryDateItem() { Name = "TestDate", ItemType = ItemType.Date };
            queryItems.Add(dateQueryItem);
            QueryItems = queryItems;

        }

        private void InitGridData()
        {
            
            var gridVM = new VWGridViewModel();
            gridVM.ItemsSource = Verition.UI.Common.SampleData.GenerateVehicleOrders(10000);
            this.GridVM = gridVM;


        }
    }
}
