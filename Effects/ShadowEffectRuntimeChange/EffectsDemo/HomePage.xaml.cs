using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EffectsDemo
{
	[Preserve(AllMembers = true)]
	public partial class HomePage : ContentPage
	{
		bool isLabelTeal = false;

		public HomePage ()
		{
			InitializeComponent ();
		}

		void OnButtonClicked (object sender, EventArgs args)
		{
			if (isLabelTeal) {
				ShadowEffect.SetColor (label, Device.OnPlatform (Color.Black, Color.White, Color.Red));
				isLabelTeal = false;
			} else {
				ShadowEffect.SetColor (label, Color.Teal);
				isLabelTeal = true;
			}
		}
	}
}
