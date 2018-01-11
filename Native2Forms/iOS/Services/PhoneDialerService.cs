using Foundation;
using UIKit;

namespace Phoneword.iOS.Services
{
    public class PhoneDialerService
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
        }
    }
}