using System;
using Xamarin.Forms;

namespace BasicAnimation
{
	public class RotateAnimationWithAnchorsPageCS : ContentPage
	{
        AbsoluteLayout absoluteLayout;
		Image image;
        Point center;
        double radius;

        public RotateAnimationWithAnchorsPageCS ()
		{
			Title = "Rotate Animation with Anchors";

			image = new Image { Source = ImageSource.FromFile ("monkey.png") };
			image.SizeChanged += OnSizeChanged;
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapped;
            image.GestureRecognizers.Add(tapGestureRecognizer);

			absoluteLayout = new AbsoluteLayout ();
            absoluteLayout.SizeChanged += OnSizeChanged;

			absoluteLayout.Children.Add (image);
            Content = absoluteLayout;
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