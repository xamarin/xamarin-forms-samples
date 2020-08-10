using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSTranslucentTabbedPageCS : Xamarin.Forms.TabbedPage
    {
        ICommand returnToPlatformSpecificsPage;

        public iOSTranslucentTabbedPageCS(ICommand restore)
        {
            returnToPlatformSpecificsPage = restore;
            On<iOS>().SetTranslucencyMode(TranslucencyMode.Opaque);

            ContentPage firstPage = CreatePage(1);
            StackLayout stackLayout = firstPage.Content as StackLayout;
            Xamarin.Forms.Button translucencyButton = new Xamarin.Forms.Button
            {
                Text = "Toggle TranslucencyMode"
            };
            translucencyButton.Clicked += (sender, e) =>
            {
                switch (On<iOS>().GetTranslucencyMode())
                {
                    case TranslucencyMode.Default:
                        On<iOS>().SetTranslucencyMode(TranslucencyMode.Translucent);
                        break;
                    case TranslucencyMode.Translucent:
                        On<iOS>().SetTranslucencyMode(TranslucencyMode.Opaque);
                        break;
                    case TranslucencyMode.Opaque:
                        On<iOS>().SetTranslucencyMode(TranslucencyMode.Default);
                        break;
                }
            };

            stackLayout.Children.Add(translucencyButton);

            Title = "TabbedPage Translucent TabBar";
            Children.Add(firstPage);
            Children.Add(CreatePage(2));
            Children.Add(CreatePage(3));
        }

        ContentPage CreatePage(int pageNumber)
        {
            var returnButton = new Xamarin.Forms.Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = string.Format("Page {0}", pageNumber),
                IconImageSource = "csharp.png",
                Content = new StackLayout
                {
                    Margin = new Thickness(20,35,20,20),
                    Children = {
                        new Label { Text = string.Format("Page {0}", pageNumber), HorizontalOptions = LayoutOptions.Center },
                        returnButton
                    }
                }
            };
        }
    }
}
