using Xamarin.Forms;

namespace StepperDemo
{
    public class BasicStepperCodePage : ContentPage
    {
        public BasicStepperCodePage()
        {
            Label rotationLabel = new Label
            {
                Text = "ROTATING TEXT",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label displayLabel = new Label
            {
                Text = "(uninitialized)",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Stepper stepper = new Stepper
            {
                Maximum = 360,
                Increment = 30,
                HorizontalOptions = LayoutOptions.Center
            };
            stepper.ValueChanged += (sender, e) => 
            {
                rotationLabel.Rotation = stepper.Value;
                displayLabel.Text = string.Format("The Stepper value is {0}", e.NewValue);
            };

            Title = "Basic Stepper Code";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { rotationLabel, stepper, displayLabel }
            };
        }
    }
}

