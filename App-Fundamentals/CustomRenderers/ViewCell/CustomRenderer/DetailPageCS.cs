using System;
using Xamarin.Forms;

namespace CustomRenderer
{
    public class DetailPageCS : ContentPage
    {
        public DetailPageCS(object detail)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(20, 40, 20, 20);
                    break;
                case Device.Android:
                case Device.UWP:
                    Padding = new Thickness(20);
                    break;
            }

            var detailLabel = new Label();
            if (detail is string)
            {
                detailLabel.Text = detail as string;
            }
            else if (detail is DataSource)
            {
                detailLabel.Text = (detail as DataSource).Name;
            }

            var dismissButton = new Button { Text = "Dismiss" };
            dismissButton.Clicked += OnButtonClicked;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label { Text = "Xamarin.Forms Detail Page" },
                    detailLabel,
                    dismissButton
                }
            };
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
