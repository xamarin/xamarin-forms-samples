using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ExpanderDemos.Views
{
    public partial class AdvancedExpanderPage : ContentPage
    {
        public AdvancedExpanderPage()
        {
            InitializeComponent();
        }

        void OnLabelTapped(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Expander expander = label.Parent.Parent.Parent as Expander;

            if (label.FontSize == Device.GetNamedSize(NamedSize.Default, label))
            {
                label.FontSize = Device.GetNamedSize(NamedSize.Large, label);
            }
            else
            {
                label.FontSize = Device.GetNamedSize(NamedSize.Default, label);
            }
            expander.ForceUpdateSize();
        }
    }
}
