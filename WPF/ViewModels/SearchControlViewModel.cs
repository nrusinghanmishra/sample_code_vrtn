using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell.ViewModels
{
    public class SearchControlViewModel
    {

        Random random;
        public SearchControlViewModel()
        {
            random = new Random();
            Items = CreateTestItems();
            SelectedItem = Items[0].Nodes[0];
        }
        public List<Node> Items { get; set; }
        public virtual Node SelectedItem { get; set; }

        public List<Node> CreateTestItems()
        {
            var result = new List<Node>();
            result.Add(Node.Create("Views", showInCollapsedMode: true, nodes: new List<Node>() {
                Node.Create("View 1"),
                Node.Create("View 2"),
                Node.Create("View 3")
            }));
            result.Add(Node.Create("History", isCustomView: true, nodes: new List<Node>() {
                Node.Create("View")
            }));
            result.Add(Node.Create("Favourites", nodes: new List<Node>() {
                Node.Create("View 1"),
                Node.Create("View 2", showInCollapsedMode:true, isCustomView: true)
            }));
            return result;
        }
        public virtual void UpdateCustomItems()
        {
            foreach (var flattenItem in Flatten(Items))
                flattenItem.IsCustomView = random.Next(0, 100) < 30;
        }
        IEnumerable<Node> Flatten(IEnumerable<Node> e)
        {
            return e == null ? Enumerable.Empty<Node>() : e.SelectMany(c => Flatten(c.Nodes)).Concat(e);
        }



    }


    public class Node
    {
        public static Node Create(string header, bool showInCollapsedMode = false, bool isCustomView = false, List<Node> nodes = null)
        {
            var factory = ViewModelSource.Factory<string, bool, bool, List<Node>, Node>((s, collapseMode, customView, children) => new Node(s, collapseMode, customView, children));
            return factory(header, showInCollapsedMode, isCustomView, nodes);
        }
        protected Node(string header, bool showInCollapsedMode, bool isCustomView, List<Node> nodes)
        {
            Header = header;
            ShowInCollapsedMode = showInCollapsedMode;
            IsCustomView = isCustomView;
            Nodes = nodes;
            Index = counter;
            counter++;
        }
        static int counter;
        public string Header { get; private set; }
        public bool ShowInCollapsedMode { get; private set; }
        public virtual bool IsCustomView { get; set; }
        public List<Node> Nodes { get; private set; }
        public int Index { get; private set; }
    }
}
