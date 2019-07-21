using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WorkingWithFonts
{
    public class App : Application // superclass new in 1.3
    {
        public App()
        {
            var tabs = new TabbedPage();

            tabs.Children.Add(new FontPageCs { Title = "C#", IconImageSource = "csharp.png" });

            tabs.Children.Add(new FontPageXaml { Title = "Xaml", IconImageSource = "xaml.png" });

            MainPage = tabs;
        }
    }
}
