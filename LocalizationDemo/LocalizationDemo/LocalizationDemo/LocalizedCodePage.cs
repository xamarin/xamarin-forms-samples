using LocalizationDemo.Resx;
using System.Globalization;
using Xamarin.Forms;

namespace LocalizationDemo
{
    public class LocalizedCodePage : ContentPage
    {
        public LocalizedCodePage()
        {
            Title = "Localized Code Page";
            Padding = new Thickness(10, 40, 10, 10);


            var imgSrc = Device.RuntimePlatform == Device.UWP ? "Assets/Images/flag.png" : "flag.png";
            Image flag = new Image
            {
                Source = ImageSource.FromFile(imgSrc)
            };

            Label notesLabel = new Label
            {
                Text = AppResources.NotesLabel,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Entry notesEntry = new Entry
            {
                Placeholder = AppResources.NotesPlaceholder,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Button addButton = new Button
            {
                Text = AppResources.AddButton,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Content = new StackLayout
            {
                Children = {
                    flag,
                    notesLabel,
                    notesEntry,
                    addButton
                }
            };
        }
    }
}