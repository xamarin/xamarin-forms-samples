using System;
using Windows.UI.Xaml.Data;

namespace CustomRenderer.WinPhone81
{
    public class ConcatImageExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fileName = value as string;
            if (fileName == null)
                return null;

            return string.Concat(fileName, ".jpg");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
