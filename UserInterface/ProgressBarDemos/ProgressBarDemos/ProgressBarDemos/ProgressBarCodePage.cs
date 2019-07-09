using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace ProgressBarDemos
{
    public class ProgressBarCodePage : ContentPage
    {
        ProgressBar defaultProgressBar;
        ProgressBar styledProgressBar;
        float progress = 0f;

        public ProgressBarCodePage()
        {
            Title = "ProgressBar Code Demo";
            Padding = 10;

            defaultProgressBar = new ProgressBar
            {
                WidthRequest = 500,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            styledProgressBar = new ProgressBar
            {
                ProgressColor = Color.Orange,
                WidthRequest = 500,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var progressButton = new Button
            {
                Text = "Click to Progress",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            progressButton.Clicked += Button_Clicked;

            Content = new StackLayout
            {
                Children = {
                    defaultProgressBar,
                    styledProgressBar,
                    progressButton
                }
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            progress += 0.2f;

            if (progress > 1)
            {
                progress = 0;
            }

            // directly set the new progress value
            defaultProgressBar.Progress = progress;

            // animate to the new value over 750 milliseconds using Linear easing
            styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
        }
    }
}