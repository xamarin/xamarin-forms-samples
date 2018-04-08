using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.UI.Popups;

namespace Phoneword.UWP.Services
{
    public class PhoneDialerService
    {
        bool _dialled = false;

        public bool Dial(string number)
        {
            DialNumber(number);
            return _dialled;
        }

        async Task DialNumber(string number)
        {
            var phoneLine = await GetDefaultPhoneLineAsync();
            if (phoneLine != null)
            {
                phoneLine.Dial(number, number);;
                _dialled = true;
            }
            else
            {
                var dialog = new MessageDialog("No line found to place the call");
                await dialog.ShowAsync();
                _dialled = false;
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