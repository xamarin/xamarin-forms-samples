using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class ImageDemoPage
	{
		public ImageDemoPage()
		{
			InitializeComponent();
		}

		public ImageSource ImageSource
		{
			get
			{
				return Device.OnPlatform( ImageSource.FromUri( new Uri( "http://xamarin.com/images/index/ide-xamarin-studio.png" ) ),
					ImageSource.FromFile( "ide_xamarin_studio.png" ),
					ImageSource.FromUri( new Uri( "http://xamarin.com/images/index/ide-xamarin-studio.png" ) ) );
			}
		}
	}
}
