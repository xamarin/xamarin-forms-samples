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
	public partial class PreviousConversionsPopup : PopupPage
    {
		public PreviousConversionsPopup (object context)
		{
            BindingContext = context;
			InitializeComponent ();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}