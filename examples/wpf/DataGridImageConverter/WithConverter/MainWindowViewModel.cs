using MvvMLightLib;
using System.Collections.ObjectModel;
using TestModel;
//C:\Developement\MyCommonInfo\@Demos\DefaultCollection\tests\Test Projects\WPF\DataGridImageConverter\WithConverter\package
namespace WithConverter
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<Model> _items;
        public ObservableCollection<Model> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Model>();
            Items.Add(new Model() { Status = "T", Name = "My Name", Description = "dafafgfsd" });
            Items.Add(new Model() { Status = "F", Name = "No Name", Description = "fagfhgfbhd" });
            Items.Add(new Model() { Status = "V", Name = "By my name", Description = "sdfgsdh" });
        }
    }
}
