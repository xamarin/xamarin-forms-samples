using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Shared.CustomViews;

namespace MobileCRM.Shared.Pages
{
    public class DetailPage<T> : ContentPage where T: class, new()
    {
        public DetailPage(T bindingContext)
        {
            BindingContext = bindingContext;
            // Use reflection to turn our object
            // into a property bag.
            var detailList = new ListView();
            detailList.ItemsSource = BindingContext.GetType()
                .GetRuntimeProperties()
                .Where(pi =>
                    pi.GetValue(BindingContext) != null)
                .Select(pi => new KeyValuePair<string, object>(pi.Name, pi.GetValue(BindingContext)));

            // Then bind our template to the key value pairs.
#if __ANDROID__
            var cell = new DataTemplate(typeof(ListTextCell));
#else
            var cell = new DataTemplate(typeof(TextCell));
#endif
            detailList.ItemTemplate = cell;

            detailList.ItemTemplate.SetBinding(TextCell.TextProperty, "Key");
            detailList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Value");

            Content = detailList;
            Title = BindingContext.ToString();
        }
    }
}
