using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WithConverter
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is "T")
            {
                Uri uri = new Uri("pack://application:,,,/WithConverter;component/icons/green.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage source = new BitmapImage(uri);
                return source;
            }

           else if(value is "F")
            {
                Uri uri = new Uri("pack://application:,,,/WithConverter;component/icons/red.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage source = new BitmapImage(uri);
                return source;
            }

           else
            {
                Uri uri = new Uri("pack://application:,,,/WithConverter;component/icons/admin.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
