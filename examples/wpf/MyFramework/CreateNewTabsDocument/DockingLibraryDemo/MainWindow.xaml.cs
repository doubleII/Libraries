using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace DockingLibraryDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : System.Windows.Window
    {
        internal static RecentFiles files = new RecentFiles();

        public MainWindow()
        {
            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;

            InitializeComponent();
        }



        private void OnLoaded(object sender, EventArgs e)
        {
            dockManager.ParentWindow = this;
        }

        private void OnClosing(object sender, EventArgs e)
        {
            Properties.Settings.Default.DockingLayoutState = dockManager.GetLayoutAsXml();
            Properties.Settings.Default.Save();
        }

        bool ContainsDocument(string title)
        {
            foreach (DockingLibrary.DocumentContent doc in dockManager.Documents)
                if (string.Compare(doc.Title, title, true) == 0)
                    return true;
            return false;
        }

        private void NewDocument(object sender, EventArgs e)
        {
            string title = "Document";
            int i = 1;
            while (ContainsDocument(title + i.ToString()))
                i++;

            DocWindow doc = new DocWindow();
            doc.DockManager = dockManager;
            doc.Title = title + i.ToString();
            doc.Show();

            files.Add(new RecentFile(doc.Title, "PATH" + doc.Title, doc.Title.Length*i));
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = "Document";
            int i = 1;
            while (ContainsDocument(title + i.ToString()))
                i++;

            DocWindow doc = new DocWindow();
            doc.DockManager = dockManager;
            doc.Title = title + i.ToString();
            doc.Show();

            files.Add(new RecentFile(doc.Title, "PATH" + doc.Title, doc.Title.Length * i));
        }

    }
}