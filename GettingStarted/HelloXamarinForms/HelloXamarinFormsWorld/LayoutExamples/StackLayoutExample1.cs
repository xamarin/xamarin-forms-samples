using Xamarin.Forms;

namespace HelloXamarinFormsWorld
{
    public class StackLayoutExample1 : ContentPage
    {
        public StackLayoutExample1()
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
                          Children = { red, yellow, green }
                      };
        }
    }
}
