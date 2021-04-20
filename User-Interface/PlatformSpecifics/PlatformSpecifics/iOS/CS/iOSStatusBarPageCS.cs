using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
	public class iOSStatusBarPageCS : ContentPage
	{
		public iOSStatusBarPageCS()
		{
			On<iOS>().SetPrefersStatusBarHidden(StatusBarHiddenMode.True)
					 .SetPreferredStatusBarUpdateAnimation(UIStatusBarAnimation.Fade);

			var statusBarHiddenButton = new Button { Text = "Toggle PrefersStatusBarHidden " };
			var statusBarAnimationButton = new Button { Text = "Toggle PreferredStatusBarUpdateAnimation " };

			statusBarHiddenButton.Clicked += (sender, e) =>
			{
				switch (On<iOS>().PrefersStatusBarHidden())
				{
					case StatusBarHiddenMode.Default:
						On<iOS>().SetPrefersStatusBarHidden(StatusBarHiddenMode.True);
						break;
					case StatusBarHiddenMode.True:
						On<iOS>().SetPrefersStatusBarHidden(StatusBarHiddenMode.False);
						break;
					case StatusBarHiddenMode.False:
						On<iOS>().SetPrefersStatusBarHidden(StatusBarHiddenMode.Default);
						break;
				}
			};

			statusBarAnimationButton.Clicked += (sender, e) =>
			{
				switch (On<iOS>().PreferredStatusBarUpdateAnimation())
				{
					case UIStatusBarAnimation.None:
						On<iOS>().SetPreferredStatusBarUpdateAnimation(UIStatusBarAnimation.Fade);
						break;
					case UIStatusBarAnimation.Fade:
						On<iOS>().SetPreferredStatusBarUpdateAnimation(UIStatusBarAnimation.Slide);
						break;
					case UIStatusBarAnimation.Slide:
						On<iOS>().SetPreferredStatusBarUpdateAnimation(UIStatusBarAnimation.None);
						break;
				}
			};

			Title = "Hide Status Bar";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = { statusBarHiddenButton, statusBarAnimationButton }
			};
		}
	}
}
