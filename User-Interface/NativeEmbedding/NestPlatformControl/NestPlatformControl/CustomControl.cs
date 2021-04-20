#if __IOS__
using UIKit;
using CoreGraphics;
#endif

#if __ANDROID__
using Android.Content;
using Android.Views;
using Android.Widget;
#endif

#if WINDOWS_UWP
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

namespace NestPlatformControl
{
	#if __IOS__
	public class CustomControl : UILabel
	{
		public override string Text {
			get { return base.Text; }
			set { base.Text = value.ToUpper (); }
		}

		public override CGSize SizeThatFits (CGSize size)
		{
			return new CGSize (size.Width, 150);
		}
	}
	#endif

	#if __ANDROID__
	public class CustomControl : TextView
	{
		public CustomControl (Context context) : base (context)
		{
		}

		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			int width = MeasureSpec.GetSize (widthMeasureSpec);

			// Force the width to half of what's been requested. 
			// This is deliberately wrong in order to demonstrate providing an override to fix it with.
			int widthSpec = MeasureSpec.MakeMeasureSpec (width / 2, MeasureSpec.GetMode (widthMeasureSpec));

			base.OnMeasure (widthSpec, heightMeasureSpec);
		}
	}
	#endif

	#if WINDOWS_UWP
    public class CustomControl : Panel
    {
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(CustomControl), new PropertyMetadata(default(string), OnTextPropertyChanged));
		
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value.ToUpper()); }
        }

        readonly TextBlock textBlock;

        public CustomControl()
        {
            textBlock = new TextBlock
            {
                MinHeight = 0,
                MaxHeight = double.PositiveInfinity,
                MinWidth = 0,
                MaxWidth = double.PositiveInfinity,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center
            };

            Children.Add(textBlock);
        }

        static void OnTextPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            ((CustomControl)dependencyObject).textBlock.Text = (string)args.NewValue;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
			// This is deliberately wrong in order to demonstrate providing an override to fix it with.
            textBlock.Arrange(new Rect(0, 0, finalSize.Width / 2, finalSize.Height));
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            textBlock.Measure(availableSize);
            return new Size(textBlock.DesiredSize.Width, textBlock.DesiredSize.Height);   
        }
    }

#endif
}
