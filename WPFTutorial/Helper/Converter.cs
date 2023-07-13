using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFTutorial
{
    // IsLessThanConverter //
    public class IsLessThanConverter : IValueConverter
    {
        public static readonly IValueConverter Insatance = new IsLessThanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double compareToValue = System.Convert.ToDouble(parameter);

            return doubleValue < compareToValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// IsGreatterThanConverter
    /// </summary>
    public class IsGreaterThanConverter : IValueConverter
    {
        public static readonly IValueConverter Insatance = new IsGreaterThanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double compareToValue = System.Convert.ToDouble(parameter);

            return doubleValue > compareToValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
