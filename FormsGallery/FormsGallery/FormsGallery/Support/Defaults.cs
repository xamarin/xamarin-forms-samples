using System;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public static class Defaults
	{
		public static Color Color
		{
			get { return Device.OnPlatform( Color.Black, Color.Default, Color.Default );  }
		}

		public static ImageSource Image
		{
			get
			{
				 // Some differences with loading images in initial release.
				return Device.OnPlatform( ImageSource.FromUri( new Uri( "http://xamarin.com/images/index/ide-xamarin-studio.png" ) ),
					ImageSource.FromFile( "ide_xamarin_studio.png" ),
					ImageSource.FromFile( "Images/ide-xamarin-studio.png" ) );
			}
		}
	}
}