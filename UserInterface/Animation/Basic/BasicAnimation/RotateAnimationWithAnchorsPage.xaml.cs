using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public partial class RotateAnimationWithAnchorsPage : ContentPage
	{
        Point center;
        double radius;

		public RotateAnimationWithAnchorsPage ()
		{
			InitializeComponent ();
		}

        void OnSizeChanged(object sender, EventArgs e)
        {
            center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
            radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;
            AbsoluteLayout.SetLayoutBounds(image,
                new Rectangle(center.X - image.Width / 2, center.Y - radius, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }

		async void OnImageTapped(object sender, EventArgs e)
		{
            image.Rotation = 0;
            image.AnchorY = radius / image.Height;
            await image.RotateTo(360, 2000);
		}
	}
}

