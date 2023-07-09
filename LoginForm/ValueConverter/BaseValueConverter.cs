using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace LoginForm
{
    /// <summary>
    /// A base  Value converter that allow direct XAML usage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()

    {
        #region Private Menmber

        /// <summary>
        /// A Single static instance of this valua converter
        /// </summary>
        private static T? mConverter;
        #endregion

        #region Markup Extension Method
        /// <summary>
        /// provides a static insatance of the converter
        /// </summary>
        /// <param name="serviceProvider"> The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion

        #region Value Converter Method

        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert a value back  to Itt's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
