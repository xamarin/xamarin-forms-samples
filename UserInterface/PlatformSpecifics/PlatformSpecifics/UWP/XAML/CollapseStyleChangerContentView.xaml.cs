using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class CollapseStyleChangerContentView : ContentView
    {
        public static readonly BindableProperty ParentPageProperty = BindableProperty.Create("ParentPage", typeof(Xamarin.Forms.MasterDetailPage), typeof(CollapseStyleChangerContentView), null, propertyChanged:OnParentPagePropertyChanged);

        public Xamarin.Forms.MasterDetailPage ParentPage
        {
            get { return (Xamarin.Forms.MasterDetailPage)GetValue(ParentPageProperty); }
            set { SetValue(ParentPageProperty, value); }
        }

        public CollapseStyleChangerContentView()
        {
            InitializeComponent();
            PopulatePicker();
        }

        void PopulatePicker()
        {
            var enumType = typeof(CollapseStyle);
            var collapseOptions = Enum.GetNames(enumType);
            foreach (string option in collapseOptions)
            {
                picker.Items.Add(option);
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            ParentPage.On<Windows>().SetCollapseStyle((CollapseStyle)Enum.Parse(typeof(CollapseStyle), picker.Items[picker.SelectedIndex]));
        }

        static void OnParentPagePropertyChanged(BindableObject element, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var enumType = typeof(CollapseStyle);
                var instance = element as CollapseStyleChangerContentView;
                instance.picker.SelectedIndex = Array.IndexOf(Enum.GetNames(enumType), Enum.GetName(enumType, instance.ParentPage.On<Windows>().GetCollapseStyle()));
            }
        }
    }
}
