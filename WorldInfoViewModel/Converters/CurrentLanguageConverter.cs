using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WorldInfoViewModel
{
    public class CurrentLanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value;
            if (val.ToString() == "T")
            {
                return DesignExtensions.ConvertToSolidColorBrush("#388E3C");
            }
            else
            {
                return DesignExtensions.ConvertToSolidColorBrush("#FF6F00");
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
