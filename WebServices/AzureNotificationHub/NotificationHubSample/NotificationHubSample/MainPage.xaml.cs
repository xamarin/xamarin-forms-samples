using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotificationHubSample
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
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
