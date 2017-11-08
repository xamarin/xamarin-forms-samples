using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ImageWrapLayout
{
	public class ImageWrapLayoutPageCS : ContentPage
	{
		WrapLayout wrapLayout;

		public ImageWrapLayoutPageCS()
		{
			wrapLayout = new WrapLayout();

			Content = new ScrollView
			{
				Margin = new Thickness(0, 20, 0, 20),
				Content = wrapLayout
			};
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			var images = await GetImageListAsync();
			foreach (var photo in images.Photos)
			{
				var image = new Image
				{
					Source = ImageSource.FromUri(new Uri(photo + string.Format("?width={0}&height={0}&mode=max", Device.RuntimePlatform == Device.UWP ? 120 : 240)))
				};
				wrapLayout.Children.Add(image);
			}
		}

		async Task<ImageList> GetImageListAsync()
		{
			var requestUri = "https://docs.xamarin.com/demo/stock.json";
			using (var client = new HttpClient())
			{
				var result = await client.GetStringAsync(requestUri);
				return JsonConvert.DeserializeObject<ImageList>(result);
			}
		}
	}
}
