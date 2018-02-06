using Phoneword.UWP;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.UI.Popups;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        bool dialled = false;

        public bool Dial(string number)
        {
            DialNumber(number);
            return dialled;
        }

        async Task DialNumber(string number)
        {
            var phoneLine = await GetDefaultPhoneLineAsync();
            if (phoneLine != null)
            {
                phoneLine.Dial(number, number);
                dialled = true;
            }
            else
            {
                var dialog = new MessageDialog("No line found to place the call");
                await dialog.ShowAsync();
                dialled = false;
            }
        }
        

        async Task<PhoneLine> GetDefaultPhoneLineAsync()
        {
            var phoneCallStore = await PhoneCallManager.RequestStoreAsync();
            var lineId = await phoneCallStore.GetDefaultLineAsync();
            return await PhoneLine.FromIdAsync(lineId);
        }
    }
}
