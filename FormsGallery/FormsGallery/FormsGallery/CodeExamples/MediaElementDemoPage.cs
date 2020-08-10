using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class MediaElementDemoPage : ContentPage
    {
        public MediaElementDemoPage()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star }
                }
            };

            grid.Children.Add(new Label
            {
                Text = "MediaElement",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            grid.Children.Add(new MediaElement
            {
                Source = "https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4",
                AutoPlay = true,
                ShowsPlaybackControls = true
            }, 0, 1);

            Title = "MediaElement Demo";
            Content = grid;
        }
    }
}

