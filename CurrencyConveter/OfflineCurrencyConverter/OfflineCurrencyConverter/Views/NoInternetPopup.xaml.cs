using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfflineCurrencyConverter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoInternetPopup : PopupPage
    {
        public string WarningExplanation { get; set; }

        public NoInternetPopup (string explanation)
		{
            WarningExplanation = explanation;
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}