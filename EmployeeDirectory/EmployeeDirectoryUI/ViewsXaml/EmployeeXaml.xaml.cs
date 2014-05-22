using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectoryUI.Xaml
{
	public partial class EmployeeXaml : ContentPage
	{
		private const int ImageSize = 176;

		public EmployeeXaml () 
		{
			InitializeComponent ();	
			NameLabel.Font = Font.BoldSystemFontOfSize (NamedSize.Large);
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			GetImage ();
		}

		private void OnFavoriteClicked (object sender, EventArgs e) 
		{
			var p = (PersonViewModel)BindingContext;
			p.ToggleFavorite ();
			Navigation.PopAsync();
		}

		private void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {

			var property = (PersonViewModel.Property)e.SelectedItem;
			System.Diagnostics.Debug.WriteLine ("Property clicked " + property.Type + " " + property.Value);

			switch (property.Type) {
			case PersonViewModel.PropertyType.Email:
				App.PhoneFeatureService.Email (property.Value);
				break;
			case PersonViewModel.PropertyType.Twitter:
				App.PhoneFeatureService.Tweet (property.Value);
				break;
			case PersonViewModel.PropertyType.Url:
				App.PhoneFeatureService.Browse (property.Value);
				break;
			case PersonViewModel.PropertyType.Phone:
				App.PhoneFeatureService.Call (property.Value);
				break;
			case PersonViewModel.PropertyType.Address:
				App.PhoneFeatureService.Map (property.Value);
				break;
			}
		}

		private void OnCancelClicked (object sender, EventArgs e) 
		{
			Navigation.PopAsync();
		}

		private void GetImage () 
		{
			var personInfo = (PersonViewModel)BindingContext;
			var person = personInfo.Person;

			if (person.HasEmail) {
				var imageUrl = Gravatar.GetImageUrl (person.Email, ImageSize);

				var loader = new UriImageSource ();
				loader.Uri = imageUrl;
				PersonImage.Source = loader;
			}
		}
	}
}