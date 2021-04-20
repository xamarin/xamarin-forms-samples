using UsingResxLocalization.Resx;
using Xamarin.Forms;

namespace UsingResxLocalization
{
    public class LocalizedCodePage : ContentPage
    {
        public LocalizedCodePage()
        {
            Title = "Localized Code Page";
            Padding = new Thickness(10, 40, 10, 10);

            string imgSrc = Device.RuntimePlatform == Device.UWP ? "Assets/Images/flag.png" : "flag.png";
            Image flag = new Image
            {
                Source = ImageSource.FromFile(imgSrc),
                WidthRequest = 100
            };

            Label notesLabel = new Label
            {
                Text = AppResources.NotesLabel,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 300
            };

            Entry notesEntry = new Entry
            {
                Placeholder = AppResources.NotesPlaceholder,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 300
            };

            Button addButton = new Button
            {
                Text = AppResources.AddButton,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 300
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