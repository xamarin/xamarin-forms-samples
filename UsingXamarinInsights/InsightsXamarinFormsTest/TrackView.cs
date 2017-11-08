using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InsightsXamarinFormsTest
{
    public class TrackView : ContentPage
    {
        StackLayout layout;

        public TrackView()
        {
            layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 8,
                Padding = 16
            };

            var headingLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        Text = "Xamarin",
                        HorizontalTextAlignment = TextAlignment.End,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#34495E")
                    },
                    new Label {
                        Text = "Insights",
                        HorizontalTextAlignment = TextAlignment.Start,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#3498DB")
                    }
                }
            };
            layout.Children.Add(headingLayout);

            var instructionsLabel = new Label()
            {
                Text = "touch a button",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };
            layout.Children.Add(instructionsLabel);

            var trackButton = new Button()
            {
                Text = "Track",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("ECECEC")
            };
            trackButton.SetBinding<TrackViewModel>(Button.CommandProperty, vm => vm.TrackCommand);
            layout.Children.Add(trackButton);

            var identifyButton = new Button()
            {
                Text = "Identify",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("DADFE1")
            };
            identifyButton.SetBinding<TrackViewModel>(Button.CommandProperty, vm => vm.IdentifyCommand);
            layout.Children.Add(identifyButton);

            var warningButton = new Button()
            {
                Text = "Warning",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("F4D03F")
            };
            warningButton.SetBinding<TrackViewModel>(Button.CommandProperty, vm => vm.WarnCommand);
            layout.Children.Add(warningButton);

            var errorButton = new Button()
            {
                Text = "Error",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("EF4836")
            };
            errorButton.SetBinding<TrackViewModel>(Button.CommandProperty, vm => vm.ErrorCommand);
            layout.Children.Add(errorButton);

            var crashButton = new Button()
            {
                Text = "Crash",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("CF000F")
            };
            crashButton.SetBinding<TrackViewModel>(Button.CommandProperty, vm => vm.CrashCommand);
            layout.Children.Add(crashButton);

            Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);

            foreach (var view in layout.Children)
            {
                // Hide all the children
                view.Scale = 0;
            }

            Content = new ScrollView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = layout
            };

            // Receive and display a message in an alert
            MessagingCenter.Subscribe<TrackViewModel, string>(this, "Alert", (vm, message) => DisplayAlert("Alert", message, "OK"));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Just to make sure the API key is entered
            if (Constants.INSIGHTS_API_KEY == "Replace with your API key")
            {
                await DisplayAlert("API Key Missing", "Update your API key in Constants.cs first, then launch the app.", "OK");
            }
            else
            {
                // Show the buttons only if we have Insights configured
                foreach (var view in layout.Children)
                {
                    await view.ScaleTo(1.1, 50, Easing.SpringIn);
                    await view.ScaleTo(1, 50, Easing.SpringOut);
                }
            }
        }
    }
}

