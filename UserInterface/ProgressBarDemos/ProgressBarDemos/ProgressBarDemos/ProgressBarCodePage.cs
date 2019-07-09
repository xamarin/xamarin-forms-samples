using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace ProgressBarDemos
{
    public class ProgressBarCodePage : ContentPage
    {
        public ProgressBarCodePage()
        {
            

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}