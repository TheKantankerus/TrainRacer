using System;
using System.Globalization;
using System.Windows.Data;

namespace TrainRacer.UI.Converters
{
    public class TrackLengthTickConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 &&
                values[0] is double length &&
                values[1] is double sliderWidth)
            {
                return length * 15 / sliderWidth;
            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
