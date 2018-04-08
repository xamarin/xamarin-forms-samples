using Xamarin.Forms;

namespace HelloXamarinFormsWorld
{
    public class StackLayoutExample2 : ContentPage
    {
        public StackLayoutExample2()
        {
            Padding = new Thickness(20);
            Label red = new Label
                        {
                            Text = "Stop",
                            BackgroundColor = Color.Red,
                            FontSize = 20
                        };
            Label yellow = new Label
                           {
                               Text = "Slow down",
                               BackgroundColor = Color.Yellow,
							   FontSize = 20
                           };
            Label green = new Label
                          {
                              Text = "Go",
                              BackgroundColor = Color.Green,
							  FontSize = 20
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
