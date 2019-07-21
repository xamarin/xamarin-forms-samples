using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSModalFormSheetPageCS : ContentPage
    {
        public iOSModalFormSheetPageCS()
        {
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);

            var button = new Button { Text = "Return to Platform-Specifics List" };
            button.Clicked += async (sender, e) =>
            {
                await Navigation.PopModalAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label { Text = "Modal popup as a form sheet on the iPad", HorizontalOptions = LayoutOptions.Center },
                    button
                }
            };
        }
    }
}
