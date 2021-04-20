using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamarinFormsAppleSignIn
{
    public class AppleSignInButton : Xamarin.Forms.Button
    {
        public AppleSignInButton()
        {
            Clicked += AppleSignInButton_Clicked;
            Text = "Sign in with Apple";
            BorderWidth = 1;

            switch (ButtonStyle)
            {
                case AppleSignInButtonStyle.Black:
                    BackgroundColor = Color.Black;
                    TextColor = Color.White;
                    BorderColor = Color.Black;
                    break;
                case AppleSignInButtonStyle.White:
                    BackgroundColor = Color.White;
                    TextColor = Color.Black;
                    BorderColor = Color.White;
                    break;
                case AppleSignInButtonStyle.WhiteOutline:
                    BackgroundColor = Color.White;
                    TextColor = Color.Black;
                    BorderColor = Color.Black;
                    break;
            }
        }

        public AppleSignInButtonStyle ButtonStyle { get; set; } = AppleSignInButtonStyle.Black;

        private void AppleSignInButton_Clicked(object sender, EventArgs e)
            => SignIn?.Invoke(sender, e);

        public event EventHandler SignIn;

        public void InvokeSignInEvent(object sender, EventArgs e)
            => SignIn?.Invoke(sender, e);

        public void Dispose()
            => Clicked -= AppleSignInButton_Clicked;
    }

    public enum AppleSignInButtonStyle
    {
        Black,
        White,
        WhiteOutline
    }

}
