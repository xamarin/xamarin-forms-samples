using System;
using Xamarin.Forms;

namespace TableViewSamples
{
	public partial class DataIntentXaml : ContentPage
	{
		public DataIntentXaml ()
		{
			InitializeComponent ();
		}

        void OnViewCellTapped(object sender, EventArgs e)
        {
            _target.IsVisible = !_target.IsVisible;
            _viewCell.ForceUpdateSize();
        }
	}
}
