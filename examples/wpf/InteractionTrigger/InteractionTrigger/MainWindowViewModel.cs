using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InteractionTrigger
{
    public class MainWindowViewModel
    {
        private ICommand _leftButtonDownCommand;

        public ICommand LeftMouseButtonDown
        {
            get
            {
                return _leftButtonDownCommand ?? (_leftButtonDownCommand = new RelayCommand(
                   x =>
                   {
                       DoStuff();
                   }));
            }
        }

        private static void DoStuff()
        {
            MessageBox.Show("Responding to left mouse button click event...");
        }
    }
}
