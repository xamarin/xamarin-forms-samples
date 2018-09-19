using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class AndroidTitleViewPageCS : ContentPage
    {
        public AndroidTitleViewPageCS(ICommand restore)
        {
            var titleView = new StackLayout
            {
                Children =
                {
                    new Label { Text = "My TitleView", Style = Device.Styles.TitleStyle },
                    new SearchBar()
                }
            };
            NavigationPage.SetTitleView(this, titleView);

            var button = new Button { Text = "Return to Platform-Specifics List" };
            button.Clicked += (sender, e) => restore.Execute(null);

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = 
                {
                    new Label { Text = "The TitleView on the NavigationPage has a BarHeight of 450." },
                    button
                }
            };
        }
    }
}

