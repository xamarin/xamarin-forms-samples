using Xamarin.Forms;

namespace RadioButtonDemos
{
    public class GroupedRadioButtonsPageCode : ContentPage
    {
        Label colorLabel;
        Label fruitLabel;

        public GroupedRadioButtonsPageCode()
        {
            fruitLabel = new Label { Text = "You have chosen:" };
            colorLabel = new Label { Text = "You have chosen:" };

            RadioButton redRadioButton = new RadioButton { Content = "Red", TextColor = Color.Red, GroupName="colors" };
            redRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton greenRadioButton = new RadioButton { Content = "Green", TextColor = Color.Green, GroupName = "colors" };
            greenRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton blueRadioButton = new RadioButton { Content = "Blue", TextColor = Color.Blue, GroupName = "colors" };
            blueRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            RadioButton otherColorRadioButton = new RadioButton { Content = "Other", GroupName = "colors" };
            otherColorRadioButton.CheckedChanged += OnColorsRadioButtonCheckedChanged;

            RadioButton appleRadioButton = new RadioButton { Content = "Apple" };
            appleRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton bananaRadioButton = new RadioButton { Content = "Banana" };
            bananaRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton pineappleRadioButton = new RadioButton { Content = "Pineapple" };
            pineappleRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;
            RadioButton otherFruitRadioButton = new RadioButton { Content = "Other" };
            otherFruitRadioButton.CheckedChanged += OnFruitsRadioButtonCheckedChanged;

            StackLayout fruitStackLayout = new StackLayout
            {
                Children = { appleRadioButton, bananaRadioButton, pineappleRadioButton, otherFruitRadioButton }
            };

            // All of the RadioButtons in this StackLayout will automatically be given the GroupName 'fruits`.
            fruitStackLayout.SetValue(RadioButtonGroup.GroupNameProperty, "fruits");

            Title = "Grouped RadioButtons demo (code)";
            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children =
                {
                    new Label { Text = "What's your favourite color?" },
                    redRadioButton,
                    greenRadioButton,
                    blueRadioButton,
                    otherColorRadioButton,
                    colorLabel,
                    new Label { Text = "What's your favorite fruit?" },
                    fruitStackLayout,
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

