using System;
using System.IO;
using Xamarin.Forms;

namespace DependencyServiceSample
{
    public class App : Application
    {
        public App()
        {
            var stack = new StackLayout();
            MainPage = new ContentPage
            {
                Content = stack
            };

            // Text-to-Speech
            var speak = new Button
            {
                Text = "Hello, Forms !",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            speak.Clicked += (sender, e) =>
            {
                DependencyService.Get<ITextToSpeech>().Speak("Hello from Xamarin Forms");
            };
            stack.Children.Add(speak);

            // Battery Information
            var button = new Button
            {
                Text = "Click for battery info",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            button.Clicked += (sender, e) =>
            {
                var bat = DependencyService.Get<IBattery>();

                switch (bat.PowerSource)
                {
                    case PowerSource.Battery:
                        button.Text = "Battery - ";
                        break;
                    case PowerSource.Ac:
                        button.Text = "AC - ";
                        break;
                    case PowerSource.Usb:
                        button.Text = "USB - ";
                        break;
                    case PowerSource.Wireless:
                        button.Text = "Wireless - ";
                        break;
                    case PowerSource.Other:
                    default:
                        button.Text = "Unknown - ";
                        break;
                }
                switch (bat.Status)
                {
                    case BatteryStatus.Charging:
                        button.Text += "Charging";
                        break;
                    case BatteryStatus.Discharging:
                        button.Text += "Discharging";
                        break;
                    case BatteryStatus.NotCharging:
                        button.Text += "Not Charging";
                        break;
                    case BatteryStatus.Full:
                        button.Text += "Full";
                        break;
                    case BatteryStatus.Unknown:
                    default:
                        button.Text += "Unknown";
                        break;
                }
            };
            stack.Children.Add(button);

            // Device Orientation
            var orient = new Button
            {
                Text = "Get Orientation",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            orient.Clicked += (sender, e) =>
            {
                var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
                switch (orientation)
                {
                    case DeviceOrientations.Undefined:
                        orient.Text = "Undefined";
                        break;
                    case DeviceOrientations.Landscape:
                        orient.Text = "Landscape";
                        break;
                    case DeviceOrientations.Portrait:
                        orient.Text = "Portrait";
                        break;
                }
            };
            stack.Children.Add(orient);

            // Picture Picker
            Button pickPictureButton = new Button
            {
                Text = "Pick Photo",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            stack.Children.Add(pickPictureButton);

            pickPictureButton.Clicked += async (sender, e) =>
            {
                pickPictureButton.IsEnabled = false;
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

                if (stream != null)
                {
                    Image image = new Image
                    {
                        Source = ImageSource.FromStream(() => stream),
                        BackgroundColor = Color.Gray
                    };

                    TapGestureRecognizer recognizer = new TapGestureRecognizer();
                    recognizer.Tapped += (sender2, args) =>
                    {
                        (MainPage as ContentPage).Content = stack;
                        pickPictureButton.IsEnabled = true;
                    };
                    image.GestureRecognizers.Add(recognizer);

                    (MainPage as ContentPage).Content = image;
                }
                else
                {
                    pickPictureButton.IsEnabled = true;
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

