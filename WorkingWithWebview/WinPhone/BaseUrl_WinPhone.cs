using Xamarin.Forms;
using WorkingWithWebview.WinPhone;

[assembly: Dependency(typeof(BaseUrl_WinPhone))]

namespace WorkingWithWebview.WinPhone
{
    public class BaseUrl_WinPhone : IBaseUrl
    {
        public string Get()
        {
            return "";
        }
    }
}