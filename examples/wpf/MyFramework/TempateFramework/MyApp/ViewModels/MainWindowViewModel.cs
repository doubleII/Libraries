
using Commands;
using DockingLibrary;
using MyApp.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using ViewAModul.Views;

namespace MyApp.ViewModels
{
    public class MainWindowViewModel : ObservableObjects
    {
        DockManager _dockManager;
        private ViewA viewA;

        private Visibility _closeButtonVisibility = Visibility.Collapsed;
        public Visibility CloseButtonVisibility 
        { 
            get { return _closeButtonVisibility; }
            set {
                _closeButtonVisibility = value;
                OnPropertyChanged(nameof(CloseButtonVisibility));
            } 
        }

        private Visibility _openButtonVisibility;
        public Visibility OpenButtonVisibility
        {
            get { return _openButtonVisibility; }
            set
            {
                _openButtonVisibility = value;
                OnPropertyChanged(nameof(OpenButtonVisibility));
            }
        }

        public string Title { get; set; }

        private RelayCommand _viewACommand;

        public RelayCommand ViewACommand => _viewACommand ?? (_viewACommand = new RelayCommand(ViewACommendExecute));

        private RelayCommand _openMenuCommand;

        public RelayCommand OpenMenuCommand => _openMenuCommand ?? (_openMenuCommand = new RelayCommand(OpenMenuCommandExecute));

        private RelayCommand _closeMenuCommand;

        public RelayCommand CloseMenuCommand => _closeMenuCommand ?? (_closeMenuCommand = new RelayCommand(CloseMenuCommandExecute));



        private void CloseMenuCommandExecute(object obj)
        {
            OpenButtonVisibility = Visibility.Visible;
            CloseButtonVisibility = Visibility.Collapsed;
        }

        private void OpenMenuCommandExecute(object obj)
        {
            OpenButtonVisibility = Visibility.Collapsed;
            CloseButtonVisibility = Visibility.Visible;
        }

        public MainWindowViewModel(DockManager dockManager, MainWindow windows)
        {
            Title = "Shell Window";
            _dockManager = dockManager;
            dockManager.ParentWindow = windows;
        }

        private void ViewACommendExecute(object obj)
        {
            if(viewA != null)
                viewA.Close();

            viewA = new ViewA();
            viewA.DockManager = _dockManager;
            viewA.Show(Dock.Left);
        }




    }
}
