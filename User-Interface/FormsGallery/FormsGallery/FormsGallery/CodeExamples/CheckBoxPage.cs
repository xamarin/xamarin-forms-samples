using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class CheckBoxPage : ContentPage
    {
        Label label;

        public CheckBoxPage()
        {
            Label header = new Label
            {
                Text = "CheckBox",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            CheckBox checkbox = new CheckBox
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            checkbox.CheckedChanged += OnCheckboxCheckedChanged;

            label = new Label
            {
                Text = "CheckBox is now False",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "CheckBox Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    checkbox,
                    label
                }
            };
        }

        void OnCheckboxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            label.Text = string.Format("CheckBox is now {0}", e.Value);
        }
    }
}
