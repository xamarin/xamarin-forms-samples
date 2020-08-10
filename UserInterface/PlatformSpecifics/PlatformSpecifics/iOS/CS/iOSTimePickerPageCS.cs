using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSTimePickerPageCS : ContentPage
    {
        public iOSTimePickerPageCS()
        {
            Xamarin.Forms.TimePicker timePicker = new Xamarin.Forms.TimePicker
            {
                Time = new TimeSpan(14,00,00)
            };

            Button button = new Button
            {
                Text = "Toggle TimePicker UpdateMode"
            };
            button.Clicked += (sender, e) =>
            {
                switch (timePicker.On<iOS>().UpdateMode())
                {
                    case UpdateMode.Immediately:
                        timePicker.On<iOS>().SetUpdateMode(UpdateMode.WhenFinished);
                        break;
                    case UpdateMode.WhenFinished:
                        timePicker.On<iOS>().SetUpdateMode(UpdateMode.Immediately);
                        break;
                }
            };
            timePicker.On<iOS>().SetUpdateMode(UpdateMode.WhenFinished);

            Title = "TimePicker UpdateMode";
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children =
                {
                    timePicker,
                    button
                }
            };
        }
    }
}

