using System;
using Xamarin.Forms;

namespace ButtonCode
{
    class ButtonCodePage : ContentPage
    {
        int count = 0;

        public ButtonCodePage()
        {
            Button button = new Button
            {
                Text = String.Format("Tap for click count!")
            };
            button.Clicked += (sender, args) =>
            {
                count++;
                button.Text = 
                    String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
            };

            this.Content = button;
        }
    }
}
