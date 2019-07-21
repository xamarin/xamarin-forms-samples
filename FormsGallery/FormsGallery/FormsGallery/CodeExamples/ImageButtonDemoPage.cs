using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class ImageButtonDemoPage : ContentPage
    {
        Label label;
        int clickTotal = 0;

        public ImageButtonDemoPage()
        {
            Label header = new Label
            {
                Text = "ImageButton",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            ImageButton imageButton = new ImageButton
            {
                Source = "XamarinLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            imageButton.Clicked += OnImageButtonClicked;

            label = new Label
            {
                Text = "0 ImageButton clicks",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "ImageButton Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    imageButton,
                    label
                }
            };
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            label.Text = $"{clickTotal} ImageButton click{(clickTotal == 1 ? "" : "s")}";
        }
    }
}
