using System;
using Xamarin.Forms;

namespace ExpanderDemos.Controls
{
    public partial class SpacingModifier : ContentView
    {
        public static readonly BindableProperty ContentSpacingProperty = BindableProperty.Create(nameof(ContentSpacing), typeof(string), typeof(SpacingModifier), "0", propertyChanged: OnContentSpacingPropertyChanged);

        public string ContentSpacing
        {
            get => (string)GetValue(ContentSpacingProperty);
            set => SetValue(ContentSpacingProperty, value);
        }

        public Expander Expander { get; set; }

        public SpacingModifier()
        {
            InitializeComponent();
        }

        void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            Expander.Spacing = Convert.ToDouble(entry.Text);
        }

        static void OnContentSpacingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (SpacingModifier)bindable;
            element.entry.Text = (string)newValue;
        }
    }
}
