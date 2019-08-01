using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FrameDemos
{
    public class FrameCodePage : ContentPage
    {
        public FrameCodePage()
        {
            Padding = 10;
            Title = "Frame Code Demo";

            Label label = new Label
            {
                Text = "example"
            };

            Frame frame = new Frame
            {
                BackgroundColor = Color.LightGray,
                BorderColor = Color.Orange,
                Content = label,
                CornerRadius = 10,
                HasShadow = true,
            };

            Content = new StackLayout
            {
                Children =
                {
                    frame
                }
            };
        }
    }
}