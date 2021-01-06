using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class CollapseWidthAdjusterContentView : ContentView
    {
        public static readonly BindableProperty ParentPageProperty = BindableProperty.Create("ParentPage", typeof(Xamarin.Forms.FlyoutPage), typeof(CollapseWidthAdjusterContentView), null, propertyChanged:OnParentPagePropertyChanged);

        public Xamarin.Forms.FlyoutPage ParentPage
        {
            get { return (Xamarin.Forms.FlyoutPage)GetValue(ParentPageProperty); }
            set { SetValue(ParentPageProperty, value); }
        }

        public CollapseWidthAdjusterContentView()
        {
            InitializeComponent();
        }

        void OnChangeButtonClicked(object sender, EventArgs e)
        {
            double width;
            if (double.TryParse(entry.Text, out width))
            {
                ParentPage.On<Windows>().CollapsedPaneWidth(width);
            }
        }

        static void OnParentPagePropertyChanged(BindableObject element, object oldValue, object newValue)
        { 
            if (newValue != null)
            {
                var instance = element as CollapseWidthAdjusterContentView;
                instance.entry.Text = instance.ParentPage.On<Windows>().CollapsedPaneWidth().ToString();
            }
        }
    }
}
