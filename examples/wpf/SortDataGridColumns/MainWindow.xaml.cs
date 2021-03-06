﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortDataGridColumns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyType> MyT = new ObservableCollection<MyType>();
        MyConfigSection config;
        private Dictionary<int, ColumnInfo> Columns = new Dictionary<int, ColumnInfo>();

        public MainWindow()
        {
            InitializeComponent();
            config = ConfigurationManager.GetSection("SchedEventTable") as MyConfigSection;

            int i = 0;
            foreach (MyConfigInstanceElement item in config.Instances)
            {
                Columns.Add(i, new ColumnInfo(item.Key, item.Value));
                i++;
            }
            myDataGrid.ItemsSource = MyT;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void myDataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var s = sender as DataGrid;
            List<dynamic> display = new List<dynamic>();
            for (int i = 0; i < s.Columns.Count; i++)
            {
                var item = Columns.Where(x => x.Value.ColumnKey.Equals(s.Columns[i].Header))
                               .Select(x => new { index = x.Key, header = x.Value.ColumnHeader, oldindex = i, oldheader = s.Columns[i].Header })
                               .ToList();

                if (item.Count > 0)
                    display.Add(item[0]);

                else
                {
                    s.Columns[i].MaxWidth = 0;
                    display.Add(new { index = -1, header = -1, oldindex = i, oldheader = s.Columns[i].Header });
                    s.Columns[i].DisplayIndex = s.Columns.Count - (i + 1);
                }
            }
            display.Where(d => d.index != -1)
                      .Select(d => d)
                      .OrderBy(d => d.index)
                      .ToList()
                      .ForEach(i => 
                      {
                          s.Columns[i.oldindex].DisplayIndex = i.index;
                          s.Columns[i.oldindex].Header = i.header;
                      });
        }
    }

    public class MyType
    {
        public string Type { get; set;}

        public string PD_FIRSNAME { get; set; }
        public string PD_LASTNAME { get; set; }
        public string PD_SVNR { get; set; }
        public string PD_GENDER { get; set; }
        public string PD_BIRTHDATE { get; set; }
        public string PD_WOHNORT { get; set; }
        public string PD_STRASSE { get; set; }
        public string PD_HAUSNR { get; set; }

        public string Contact { get; set; }

        public string num_1 { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? Today { get; set; }
        public int? NumberOfDays { get; set; }
        public string AllDays { get; set; }

        public string KT_PICK_DT { get; set; }

    }

    public class MyConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public MyConfigInstanceCollection Instances
        {
            get => (MyConfigInstanceCollection)this[""];
            set { this[""] = value; }
        }
    }
    public class MyConfigInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            => new MyConfigInstanceElement();

        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((MyConfigInstanceElement)element).Key;
        }

        public new MyConfigInstanceElement this[string elementName]
            => this.OfType<MyConfigInstanceElement>().FirstOrDefault(item => item.Key == elementName);
    }

    public class MyConfigInstanceElement : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get => (string)base["key"];
            set => base["key"] = value;
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get => (string)base["value"];
            set => base["value"] = value;
        }
    }
    public class ColumnInfo
    {
        public ColumnInfo(string key, string header)
        {
            ColumnKey = key;
            ColumnHeader = header;
        }

        public string ColumnHeader { get; private set; }

        public string ColumnKey { get; private set; }
    }
}

