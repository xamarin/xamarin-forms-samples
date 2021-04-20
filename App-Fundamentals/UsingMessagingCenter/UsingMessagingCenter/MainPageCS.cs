using Xamarin.Forms;

namespace UsingMessagingCenter
{
    public class MainPageCS : ContentPage
    {
        public MainPageCS()
        {
            BindingContext = new MainPageViewModel();

            Label label = new Label { Text = "MessagingCenter Demo", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center };

            // Send messages when buttons are pressed
            Button button1 = new Button { Text = "Say Hi" };
            button1.Clicked += (sender, e) =>
            {
                MessagingCenter.Send<MainPageCS>(this, "Hi");
            };
            Button button2 = new Button { Text = "Say Hi to John" };
            button2.Clicked += (sender, e) =>
            {
                MessagingCenter.Send<MainPageCS, string>(this, "Hi", "John");
            };

            Button button3 = new Button { Text = "Unsubscribe from alert" };
            button3.Clicked += async (sender, e) =>
            {
                MessagingCenter.Unsubscribe<MainPageCS, string>(this, "Hi");
                await DisplayAlert("Unsubscribed",
                                   "This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.",
                                   "OK");
            };

            // Subscribe to a message (which the ViewModel has also subscribed to) to display an alert
            MessagingCenter.Subscribe<MainPageCS, string>(this, "Hi", async (sender, arg) =>
            {
                await DisplayAlert("Message Received", "arg=" + arg, "OK");
            });

            ListView listView = new ListView();
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Greetings");

            Content = new StackLayout
            {
                Padding = new Thickness(20, 35, 20, 20),
                Children = { label, button1, button2, button3, listView }
            };
        }
    }
}

