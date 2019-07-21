using Xamarin.Forms;

#if __IOS__
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

#if __ANDROID__
using Android.Widget;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using NestPlatformControl.Droid;
#endif

#if WINDOWS_UWP
using System;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
#endif

namespace NestPlatformControl
{
    public class HomePageCS : ContentPage
    {
        public HomePageCS()
        {
            var stackLayout = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Nest Platform Control Demo",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Label { Text = "The controls below the separator have been added to this Xamarin.Forms page using platform-specific controls." },
                    new Separator ()
                }
            };

            Content = new Xamarin.Forms.ScrollView
            {
                Margin = new Xamarin.Forms.Thickness(20, 40, 20, 0),
                Content = stackLayout
            };

#if __IOS__
			const string originalText = "Native UILabel.";
			const string longerText = "Native UILabel. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";
			
			var uiLabel = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = originalText,
			};
			stackLayout.Children.Add (uiLabel);
			
			var uiButton = new UIButton (UIButtonType.RoundedRect);
			uiButton.SetTitle ("Change Text", UIControlState.Normal);
			uiButton.Font = UIFont.FromName ("Helvetica", 14f);
			uiButton.TouchUpInside += (sender, args) => {
				uiLabel.Text = uiLabel.Text == originalText ? longerText : originalText;
				uiLabel.SizeToFit ();
			};
			stackLayout.Children.Add (uiButton);
			
			var explanation1 = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "The next control is a CustomControl (a customized UILabel with a bad SizeThatFits implementation).",
			};
			stackLayout.Children.Add (explanation1);
			
			var brokenControl = new CustomControl {
				MinimumFontSize = 14,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "This control has incorrect sizing - there's empty space above and below it."
			};
			stackLayout.Children.Add (brokenControl);
			
			var explanation2 = new UILabel {
				MinimumFontSize = 14f,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "The next control is a CustomControl, but an override to the GetDesiredSize method is passed in when adding the control to the layout.",
			};
			stackLayout.Children.Add (explanation2);
			
			var fixedControl = new CustomControl {
				MinimumFontSize = 14,
				Lines = 0,
				LineBreakMode = UILineBreakMode.WordWrap,
				Text = "This control has correct sizing - there's no empty space above and below it."
			};
			stackLayout.Children.Add (fixedControl, FixSize);
#endif

#if __ANDROID__
            const string originalText = "Native TextView.";
            const string longerText = "Native TextView. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";

            var textView = new TextView(MainActivity.Instance) { Text = originalText, TextSize = 14 };
            textView.SetSingleLine(false);
            textView.SetLines(3);
            stackLayout.Children.Add(textView);

            var button = new Android.Widget.Button(MainActivity.Instance) { Text = "Change Text" };
            button.Click += (sender, args) =>
            {
                textView.Text = textView.Text == originalText ? longerText : originalText;
            };
            stackLayout.Children.Add(button);

            var explanation1 = new TextView(MainActivity.Instance)
            {
                Text = "The next control is a CustomControl (a customized TextView with a bad OnMeasure implementation).",
                TextSize = 14
            };
            stackLayout.Children.Add(explanation1);

            var brokenControl = new CustomControl(MainActivity.Instance)
            {
                Text = "This control has incorrect sizing - it doesn't occupy the available width of the device.",
                TextSize = 14
            };
            stackLayout.Children.Add(brokenControl);

            var explanation2 = new TextView(MainActivity.Instance)
            {
                Text = "The next control is a CustomControl, but with a custom GetDesiredSize delegate to accomodate it's sizing problem.",
                TextSize = 14
            };
            stackLayout.Children.Add(explanation2);

            var goodControl = new CustomControl(MainActivity.Instance)
            {
                Text = "This control has correct sizing - it occupies the available width of the device.",
                TextSize = 14
            };
            stackLayout.Children.Add(goodControl, FixSize);
#endif

#if WINDOWS_UWP
			const string originalText = "Native TextBlock.";
			const string longerText = "Native TextBlock. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vel elit orci. Nam sollicitudin consectetur congue.";
			
			var textBlock = new TextBlock
			{
			Text = originalText,
			FontSize = 14,
			FontFamily = new FontFamily("HeveticaNeue"),
			TextWrapping = TextWrapping.Wrap
			};
			stackLayout.Children.Add(textBlock);
			
			var button = new Windows.UI.Xaml.Controls.Button { Content = "Change Text" };
			button.Click += (sender, args) => { textBlock.Text = textBlock.Text == originalText ? longerText : originalText; };
			stackLayout.Children.Add(button);
			
			var explanation1 = new TextBlock
			{
			Text = "The next control is a CustomControl (a customized TextBlock with a bad ArrangeOverride implementation).",
			FontSize = 14,
			FontFamily = new FontFamily("HeveticaNeue"),
			TextWrapping = TextWrapping.Wrap
			};
			stackLayout.Children.Add(explanation1);
			
			var brokenControl = new CustomControl { Text = "This control has incorrect sizing - it doesn't occupy the available width of the device." };
			stackLayout.Children.Add(brokenControl);
			
			var explanation2 = new TextBlock
			{
			Text = "The next control is a CustomControl, but an ArrangeOverride delegate is passed in when adding the control to the layout.",
			FontSize = 14,
			FontFamily = new FontFamily("HeveticaNeue"),
			TextWrapping = TextWrapping.Wrap
			};
			stackLayout.Children.Add(explanation2);
			
			var fixedControl = new CustomControl { Text = "This control has correct sizing - it occupies the available width of the device." };
			stackLayout.Children.Add(fixedControl, arrangeOverrideDelegate: (renderer, finalSize) =>
			{
			if (finalSize.Width <= 0 || double.IsInfinity(finalSize.Width))
			{
			return null;
			}
			var frameworkElement = renderer.Control;
			frameworkElement.Arrange(new Rect(0, 0, finalSize.Width * 2, finalSize.Height));
			return finalSize;
			});
#endif
        }

#if __IOS__
		SizeRequest? FixSize (NativeViewWrapperRenderer renderer, double width, double height)
		{
			var uiView = renderer.Control;
		
			if (uiView == null) {
				return null;
			}
		
			var constraint = new CGSize (width, height);
		
			// Let the CustomControl determine its size (which will be wrong)
			var badRect = uiView.SizeThatFits (constraint);
		
			// Use the width and substitute the height
			return new SizeRequest (new Size (badRect.Width, 70));
		}
#endif

#if __ANDROID__
        static SizeRequest? FixSize(NativeViewWrapperRenderer renderer, int widthConstraint, int heightConstraint)
        {
            var nativeView = renderer.Control;

            if ((widthConstraint == 0 && heightConstraint == 0) || nativeView == null)
            {
                return null;
            }

            int width = Android.Views.View.MeasureSpec.GetSize(widthConstraint);
            int widthSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(width * 2, Android.Views.View.MeasureSpec.GetMode(widthConstraint));
            nativeView.Measure(widthSpec, heightConstraint);
            return new SizeRequest(new Size(nativeView.MeasuredWidth, nativeView.MeasuredHeight));
        }
#endif
    }
}

