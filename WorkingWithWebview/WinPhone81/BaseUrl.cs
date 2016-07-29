using WorkingWithWebview.WinPhone81;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace WorkingWithWebview.WinPhone81
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "ms-appx-web:///";
        }
    }
}
