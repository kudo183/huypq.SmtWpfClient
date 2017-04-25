using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace huypq.SmtWpfClient.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        private static readonly InverseBoolToVisibilityConverter _instance = new InverseBoolToVisibilityConverter();

        public static InverseBoolToVisibilityConverter Instance
        {
            get { return _instance; }
        }

        private BooleanToVisibilityConverter _converter = new BooleanToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = _converter.Convert(value, targetType, parameter, culture) as Visibility?;
            return result == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = _converter.ConvertBack(value, targetType, parameter, culture) as bool?;
            return result == true ? false : true;
        }
    }
}
