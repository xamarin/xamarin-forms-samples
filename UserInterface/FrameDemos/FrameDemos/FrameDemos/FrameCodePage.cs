using Xamarin.Forms;

namespace FrameDemos
{
    public class FrameCodePage : ContentPage
    {
        public FrameCodePage()
        {
            Padding = 10;
            Title = "Frame Code Demo";

            Frame frame1 = new Frame
            {
                Content = new Label { Text = "Default" }
            };

            Frame frame2 = new Frame
            {
                BorderColor = Color.Orange,
                Content = new Label { Text = "BorderColor" },
            };

            Frame frame3 = new Frame
            {
                BorderColor = Color.Orange,
                Content = new Label { Text = "CornerRadius" },
                CornerRadius = 10
            };

            Frame frame4 = new Frame
            {
                BackgroundColor = Color.LightGray,
                BorderColor = Color.Orange,
                Content = new Label { Text = "BackgroundColor" },
                CornerRadius = 10
            };

            Frame frame5 = new Frame
            {
                BackgroundColor = Color.LightGray,
                BorderColor = Color.Orange,
                Content = new Label { Text = "HasShadow False (platform-dependent)" },
                CornerRadius = 10,
                HasShadow = false
            };

            Frame frame6 = new Frame
            {
                BackgroundColor = Color.LightGray,
                BorderColor = Color.Orange,
                Content = new Label { Text = "HasShadow True (platform-dependent)" },
                CornerRadius = 10,
                HasShadow = true
            };

            Frame cardFrame = new Frame
            {
                BorderColor = Color.Gray,
                CornerRadius = 5,
                Padding = 8,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Card Example",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new BoxView
                        {
                            Color = Color.Gray,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill
                        },
                        new Label
                        {
                            Text = "Frames can wrap more complex layouts to create more complex UI components, such as this card!"
                        }
                    }
                }
            };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        frame1,
                        frame2,
                        frame3,
                        frame4,
                        frame5,
                        frame6,
                        cardFrame
                    }
                }
            };
        }
    }
}