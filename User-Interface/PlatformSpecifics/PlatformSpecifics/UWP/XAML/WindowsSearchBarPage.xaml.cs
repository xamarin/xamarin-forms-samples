using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class WindowsSearchBarPage : ContentPage
    {
        public WindowsSearchBarPage()
        {
            InitializeComponent();
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
		{
			_searchBar.On<Windows>().SetIsSpellCheckEnabled(!_searchBar.On<Windows>().GetIsSpellCheckEnabled());
		}
    }
}
