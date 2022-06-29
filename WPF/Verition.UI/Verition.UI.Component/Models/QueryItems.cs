using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verition.UI.Component.Models
{
    public class QueryItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
    }

    public class QueryTextItem : QueryItem
    {
        public string Text { get; set; }
    }

    public class QueryDateItem : QueryItem
    {
        public DateTime SelectedItem { get; set; }
    }

    public class QueryComboItem : QueryItem
    {
        public LookupItem SelectedItem { get; set; }
        public List<LookupItem> Lookups { get; set; }
    }

    public class QueryMultiSelectComboItem : QueryItem
    {
        public IEnumerable<string> SelectedItems { get; set; }
        public List<LookupItem> Lookups { get; set; }
    }



    public class LookupItem
    {
       public string Name { get; set; }
       public int Id { get; set; }
       public string Description { get; set; }
    }

    public enum ItemType
    {
        Date,
        Combo,
        Text
    }

}
