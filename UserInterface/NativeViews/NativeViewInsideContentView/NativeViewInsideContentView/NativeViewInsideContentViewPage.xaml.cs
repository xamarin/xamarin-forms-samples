using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NativeViewInsideContentView
{
	public partial class NativeViewInsideContentViewPage : ContentPage
	{
		public NativeViewInsideContentViewPage()
		{
			InitializeComponent();

#if __IOS__
			var wrapper = (Xamarin.Forms.Platform.iOS.NativeViewWrapper)contentViewButtonParent.Content;
			var button = (UIKit.UIButton)wrapper.NativeView;
			button.SetTitle("Scale and Rotate Text", UIKit.UIControlState.Normal);
			button.SetTitleColor(UIKit.UIColor.Black, UIKit.UIControlState.Normal);
#endif

#if __ANDROID__
			var wrapper = (Xamarin.Forms.Platform.Android.NativeViewWrapper)contentViewTextParent.Content;
			var textView = (Android.Widget.TextView)wrapper.NativeView;
			textView.SetTextColor(Android.Graphics.Color.Red);
#endif
#if WINDOWS_UWP
            var textWrapper = (Xamarin.Forms.Platform.UWP.NativeViewWrapper)contentViewTextParent.Content;
            var textBlock = (Windows.UI.Xaml.Controls.TextBlock)textWrapper.NativeElement;
            textBlock.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
			var buttonWrapper = (Xamarin.Forms.Platform.UWP.NativeViewWrapper)contentViewButtonParent.Content;
			var button = (Windows.UI.Xaml.Controls.Button)buttonWrapper.NativeElement;
            button.Click += (sender, args) => OnButtonTap(sender, EventArgs.Empty);
#endif
		}

		async void OnButtonTap(object sender, EventArgs e)
		{
			contentViewButtonParent.Content.IsEnabled = false;
			contentViewTextParent.Content.ScaleTo(2, 2000);
			await contentViewTextParent.Content.RotateTo(360, 2000);
			contentViewTextParent.Content.ScaleTo(1, 2000);
			await contentViewTextParent.Content.RelRotateTo(360, 2000);
			contentViewButtonParent.Content.IsEnabled = true;
		}
	}
}
