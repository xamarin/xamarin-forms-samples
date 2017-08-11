using System;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			masterPage.ListView.ItemSelected += OnItemSelected;

			if (Device.OS == TargetPlatform.Windows) {
				Master.Icon = "swap.png";
			}
		}

		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;

				// Workaround for bug #53215 until https://github.com/xamarin/Xamarin.Forms/pull/707
				// is available in a stable release
				if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Desktop)
					return;

				IsPresented = false;
			}
		}
	}
}
