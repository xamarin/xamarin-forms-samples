using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public partial class AndroidListViewFastScrollPage : ContentPage
    {
        public AndroidListViewFastScrollPage()
        {
            InitializeComponent();
            BindingContext = new ListViewViewModel();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            listView.On<Android>().SetIsFastScrollEnabled(!listView.On<Android>().IsFastScrollEnabled());
        }
    }
}
