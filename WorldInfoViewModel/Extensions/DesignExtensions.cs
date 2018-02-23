using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WorldInfoViewModel
{
    public static class DesignExtensions
    {
        public static SolidColorBrush ConvertToSolidColorBrush(string HexCode)
        {
            return new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(HexCode));
        }
    }
}
