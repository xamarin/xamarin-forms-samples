using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSSearchBarPage : ContentPage
    {
        public iOSSearchBarPage()
        {
            InitializeComponent();
        }

        void OnSearchBarStyleButtonClicked(object sender, EventArgs e)
        {
            switch (searchBar.On<iOS>().GetSearchBarStyle())
            {
                case UISearchBarStyle.Default:
                    searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Minimal);
                    break;
                case UISearchBarStyle.Minimal:
                    searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Prominent);
                    break;
                case UISearchBarStyle.Prominent:
                    searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Default);
                    break;
            }
        }

        void OnToggleBackgroundButtonClicked(object sender, EventArgs e)
        {
            searchBar.BackgroundColor = (searchBar.BackgroundColor == Color.Teal) ? Color.Default : Color.Teal;
        }
    }
}
