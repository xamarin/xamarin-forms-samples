using Xamarin.Forms;

namespace WorkingWithFonts
{
    public class App : Application
    {
        public App()
        {
            TabbedPage tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(new FontPageXaml { Title = "Xaml", IconImageSource = "xaml.png" });
            tabbedPage.Children.Add(new FontPageCs { Title = "C#", IconImageSource = "csharp.png" });

            MainPage = tabbedPage;
        }
    }
}
