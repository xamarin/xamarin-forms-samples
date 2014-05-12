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

        void OnListViewItemSelected(object sender, EventArg<object> args)
        {
            if (args.Data != null)
            {
                this.Navigation.Push(new RssItemPage
                        {
                            BindingContext = (RssItem)args.Data
                        });
            }
        }
    }
}
