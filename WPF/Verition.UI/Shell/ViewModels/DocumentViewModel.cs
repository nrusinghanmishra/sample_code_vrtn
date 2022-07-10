using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.About;
using DevExpress.Xpf;
using DevExpress.Xpf.Accordion;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Bars.Native;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.DemoBase.Helpers;
using DevExpress.Xpf.DemoBase.Helpers.TextColorizer;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.PropertyGrid;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Shell.ViewModels
{
    public class DocumentViewModel : PanelWorkspaceViewModel
    {
        public DocumentViewModel()
        {
            IsClosed = false;
        }
        public DocumentViewModel(string displayName, string text) : this()
        {
            DisplayName = displayName;
            
        }

        public FrameworkElement Control { get; set; }
       
        public string Description { get; protected set; }
        public string FilePath { get; protected set; }
        public string Footer { get; protected set; }
        protected override string WorkspaceName { get { return "DocumentHost"; } }

        public override void OpenItemByPath(Controls.SearchControl.Model.MenuItem menuItem)
        {
            DisplayName = menuItem.Header;
            FilePath = menuItem.Header;
            if (path == "GridTest")
                Control = new Modules.GridViewTest();
            else if (path == "TestData")
                Control = new Shell.SampleModules.TestUserControl();
            else if (path == "PositionGridTest")
                Control = new Shell.SampleModules.GenericGridView();
            else
                Control = new Shell.SampleModules.TestUserControl();
            IsActive = true;
        }

        public override void OpenItemByPath(string path)
        {
            DisplayName = Path.GetFileName(path);
            FilePath = path;
            if (path == "GridTest")
                Control = new Modules.GridViewTest();
            else if (path == "TestData")
                Control = new Shell.SampleModules.TestUserControl();
            else if (path == "PositionGridTest")
                Control = new Shell.SampleModules.GenericGridView();
            else
                Control = new Shell.SampleModules.TestUserControl();
            IsActive = true;
        }

    }
}
