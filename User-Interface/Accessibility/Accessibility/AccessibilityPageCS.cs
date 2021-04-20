using System;
using Xamarin.Forms;

namespace Accessibility
{
    public class AccessibilityPageCS : ContentPage
    {
        public AccessibilityPageCS()
        {
            var titleLabel = new Label { Text = "Accessibility Demo", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            AutomationProperties.SetIsInAccessibleTree(titleLabel, true);
            AutomationProperties.SetName(titleLabel, "Title Label");

            var messageLabel = new Label();
            AutomationProperties.SetIsInAccessibleTree(messageLabel, true);
            AutomationProperties.SetName(messageLabel, "Instructions Label");
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    messageLabel.Text = "Use two fingers to swipe up or down the screen to read each element on the page.";
                    break;
                case Device.Android:
                    messageLabel.Text = "Quickly swipe right or left to navigate through elements on the page in sequence.";
                    break;
                case Device.UWP:
                    messageLabel.Text = "Use three fingers to swipe up the screen to read each element on the page.";
                    break;
            }

            var activityIndicator = new ActivityIndicator();
            AutomationProperties.SetIsInAccessibleTree(activityIndicator, true);
            AutomationProperties.SetName(activityIndicator, "Progress indicator");

            var button = new Button { Text = "Toggle ActivityIndicator" };
            AutomationProperties.SetIsInAccessibleTree(button, true);
            AutomationProperties.SetHelpText(button, "Tap to toggle the activity indicator");

            button.Clicked += (sender, e) =>
            {
                activityIndicator.IsRunning = !activityIndicator.IsRunning;
                AutomationProperties.SetHelpText(activityIndicator, activityIndicator.IsRunning ? "Running" : "Not running");
            };

            var stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            var nameLabel = new Label { Text = "Enter your name: " };
            var entry = new Entry { Placeholder = "Enter name here" };
            AutomationProperties.SetIsInAccessibleTree(entry, true);
            AutomationProperties.SetLabeledBy(entry, nameLabel);
            stackLayout.Children.Add(nameLabel);
            stackLayout.Children.Add(entry);

            var imageLabel = new Label { Text = "Tap image to hear the alert box." };
            AutomationProperties.SetIsInAccessibleTree(imageLabel, true);
            AutomationProperties.SetName(imageLabel, "Image Label");

            var image = new Image { Source = "monkeyface.png" };
            AutomationProperties.SetIsInAccessibleTree(image, true);
            AutomationProperties.SetName(image, "Monkey Face");
            AutomationProperties.SetHelpText(image, "Tap to show an alert");

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, e) => await DisplayAlert("Success", "You tapped the image", "OK");
            image.GestureRecognizers.Add(tapGestureRecognizer);

            Content = new ScrollView
            {
                Margin = new Thickness(20),
                Content = new StackLayout
                {
                    Children = {
                        titleLabel,
                        messageLabel,
                        button,
                        activityIndicator,
                        stackLayout,
                        imageLabel,
                        image
                    }
                }
            };
        }
    }
}
