using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
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

            Content = new StackLayout
            {
                Children =
                {
                    frame1,
                    frame2,
                    frame3,
                    frame4,
                    frame5,
                    frame6
                }
            };
        }
    }
}