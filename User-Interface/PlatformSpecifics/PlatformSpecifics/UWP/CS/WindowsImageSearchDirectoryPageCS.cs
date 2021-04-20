using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsImageSearchDirectoryPageCS : ContentPage
    {
        public WindowsImageSearchDirectoryPageCS()
        {
            Xamarin.Forms.Application.Current.On<Windows>().SetImageDirectory("Assets");

            Title = "Image Directory";
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children = 
                {
                    new Image { Source = "Xamagon.png" },
                    new ImageButton { Source = "net_small_purple.png" },
                    new Button { ImageSource = "DotNetSource_small.png", BackgroundColor = Color.Transparent }
                }
            };
        }
    }
}
