using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class StringConcatenationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values is null || values.Length == 0)
            {
                return null;
            }

            string separator = parameter as string ?? " ";
            StringBuilder sb = new StringBuilder();
            int i = 0;

            if (values.All(v => string.IsNullOrEmpty(v as string)))
            {
                return BindableProperty.UnsetValue;
            }

            foreach (var value in values)
            {
                if (value as string == "DoNothing")
                {
                    return Binding.DoNothing;
                }
                if (value as string == "UnsetValue")
                {
                    return BindableProperty.UnsetValue;
                }
                if (value as string == null)
                {
                    return null;
                }

                if (i != 0 && separator != null)
                {
                    sb.Append(separator);
                }
                sb.Append(value?.ToString());
                i++;
            }
            return sb.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string s = value as string;
            if (s == "null" || string.IsNullOrEmpty(s))
            {
                return null;
            }

            string separator = parameter as string ?? " ";

            if (!targetTypes.All(t => t == typeof(object)) && !targetTypes.All(t => t == typeof(string)))
            {
                return null;
            }

            var array = s.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).Cast<object>().ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                var str = array[i] as string;
                if (str == null)
                {
                    array[i] = null;
                }                    
                if (str == "UnsetValue")
                {
                    array[i] = BindableProperty.UnsetValue;
                }                    
                if (str == "DoNothing")
                {
                    array[i] = Binding.DoNothing;
                }                    
            }
            return array;
        }
    }
}
