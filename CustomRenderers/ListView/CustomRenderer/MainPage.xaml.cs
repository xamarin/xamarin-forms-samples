using Xamarin.Forms;

namespace CustomRenderer
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			nativeListView.Items = DataSource.GetList ();
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushModalAsync (new DetailPage (e.SelectedItem));
		}
	}
}
