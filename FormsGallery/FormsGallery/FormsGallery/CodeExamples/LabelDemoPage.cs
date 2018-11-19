using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class LabelDemoPage : ContentPage
    {
        public LabelDemoPage()
        {
            Label header = new Label
            {
                Text = "Label",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label label = new Label
            {
                Text =
                    "Xamarin.Forms is a cross-platform natively " +
                    "backed UI toolkit abstraction that allows " +
                    "developers to easily create user interfaces " +
                    "that can be shared across Android, iOS, and " +
                    "the Universal Windows Platform.",

                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 0)
            };

            // Build the page.
            Title = "Label Demo";
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    label
                }
            };
        }
    }
}
