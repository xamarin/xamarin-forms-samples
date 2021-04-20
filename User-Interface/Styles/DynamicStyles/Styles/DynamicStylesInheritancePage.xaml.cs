using System;
using Xamarin.Forms;

namespace Styles
{
	public partial class DynamicStylesInheritancePage : ContentPage
	{
		bool originalStyle = true;

		public DynamicStylesInheritancePage ()
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

