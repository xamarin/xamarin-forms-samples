using System;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
	public partial class WindowsTabbedPageIcons : Xamarin.Forms.TabbedPage
	{
        ICommand _returnToPlatformSpecificsPage;

        public WindowsTabbedPageIcons (ICommand restore)
		{
			InitializeComponent ();
            _returnToPlatformSpecificsPage = restore;
		}

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            On<Windows>().SetHeaderIconsEnabled(!On<Windows>().GetHeaderIconsEnabled());
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}