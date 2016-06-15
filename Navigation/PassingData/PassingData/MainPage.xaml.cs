using System;
using Xamarin.Forms;

namespace PassingData
{
	public partial class MainPage : ContentPage
	{
		public MainPage (string date)
		{
			InitializeComponent ();

			dateLabel.Text = date;
		}

		async void OnNavigateButtonClicked (object sender, EventArgs e)
		{
			var contact = new Contact {
				Name = "Jane Doe",
				Age = 30,
				Occupation = "Developer",
				Country = "USA"
			};

			var secondPage = new SecondPage ();
			secondPage.BindingContext = contact;
			await Navigation.PushAsync (secondPage);
		}
	}
}
