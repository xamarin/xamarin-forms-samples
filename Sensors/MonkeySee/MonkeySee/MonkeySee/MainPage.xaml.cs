using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Urho;
using Urho.Forms;

namespace MonkeySee
{
    public partial class MainPage : ContentPage
    {
        MonkeyDo monkeyDo;

        public MainPage()
        {
            InitializeComponent();

            OrientationSensor.ReadingChanged += (sender, args) =>
            {
                System.Numerics.Quaternion q = args.Reading.Orientation;

                // Convert to Urho Quaternion, and swap Y and Z values to 
                //  convert from right-hand to left-hand coordinates.
                monkeyDo.Orientation = new Quaternion(q.X, q.Z, q.Y, q.W);
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            monkeyDo = await urhoSurface.Show<MonkeyDo> (new ApplicationOptions(assetsFolder: "Data"));

            try
            {
                OrientationSensor.Start(SensorSpeed.Default);
            }
            catch
            {
                Content = new Label
                {
                    Text = "Sorry, the OrientationSensor is not supported on this device.",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(50)
                };
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            OrientationSensor.Stop();
            UrhoSurface.OnDestroy();
        }
    }
}
