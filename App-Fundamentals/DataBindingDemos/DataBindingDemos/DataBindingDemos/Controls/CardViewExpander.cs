using Xamarin.Forms;

namespace DataBindingDemos.Controls
{
    public class CardViewExpander : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardViewExpander), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardViewExpander), string.Empty);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardViewExpander), Color.DarkGray);
        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardViewExpander), Color.White);
        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CardViewExpander), default(ImageSource));
        public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CardViewExpander), Color.LightGray);
        public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(CardViewExpander), false);

        public string CardTitle
        {
            get => (string)GetValue(CardViewExpander.CardTitleProperty);
            set => SetValue(CardViewExpander.CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(CardViewExpander.CardDescriptionProperty);
            set => SetValue(CardViewExpander.CardDescriptionProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(CardViewExpander.BorderColorProperty);
            set => SetValue(CardViewExpander.BorderColorProperty, value);
        }

        public Color CardColor
        {
            get => (Color)GetValue(CardViewExpander.CardColorProperty);
            set => SetValue(CardViewExpander.CardColorProperty, value);
        }

        public ImageSource IconImageSource
        {
            get => (ImageSource)GetValue(CardViewExpander.IconImageSourceProperty);
            set => SetValue(CardViewExpander.IconImageSourceProperty, value);
        }

        public Color IconBackgroundColor
        {
            get => (Color)GetValue(CardViewExpander.IconBackgroundColorProperty);
            set => SetValue(CardViewExpander.IconBackgroundColorProperty, value);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(CardViewExpander.IsExpandedProperty);
            set => SetValue(CardViewExpander.IsExpandedProperty, value);
        }
    }
}
