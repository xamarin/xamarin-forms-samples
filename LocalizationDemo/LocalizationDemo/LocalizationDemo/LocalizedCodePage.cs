using LocalizationDemo.Resx;
using System.Globalization;
using Xamarin.Forms;

namespace LocalizationDemo
{
    public class LocalizedCodePage : ContentPage
    {
        public LocalizedCodePage()
        {
            // Note: you can override the CurrentUICulture to test other languages
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("zh-Hans");

            Title = "Localed Code Page";
            Padding = new Thickness(10, 40, 10, 10);

            Label notesLabel = new Label
            {
                Text = AppResources.NotesLabel,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Entry notesEntry = new Entry
            {
                Placeholder = AppResources.NotesPlaceholder,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Button addButton = new Button
            {
                Text = AppResources.AddButton,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            Content = new StackLayout
            {
                Children = {
                    notesLabel,
                    notesEntry,
                    addButton
                }
            };
        }
    }
}