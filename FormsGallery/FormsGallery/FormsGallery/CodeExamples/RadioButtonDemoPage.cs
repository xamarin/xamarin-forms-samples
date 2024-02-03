using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class RadioButtonDemoPage : ContentPage
    {
        Label colorLabel;
        Label fruitLabel;

        public RadioButtonDemoPage()
        {
            Label header = new Label
            {
                Text = "RadioButton",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            fruitLabel = new Label { Text = "You have chosen:" };
            colorLabel = new Label { Text = "You have chosen:" };

            RadioButton redRadioButton = new RadioButton { Content = "Red", TextColor = Color.Red, GroupName = "colors" };
            redRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton greenRadioButton = new RadioButton { Content = "Green", TextColor = Color.Green, GroupName = "colors" };
            greenRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton blueRadioButton = new RadioButton { Content = "Blue", TextColor = Color.Blue, GroupName = "colors" };
            blueRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton otherColorRadioButton = new RadioButton { Content = "Other", GroupName = "colors" };
            otherColorRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;

            RadioButton appleRadioButton = new RadioButton { Content = "Apple", GroupName = "fruits" };
            appleRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton bananaRadioButton = new RadioButton { Content = "Banana", GroupName = "fruits" };
            bananaRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton pineappleRadioButton = new RadioButton { Content = "Pineapple", GroupName = "fruits" };
            pineappleRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton otherFruitRadioButton = new RadioButton { Content = "Other", GroupName = "fruits" };
            otherFruitRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;

            // Build the page.
            Title = "RadioButton Demo";
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children =
                {
                    header,
                    new Label { Text = "What's your favourite color?" },
                    redRadioButton,
                    greenRadioButton,
                    blueRadioButton,
                    otherColorRadioButton,
                    colorLabel,
                    new Label { Text = "What's your favorite fruit?" },
                    appleRadioButton,
                    bananaRadioButton,
                    pineappleRadioButton,
                    otherFruitRadioButton,
                    fruitLabel
                }
            };
        }

        void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            colorLabel.Text = $"You have chosen: {button.Content}";
        }

        void OnFruitsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            fruitLabel.Text = $"You have chosen: {button.Content}";
        }
    }
}

