using System;
using System.Globalization;
using System.Windows.Data;
using TrainRacer.Contract;

namespace TrainRacer.UI.Converters
{
    public class TrainImageConverter : IValueConverter
    {
        private const string _packPrefix = "/TrainRacer;component/UI/Images/Trains/";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ITrain train:
                    return $"{_packPrefix}{train.Name}.png";
                case string name:
                    return $"{_packPrefix}{name}.png";
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
