using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class iOSFirstResponderPageCS : ContentPage
    {
        public iOSFirstResponderPageCS()
        {
            Xamarin.Forms.Entry firstEntry = new Xamarin.Forms.Entry { Placeholder = "First Entry" };
            Button firstButton = new Button { Text = "OK" };

            Xamarin.Forms.Entry secondEntry = new Xamarin.Forms.Entry { Placeholder = "Second Entry" };
            Button secondButton = new Button { Text = "OK" };
            secondButton.On<iOS>().SetCanBecomeFirstResponder(true);

            Title = "VisualElement first responder";
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children =
                {
                    new Label { Text = "Click in the first Entry to make the keyboard appear. Then click OK and the keyboard should disappear." },
                    firstEntry,
                    firstButton,
                    new Label { Text = "Click in the second Entry to make the keyboard appear. Then click OK and the keyboard shouldn't disappear." },
                    secondEntry,
                    secondButton
                }
            };
        }
    }
}
