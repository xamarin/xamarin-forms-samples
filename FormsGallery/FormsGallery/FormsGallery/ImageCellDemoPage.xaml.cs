using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class ImageCellDemoPage
	{
		public ImageCellDemoPage()
		{
			InitializeComponent();
		}

		public ImageSource ImageSource
		{
			get
			{
				// There MUST be a better way of doing this. ;)
				return Device.OnPlatform( ImageSource.FromUri( new Uri( "http://xamarin.com/images/index/ide-xamarin-studio.png" ) ),
					ImageSource.FromFile( "ide_xamarin_studio.png" ),
					ImageSource.FromFile( "Images/ide-xamarin-studio.png" ) );
			}
		}
	}
}