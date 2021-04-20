using System;
using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace XamFormsImageResize
{
	public class HomePage : ContentPage
	{
#if __IOS__
		public static string ResourcePrefix = "XamFormsImageResize.iOS.";
#endif
#if __ANDROID__
		public static string ResourcePrefix = "XamFormsImageResize.Android.";
#endif
#if WINDOWS_UWP
        public static string ResourcePrefix = "XamFormsImageResize.UWP.";
#endif

		protected StackLayout _mainLayout;
		protected Button _resizeImageButton;
		protected Image _photo;

		public HomePage() : base()
		{
			base.Title = "Home";

			this._mainLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(20, 50)
			};
			this._resizeImageButton = new Button()
			{
				Text = "ResizeImage"
			};
			this._resizeImageButton.Clicked += (object sender, EventArgs e) =>
			{
				this.ResizeImage();
			};

			this._mainLayout.Children.Add(this._resizeImageButton);
			this._photo = new Image();
			this._mainLayout.Children.Add(this._photo);

			this.Content = this._mainLayout;
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();

			var assembly = typeof(HomePage).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames())
				System.Diagnostics.Debug.WriteLine("found resource: " + res);

		}

		protected async void ResizeImage()
		{
			var assembly = typeof(HomePage).GetTypeInfo().Assembly;
			byte[] imageData;

			Stream stream = assembly.GetManifestResourceStream(ResourcePrefix + "OriginalImage.JPG");
			using (MemoryStream ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				imageData = ms.ToArray();
			}

			byte[] resizedImage = await ImageResizer.ResizeImage(imageData, 400, 400);

			this._photo.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage));
		}
	}
}

