using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WorkingWithImages
{
    public class App : Application
    {
        public App()
        {
            // This sample includes both XAML and C# examples of working with the
            // Xamarin.Forms image control. Uncomment one of the two lines at the end
            // of this constructor to switch between the XAML and C# examples.
            // Visit the docs at this link:
            // https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/images

            // C# examples
            var csharpTab = new TabbedPage();
            csharpTab.Children.Add(new LocalImages { Title = "Local", IconImageSource = "csharp.png" });
            csharpTab.Children.Add(new DownloadImages { Title = "Download", IconImageSource = "csharp.png" });
            csharpTab.Children.Add(new EmbeddedImages { Title = "Embedded", IconImageSource = "csharp.png" });
            

            // Xaml examples
            var xamlTab = new TabbedPage();
            xamlTab.Children.Add(new LocalImagesXaml { Title = "Local", IconImageSource = "xaml.png" });
            xamlTab.Children.Add(new DownloadImagesXaml { Title = "Downloaded", IconImageSource = "xaml.png" });
            xamlTab.Children.Add(new EmbeddedImagesXaml { Title = "Embedded", IconImageSource = "xaml.png" });


            // NOTE: uncomment the one of these lines to test C# or XAML
            //MainPage = csharpTab;
            MainPage = xamlTab;


            // EXTRA: show loading a large filesize image with indicator while downloading
            //MainPage = new LoadingPlaceholder ();
        }
    }
}
