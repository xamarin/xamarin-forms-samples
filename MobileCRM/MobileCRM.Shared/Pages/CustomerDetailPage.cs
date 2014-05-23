using MobileCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Shared.CustomViews;

namespace MobileCRM.Shared.Pages
{
    public class CustomerDetailPage : ContentPage
    {
        public CustomerDetailPage(POI poi)
        {

            this.BindingContext = poi;
            // Use reflection to turn our object
            // into a property bag.
            var detailList = new ListView();
            detailList.ItemSource = poi.GetType()
                .GetRuntimeProperties()
                .Where(pi =>
                    pi.GetValue(poi) != null)
                .Select(pi => new KeyValuePair<string, object>(pi.Name, pi.GetValue(poi)));

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
            Title = poi.DisplayLabel;
        }
    }
}
