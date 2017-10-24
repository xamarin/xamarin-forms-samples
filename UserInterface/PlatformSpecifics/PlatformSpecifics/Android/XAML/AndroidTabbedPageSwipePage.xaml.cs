using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public partial class AndroidTabbedPageSwipePage : Xamarin.Forms.TabbedPage
    {
        public AndroidTabbedPageSwipePage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            On<Android>().SetIsSwipePagingEnabled(!On<Android>().IsSwipePagingEnabled());
        }
    }
}
