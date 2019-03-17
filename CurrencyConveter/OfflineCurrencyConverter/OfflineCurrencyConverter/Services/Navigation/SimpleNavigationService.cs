using OfflineCurrencyConverter.Shared;
using OfflineCurrencyConverter.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCurrencyConverter.Services.Navigation
{
    public class SimpleNavigationService
    {
        public async Task NavigateToNoInternetPopup()
        {
            await PopupNavigation.Instance.PushAsync(new NoInternetPopup("InternetWarningExplanation".Translate()));
        }

        public async Task NavigateToSharePopup()
        {
            await PopupNavigation.Instance.PushAsync(new ShareAppPopup());
        }

        public async Task NavigateToPreviousConversionsPopup(object context)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new PreviousConversionsPopup(context));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task ClosePopupAsync()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}
