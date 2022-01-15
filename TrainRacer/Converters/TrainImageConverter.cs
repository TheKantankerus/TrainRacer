using System;
using System.Globalization;
using System.Windows.Data;
using TrainRacer.Contract;

namespace TrainRacer.Converters
{
    public class TrainImageConverter : IValueConverter
    {
        private const string _packPrefix = "pack://application:,,,/TrainRacer;component/Images/Trains";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ITrain train:
                    return $"{_packPrefix}{train.Name}.png";
                default:
                    return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
