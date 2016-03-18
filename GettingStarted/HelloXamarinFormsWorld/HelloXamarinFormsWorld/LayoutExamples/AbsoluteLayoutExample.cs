using Xamarin.Forms;

namespace HelloXamarinFormsWorld
{
    public class AbsoluteLayoutExample : ContentPage
    {
        public AbsoluteLayoutExample()
        {
            Label red = new Label
                        {
                            Text = "Stop",
                            BackgroundColor = Color.Red,
                            FontSize = 20,
                            WidthRequest = 200,
                            HeightRequest = 30
                        };
            Label yellow = new Label
                           {
                               Text = "Slow down",
                               BackgroundColor = Color.Yellow,
                               FontSize = 20,
                               WidthRequest = 160,
                               HeightRequest = 160
                           };
            Label green = new Label
                          {
                              Text = "Go",
                              BackgroundColor = Color.Green,
                              FontSize = 20,
                              WidthRequest = 50,
                              HeightRequest = 50
                          };
            AbsoluteLayout absLayout = new AbsoluteLayout();
            absLayout.Children.Add(red, new Point(20, 20));
            absLayout.Children.Add(yellow, new Point(40, 60));
            absLayout.Children.Add(green, new Point(80, 180));

            Content = absLayout;
        }
    }
}
