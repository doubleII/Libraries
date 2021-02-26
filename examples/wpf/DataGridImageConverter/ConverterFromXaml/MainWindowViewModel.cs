using MvvMLightLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel;

namespace ConverterFromXaml
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
