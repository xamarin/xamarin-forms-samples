using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class ToolbarPlacementChangerContentView : ContentView
    {
        public static readonly BindableProperty ParentPageProperty = BindableProperty.Create("ParentPage", typeof(Xamarin.Forms.Page), typeof(ToolbarPlacementChangerContentView), null, propertyChanged:OnParentPagePropertyChanged);

        public Xamarin.Forms.Page ParentPage
        {
            get { return (Xamarin.Forms.Page)GetValue(ParentPageProperty); }
            set { SetValue(ParentPageProperty, value); }
        }

        public ToolbarPlacementChangerContentView()
        {
            InitializeComponent();
            PopulatePicker();
        }

        void PopulatePicker()
        {
            var enumType = typeof(ToolbarPlacement);
            var placementOptions = Enum.GetNames(enumType);
            foreach (string option in placementOptions)
            {
                picker.Items.Add(option);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            ParentPage.On<Windows>().SetToolbarPlacement((ToolbarPlacement)Enum.Parse(typeof(ToolbarPlacement), picker.Items[picker.SelectedIndex]));
        }

        static void OnParentPagePropertyChanged(BindableObject element, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var enumType = typeof(ToolbarPlacement);
                var instance = element as ToolbarPlacementChangerContentView;
                instance.picker.SelectedIndex = Array.IndexOf(Enum.GetNames(enumType), Enum.GetName(enumType, instance.ParentPage.On<Windows>().GetToolbarPlacement()));
            }
        }
    }
}

