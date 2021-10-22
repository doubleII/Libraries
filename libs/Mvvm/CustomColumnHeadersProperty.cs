using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataSchedule
{
    public static class CustomColumnHeadersProperty
    {

        public static DependencyProperty ItemTypeProperty = DependencyProperty.RegisterAttached(
            "ItemType",
            typeof(Type),
            typeof(CustomColumnHeadersProperty),
            new PropertyMetadata(OnItemTypeChanged));

        public static void SetItemType(DependencyObject obj, Type value)
        {
            obj.SetValue(ItemTypeProperty, value);
        }

        public static Type GetItemType(DependencyObject obj)
        {
            return (Type)obj.GetValue(ItemTypeProperty);
        }

        private static void OnItemTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var dataGrid = sender as DataGrid;

            if (args.NewValue != null)
                dataGrid.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            else
                dataGrid.AutoGeneratingColumn -= dataGrid_AutoGeneratingColumn;
        }

        static void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //var type = GetItemType(sender as DataGrid);
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
            var header = Helper.columns.Where(c => c.ColumnKey == $"{e.Column.Header}")
                                     .Select(c => c.ColumnHeaderText).ToList();
            if (header.Count() is 0)
                e.Column.Visibility = Visibility.Hidden;
            else
                e.Column.Header = header[0];
            var ee = e.Column;
        }
    }

    public static class Helper
    {
        public static readonly ColumnInfo[] columns = ConfigHandler.GetListViewInfo_PatMonitor("lvAppointments").GetAllColumns();
    }
}
