using MobileCRM.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileCRM.Shared.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel(Navigation);

            BackgroundColor = Helpers.Color.Blue.ToFormsColor();

            var layout = new StackLayout { Padding = 10 };

            var label = new Label
            {
                Text = "Connect with Your Data",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
            layout.Children.Add(password);


            
            var button = new Button { Text = "Sign In", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };
        }
    }
}
