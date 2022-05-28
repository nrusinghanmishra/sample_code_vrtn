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
            CodeLanguageText = new CodeLanguageText(CodeLanguage.CS, text);
        }

        public CodeLanguage ModelCodeLanguage { get; private set; }
        public CodeLanguageText CodeLanguageText { get; private set; }
        public string Description { get; protected set; }
        public string FilePath { get; protected set; }
        public string Footer { get; protected set; }

        public FrameworkElement Control { get; set; }
        protected override string WorkspaceName { get { return "DocumentHost"; } }

        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Visual C# Files (*.cs)|*.cs|XAML Files (*.xaml)|*.xaml";
            openFileDialog.FilterIndex = 1;
            bool? dialogResult = openFileDialog.ShowDialog();
            bool dialogResultOK = dialogResult.HasValue && dialogResult.Value;
            if (dialogResultOK)
            {
                DisplayName = openFileDialog.SafeFileName;
                FilePath = openFileDialog.FileName;
                //SetCodeLanguageProperties(Path.GetExtension(openFileDialog.SafeFileName));
                Stream fileStream = File.OpenRead(openFileDialog.FileName);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    CodeLanguageText = new CodeLanguageText(ModelCodeLanguage, reader.ReadToEnd());
                }
                fileStream.Close();
            }
            return dialogResultOK;
        }
        public override void OpenItemByPath(string path)
        {
            DisplayName = Path.GetFileName(path);
            Control = new UserControl();
            IsActive = true;
        }
        //string GenerateClassText(string className)
        //{
        //    string text = @"
        //using System;
        //using System.Collections.Generic;
        //using System.Linq;
        //using System.Text;

        //namespace Shell {{
        //    class {0} {{
        //    }}
        //}}";
        //    return string.Format(text, className);
        //}
        //CodeLanguage GetCodeLanguage(string fileExtension)
        //{
        //    switch (fileExtension)
        //    {
        //        case ".cs": return CodeLanguage.CS;
        //        case ".vb": return CodeLanguage.VB;
        //        case ".xaml": return CodeLanguage.XAML;
        //        default: return CodeLanguage.Plain;
        //    }
        //}
        //string GetCodeTextByPath(string path)
        //{
        //    Assembly assembly = typeof(DocumentViewModel).Assembly;
        //    using (Stream stream = AssemblyHelper.GetResourceStream(assembly, path, true))
        //    {
        //        if (stream == null)
        //            return GenerateClassText(Path.GetFileNameWithoutExtension(path));
        //        using (StreamReader reader = new StreamReader(stream))
        //            return reader.ReadToEnd();
        //    }
        //}
        //string GetDescription(CodeLanguage codeLanguage)
        //{
        //    switch (codeLanguage)
        //    {
        //        case CodeLanguage.CS: return "Visual C# Source file";
        //        case CodeLanguage.VB: return "Visual Basic Source file";
        //        case CodeLanguage.XAML: return "Windows Markup File";
        //        default: return "Other file";
        //    }
        //}
        //void SetCodeLanguageProperties(string fileExtension)
        //{
        //    ModelCodeLanguage = GetCodeLanguage(fileExtension);
        //    Description = GetDescription(ModelCodeLanguage);
        //    Footer = DisplayName;
        //    Glyph = ModelCodeLanguage.Equals(CodeLanguage.XAML) ? Images.FileXaml : ModelCodeLanguage.Equals(CodeLanguage.CS) ? Images.FileCS : null;
        //}
    }
}
