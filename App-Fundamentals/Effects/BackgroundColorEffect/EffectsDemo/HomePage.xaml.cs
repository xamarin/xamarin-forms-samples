using Xamarin.Forms;

namespace EffectsDemo
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			entry.Effects.Add (Effect.Resolve ("MyCompany.BackgroundColorEffect"));
		}
	}
}

