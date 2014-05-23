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
            
            var layout = new StackLayout();
            var label = new Label
            {
                Text = "Connect with Your Data",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            layout.Children.Add(label);

            var username = new Entry() { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
            layout.Children.Add(username);

            var password = new Entry() { Placeholder = "Password" };
            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
            layout.Children.Add(password);


            
            var button = new Button() { Text = "Sign In" };
            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

            layout.Children.Add(button);

            Content = layout;
        }
    }
}
