using System.Linq;
using Xamarin.Forms;

namespace NotificationHubSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (messageDisplay.Children.OfType<Label>().Where(c => c.Text == message).Any())
                {
                    // Do nothing, an identical message already exists
                }
                else
                {
                    Label label = new Label()
                    {
                        Text = message,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Start
                    };
                    messageDisplay.Children.Add(label);
                }
            });
        }
    }
}
