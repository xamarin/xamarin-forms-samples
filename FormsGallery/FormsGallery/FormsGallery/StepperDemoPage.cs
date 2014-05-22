using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class StepperDemoPage : ContentPage
    {
        Label label;

        public StepperDemoPage()
        {
            Label header = new Label
            {
                Text = "Stepper",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Stepper stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 10,
                Increment = 0.1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            stepper.ValueChanged += OnStepperValueChanged;

            label = new Label
            {
                Text = "Stepper value is 0",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    stepper,
                    label
                }
            };
        }

        void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Stepper value is {0:F1}", e.NewValue);
        }
    }
}
