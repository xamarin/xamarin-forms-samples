using System;
using Xamarin.Forms;

namespace Styles
{
	public partial class DynamicStylesPage : ContentPage
	{
		bool originalStyle = true;

		public DynamicStylesPage ()
		{
			InitializeComponent ();
			Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			if (originalStyle) {
				Resources ["searchBarStyle"] = Resources ["greenSearchBarStyle"];
				originalStyle = false;
			} else {
				Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];
				originalStyle = true;
			}
		}
	}
}

