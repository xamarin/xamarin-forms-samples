using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WorkingWithListview
{
    /// <summary>
    /// Very simple example of a ListView with Context Menu
    /// when holding on an item (swipe left on iOS)
    /// </summary>
    public class ContextActionsPage : ContentPage
    {
        private class BindItem
        {
            public string Title { get; set; }
            public ICommand ContextItemTapped { get; set; }
        }

        public ContextActionsPage()
        {
           

            var showAlert = new Command<object>((parameter) =>
            {
                DisplayAlert("Context Item", string.Format("on item {0} Tapped", parameter), "Ok");
            });

            var items = new List<BindItem>();
            items.Add(new BindItem { Title = "first", ContextItemTapped = showAlert });
            items.Add(new BindItem { Title = "second", ContextItemTapped = showAlert });
            items.Add(new BindItem { Title = "third", ContextItemTapped = showAlert });

            var listView = new ListView();
            listView.ItemsSource = items;
            listView.ItemTemplate = new DataTemplate(typeof(ContextActionCell));

            Padding = new Thickness(0, 20, 0, 0);

            Content = listView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
