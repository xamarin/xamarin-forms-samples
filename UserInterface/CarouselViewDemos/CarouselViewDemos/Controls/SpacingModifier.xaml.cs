using System;
using Xamarin.Forms;
using CarouselViewDemos.Helpers;

namespace CarouselViewDemos.Controls
{
    public partial class SpacingModifier : ContentView
    {
        public static readonly BindableProperty SpacingTextProperty = BindableProperty.Create(nameof(SpacingText), typeof(string), typeof(SpacingModifier), "0", propertyChanged: OnSpacingTextPropertyChanged);

        public string SpacingText
        {
            get => (string)GetValue(SpacingTextProperty);
            set => SetValue(SpacingTextProperty, value);
        }

        public CollectionView CV { get; set; }

        public SpacingModifier()
        {
            InitializeComponent();
        }

        void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            var linearItemsLayout = CV.ItemsLayout as LinearItemsLayout;
            linearItemsLayout.ItemSpacing = IndexParser.ParseToken(entry.Text);
        }

        static void OnSpacingTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (SpacingModifier)bindable;
            element.entry.Text = (string)newValue;
        }
    }
}
