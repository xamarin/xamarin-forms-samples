using Xamarin.Forms;

namespace HelloXamarinFormsWorld
{
    public class StackLayoutExample3 : ContentPage
    {
        public StackLayoutExample3()
        {
            Padding = new Thickness(20);
            Label red = new Label
                        {
                            Text = "Stop",
                            BackgroundColor = Color.Red,
                            FontSize = 20,
                            WidthRequest = 100
                        };
            Label yellow = new Label
                           {
                               Text = "Slow down",
                               BackgroundColor = Color.Yellow,
							   FontSize = 20,
                               WidthRequest = 100
                           };
            Label green = new Label
                          {
                              Text = "Go",
                              BackgroundColor = Color.Green,
                              FontSize = 20,
                              WidthRequest = 200
                          };

            Content = new StackLayout
                      {
                          Spacing = 10,
                          VerticalOptions = LayoutOptions.End,
                          Orientation = StackOrientation.Horizontal,
                          HorizontalOptions = LayoutOptions.Start,
                          Children = { red, yellow, green }
                      };
        }
    }
}
