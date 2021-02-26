using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using TestWindow.Views;

namespace DockingLibraryDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // add windows
        private MyWindow myTestWindow;


        internal static RecentFiles files;

        public MainWindow()
        {
            myTestWindow = new MyWindow();
            files = new RecentFiles();

            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;

            InitializeComponent();
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            dockManager.ParentWindow = this;

            // can be made xml layout config file to be saved states
            //if (!string.IsNullOrEmpty(Properties.Settings.Default.DockingLayoutState))
            //    dockManager.RestoreLayoutFromXml(Properties.Settings.Default.DockingLayoutState,
            //        new DockingLibrary.GetContentFromTypeString(this.GetContentFromTypeString));
            //else
            {
                //add the windows (plug-in's)

                //
                myTestWindow.DockManager = dockManager;
                myTestWindow.Show(Dock.Left);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            //Properties.Settings.Default.DockingLayoutState = dockManager.GetLayoutAsXml();
            Properties.Settings.Default.Save();
        }


        private void ExitApplication(object sender, EventArgs e)
          =>  Application.Current.Shutdown();



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (myTestWindow != null)
            {
                myTestWindow.Close();
                myTestWindow = new MyWindow();
                myTestWindow.DockManager = dockManager;
                myTestWindow.Show(Dock.Left);
            }
        }
    }
}