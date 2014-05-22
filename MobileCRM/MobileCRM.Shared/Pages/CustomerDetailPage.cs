using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace Meetup.Shared.Pages
{
    public class CustomerDetailPage : ContentPage
    {
        public CustomerDetailPage(POI poi)
        {
            // Use reflection to turn our object
            // into a property bag.
            var detailList = new ListView();
            detailList.ItemSource = poi.GetType()
                .GetRuntimeProperties()
                .Where(pi =>
                    pi.GetValue(poi) != null)
                .Select(pi => new KeyValuePair<string, object>(pi.Name, pi.GetValue(poi)));

            // Then bind our template to the key value pairs.
            detailList.ItemTemplate = new DataTemplate(typeof(TextCell));

            detailList.ItemTemplate.SetBinding(TextCell.TextProperty, "Key");
            detailList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Value");

            detailList.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
            detailList.ItemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

            detailList.BackgroundColor = Helpers.Color.Tan.ToFormsColor();

            Content = detailList;
            Title = poi.DisplayLabel;
        }
    }
}
