using Xamarin.Forms;

namespace MyCompany.Controls
{
    public class CircleButton : Button
    {
        public static readonly BindableProperty CircleDiameterProperty = BindableProperty.Create(nameof(CircleDiameter), typeof(double), typeof(CircleButton), -1d, propertyChanged: OnCircleDiameterPropertyChanged);

        public double CircleDiameter
        {
            get { return (double)GetValue(CircleDiameterProperty); }
            set { SetValue(CircleDiameterProperty, value); }
        }

        public CircleButton()
        {
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
            TextColor = Color.White;
            HorizontalOptions = LayoutOptions.Center;
            BorderWidth = 5;

            SetupVisualStates();
        }

        void SetupVisualStates()
        {
            VisualStateManager.SetVisualStateGroups(this, new VisualStateGroupList
            {
                new VisualStateGroup
                {
                    Name = "CommonStates",
                    States =
                    {
                        new VisualState
                        {
                            Name = "Normal",
                            TargetType = typeof(Button),
                            Setters = { new Setter { Property = ScaleProperty, Value = 1 } }
                        },
                        new VisualState
                        {
                            Name = "Pressed",
                            TargetType = typeof(Button),
                            Setters = { new Setter { Property = ScaleProperty, Value = 0.9 } }
                        }
                    }
                }
            });
        }

        static void OnCircleDiameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (CircleButton)bindable;
            element.WidthRequest = element.HeightRequest = (double)newValue;
            element.CornerRadius = (int)(double)newValue / 2;
        }
    }
}
