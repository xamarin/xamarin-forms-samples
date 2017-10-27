using System;
using Xamarin.Forms;
using UsingResxLocalization.Resx;

namespace UsingResxLocalization
{
    public class FirstPage : ContentPage
    {
        public FirstPage()
        {
            // create UI controls
            var myLabel = new Label();
            var myEntry = new Entry();
            var myButton = new Button();
            var myPicker = new Picker();
            myPicker.Items.Add("0");
            myPicker.Items.Add("1");
            myPicker.Items.Add("2");
            myPicker.Items.Add("3");
            myPicker.Items.Add("4");

            // apply translated resources
            myLabel.Text = AppResources.NotesLabel;
            myEntry.Placeholder = AppResources.NotesPlaceholder;
            myPicker.Title = AppResources.PickerName;
            myButton.Text = AppResources.AddButton;

            var flag = new Image();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    flag.Source = ImageSource.FromFile("flag.png");
                    break;
                case Device.UWP:
                    flag.Source = ImageSource.FromFile("Assets/Images/flag.png");
                    break;
            }

            // button shows an alert, also translated
            myButton.Clicked += async (sender, e) =>
            {
                var message = AppResources.AddMessageN;
                if (myPicker.SelectedIndex <= 0)
                {
                    message = AppResources.AddMessage0;
                }
                else if (myPicker.SelectedIndex == 1)
                {
                    message = AppResources.AddMessage1;
                }
                else
                {
                    message = String.Format(message, myPicker.Items[myPicker.SelectedIndex]);
                }
                await DisplayAlert(message, message, AppResources.CancelButton);
            };

            // add to screen
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    myLabel,
                    myEntry,
                    myPicker,
                    myButton,
                    flag},
            };
        }
    }
}

