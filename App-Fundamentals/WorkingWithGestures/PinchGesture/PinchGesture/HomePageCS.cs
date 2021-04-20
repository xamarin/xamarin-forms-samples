using Xamarin.Forms;

namespace PinchGesture
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			Content = new Grid {
				Padding = new Thickness (20),
				Children = {
					new PinchToZoomContainer {
						Content = new Image { Source = ImageSource.FromFile ("waterfront.jpg") }
					}	
				}
			};
		}
	}
}
