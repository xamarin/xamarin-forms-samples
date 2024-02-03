using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class AnyTrueMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || !targetType.IsAssignableFrom(typeof(bool)))
            {
                return false;
                // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue               
            }

            foreach (var value in values)
            {
                if (!(value is bool b))
                {
                    return false;
                    // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue
                }
                else if (b)
                {
                    return true;
                }                    
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (!(value is bool b) || targetTypes.Any(t => !t.IsAssignableFrom(typeof(bool))))
            {
                // Return null to indicate conversion back is not possible
                return null;
            }

            if (!b)
            {
                return targetTypes.Select(t => (object)false).ToArray();
            }
            else
            {
                // Can't convert back from true because of ambiguity
                return null;
            }
        }
    }
}
