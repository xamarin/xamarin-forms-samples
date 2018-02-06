using Phoneword.WinPhone81;
using Windows.ApplicationModel.Calls;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.WinPhone81
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallManager.ShowPhoneCallUI(number, string.Empty);
            return true;
        }    
    }
}
