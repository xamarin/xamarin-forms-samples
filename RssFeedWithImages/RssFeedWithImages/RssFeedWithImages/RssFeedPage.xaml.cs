using System;
using Xamarin.Forms;

namespace RssFeedWithImages
{
    public partial class RssFeedPage
    {
        public RssFeedPage()
        {
            InitializeComponent();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                await this.Navigation.PushAsync(new RssItemPage
                        {
                            BindingContext = (RssItem)args.SelectedItem
                        });
            }
        }
    }
}
