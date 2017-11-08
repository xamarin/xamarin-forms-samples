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

            tabs.Children.Add(new FontPageCs { Title = "C#", Icon = "csharp.png" });

            tabs.Children.Add(new FontPageXaml { Title = "Xaml", Icon = "xaml.png" });

            MainPage = tabs;
        }
    }
}

