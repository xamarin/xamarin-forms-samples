using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory
{
	public partial class EmployeeXaml : ContentPage
	{
		public EmployeeXaml () {
			InitializeComponent ();	

			NameLabel.Font = Font.BoldSystemFontOfSize (NamedSize.Large);
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			GetImage ();
		}

		void OnFavoriteClicked (object sender, EventArgs e) {
			var p = (PersonViewModel)BindingContext;
			p.ToggleFavorite ();
			this.Navigation.Pop();
		}

		void OnItemSelected (object sender, EventArg<object> e) {

			var property = (PersonViewModel.Property)e.Data;
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

		void OnCancelClicked (object sender, EventArgs e) {
			this.Navigation.Pop();
		}

		const int ImageSize = 88*2; //176

		void GetImage () {
			var p = (PersonViewModel)BindingContext;
			var person = p.Person;

			if (person.HasEmail) {
				var imageUrl = Gravatar.GetImageUrl (person.Email, ImageSize);

				var loader = new ImageLoader ();
				loader.Uri = imageUrl;
				PersonImage.Source = loader;
			}
		}
	}
}