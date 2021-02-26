using Commands;
using System;

namespace ViewAModul.ViewModules
{
    public class ViewAViewModel : ObservableObjects
    {
        private RelayCommand _clickMeCommand;

        private string _title;
        public string Title
        {
            get
            { return _title; }
            private set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            private set 
            { 
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }




        public RelayCommand ClickMeCommand => _clickMeCommand ?? (_clickMeCommand = new RelayCommand(ClickMeExecute));

        public ViewAViewModel()
        {
            Title = "View A";
        }

        private void ClickMeExecute(object obj)
        {
            Text = $"Hallo from View A current time: {DateTime.Now.ToString()}";
        }
    }
}
