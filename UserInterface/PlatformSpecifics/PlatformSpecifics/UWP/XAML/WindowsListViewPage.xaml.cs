using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class WindowsListViewPage : ContentPage
    {
        public WindowsListViewPage()
        {
            InitializeComponent();
			BindingContext = new ListViewViewModel();
            UpdateLabel();
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            await DisplayAlert("Item Tapped", "ItemTapped event fired.", "OK");
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Tap Gesture Recognizer", "Tapped event fired.", "OK");
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            switch (_listView.On<Windows>().GetSelectionMode())
            {
                case Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Accessible:
                    _listView.On<Windows>().SetSelectionMode(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Inaccessible);
                    break;
                case Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Inaccessible:
                    _listView.On<Windows>().SetSelectionMode(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Accessible);
                    break;
            }
            UpdateLabel();
        }

        void UpdateLabel()
        {
            _label.Text = $"ListView SelectionMode: {_listView.On<Windows>().GetSelectionMode()}";
        }
    }
}
