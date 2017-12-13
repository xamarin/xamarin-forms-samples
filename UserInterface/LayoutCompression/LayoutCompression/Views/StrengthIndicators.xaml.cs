using System;
using Xamarin.Forms;

namespace LayoutCompression
{
    public partial class StrengthIndicators : ContentView
    {
        public static readonly BindableProperty StrengthProperty = BindableProperty.Create(nameof(StrengthProperty), typeof(object), typeof(StrengthIndicators), default(Object));

        public Object Strength
        {
            get
            {
                return GetValue(StrengthProperty);
            }
            set
            {
                SetValue(StrengthProperty, value);
            }
        }

        public StrengthIndicators()
        {
            InitializeComponent();
        }
    }
}
