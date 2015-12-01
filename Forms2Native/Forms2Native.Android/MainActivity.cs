using Android.App;
using Android.OS;

using Xamarin.Forms;

namespace Forms2Native
{
	/// <summary>
	/// Android app starts with Xamarin.Forms, then opens a natively rendered Page
	/// </summary>
	[Activity (Label = "Forms2Native", MainLauncher = true)]
	public class Activity1 : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Forms.Init (this, bundle);

			LoadApplication (new App ());

			MessagingCenter.Subscribe<MyFirstPage, NativeNavigationArgs>(
				this,
				App.NativeNavigationMessage,
				HandleNativeNavigationMessage);
		}

		private void HandleNativeNavigationMessage(MyFirstPage sender, NativeNavigationArgs args)
		{
			StartActivity(typeof(MyThirdActivity));
		}
	}
}
