using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Shared.CustomViews;
using System.Collections;

namespace MobileCRM.Shared.Pages
{
    public class DetailPage<T> : ContentPage where T: class, new()
    {
        static string ConvertToString (object obj)
        {
            if (obj is string) return (string)obj;
            var list = obj as IEnumerable;
            if (list != null)
                return string.Join (" ", list.Cast<object>().Count() > 0 ? list.Cast<object>() : new object[] { String.Empty });
            if (obj is Address)
                return ((Address)obj).ToString();
            return Convert.ToString(obj);
        }

        public DetailPage(T bindingContext)
        {
            BindingContext = bindingContext;
            // Use reflection to turn our object
            // into a property bag.
            var detailList = new ListView();
            var items = BindingContext.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi =>{
                    var value = pi.GetValue(BindingContext);
                    if (value == null) return false;
                    if (value is string || value is Address) return !string.IsNullOrWhiteSpace(value.ToString());
                    if (value is IEnumerable)
                        return ((IEnumerable)value).Cast<object>().Any ();
                    return true;
                })
                .Select(pi => new KeyValuePair<string, object>(pi.Name, ConvertToString(pi.GetValue(BindingContext))))
                .ToList();
            detailList.ItemsSource = items;
            // Then bind our template to the key value pairs.
#if __ANDROID__
            var cell = new DataTemplate(typeof(ListTextCell));
#else
            var cell = new DataTemplate(typeof(TextCell));
#endif
            detailList.ItemTemplate = cell;

            detailList.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");
            detailList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Key");

            Content = detailList;
            Title = BindingContext.ToString();
        }
    }
}
