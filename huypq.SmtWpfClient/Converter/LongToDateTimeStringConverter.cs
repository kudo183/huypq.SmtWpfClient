using System;
using System.Windows.Data;

namespace huypq.SmtWpfClient.Converter
{
    [ValueConversion(typeof(long), typeof(string))]
    public class LongToDateTimeStringConverter : IValueConverter
    {
        private static readonly LongToDateTimeStringConverter _instance = new LongToDateTimeStringConverter();

        public static LongToDateTimeStringConverter Instance
        {
            get { return _instance; }
        }

        public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
        {
            var date = new DateTime((long)value, DateTimeKind.Utc);
            return date.ToLocalTime().ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
