using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GlobalExceptionHandling
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                MainWindow mw = new MainWindow();
                // if you want to use only one instance
                // sgi = new SingleGlobalInstance(0);
                // start application with arguments
                //MainWindow mw = new MainWindow(e.Args);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Global exception: {ex}.");
                Console.WriteLine("Close App...");
                Current.Shutdown();
            }
        }
    }
}
