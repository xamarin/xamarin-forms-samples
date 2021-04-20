using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using RefreshPullDirection = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.RefreshView.RefreshPullDirection;

namespace PlatformSpecifics
{
	public partial class WindowsRefreshViewPage : ContentPage
	{
		public WindowsRefreshViewPage ()
		{
			InitializeComponent ();
            enumPicker.EnumType = typeof(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.RefreshView.RefreshPullDirection);
            enumPicker.SelectedIndex = 0;
		}

        void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            refreshView.On<Windows>().SetRefreshPullDirection((RefreshPullDirection)enumPicker.SelectedItem);
        }
    }
}