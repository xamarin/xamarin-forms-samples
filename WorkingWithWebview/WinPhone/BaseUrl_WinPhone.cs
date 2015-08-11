using Xamarin.Forms;
using WorkingWithWebview.WinPhone;
using Windows.Storage;
using System.IO.IsolatedStorage;

[assembly: Dependency(typeof(BaseUrl_WinPhone))]

namespace WorkingWithWebview.WinPhone
{
    public class BaseUrl_WinPhone : IBaseUrl
    {
        public string Get()
        {
            //IsolatedStorageFile.GetUserStoreForApplication().
            return "";
        }
    }
}