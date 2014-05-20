using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Utilities;
using System.Diagnostics;

namespace EmployeeDirectoryCSharp
{
	public class EmployeeView : ContentPage
	{
		private const int IMAGE_SIZE = 176;
		private Image photo;

		public EmployeeView ()
		{
			Title = "Employee";

			photo = new Image { WidthRequest = IMAGE_SIZE, HeightRequest = IMAGE_SIZE };
			photo.SetBinding (Image.SourceProperty, "DetailsPlaceholder.jpg");

			var nameLabel = new Label { Font = Font.BoldSystemFontOfSize (NamedSize.Large) };
			nameLabel.SetBinding (Label.TextProperty, "Person.Name");

			var removeButton = new Button { Text = "Remove Favorite" };
			removeButton.Clicked += OnFavoriteClicked;
			removeButton.SetBinding (Button.IsVisibleProperty, "Path=Person.IsFavorite");

			var addButton = new Button { Text = "Add Favorite" };
			addButton.Clicked += OnFavoriteClicked;
			addButton.SetBinding (Button.IsVisibleProperty, "Path=Person.IsNotFavorite");

			var optionsView = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, removeButton, addButton }
			};

			var headerView = new StackLayout {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { photo, optionsView }
			};

			var listView = new ListView { IsGroupingEnabled = true };
			listView.ItemSelected += OnItemSelected;
			listView.SetBinding (ListView.ItemSourceProperty, "PropertyGroups");
			listView.GroupHeaderTemplate = new DataTemplate (typeof(GroupHeaderTemplate));
			listView.ItemTemplate = new DataTemplate (typeof(DetailsItemTemplate));

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { headerView, listView }
			};
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			DownloadImage ();
		}

		private void OnFavoriteClicked (object sender, EventArgs e)
		{
			var personInfo = (PersonViewModel)BindingContext;
			personInfo.ToggleFavorite ();
			Navigation.Pop ();
		}

		private void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var property = (PersonViewModel.Property)e.SelectedItem;
			Debug.WriteLine (string.Format ("Property clicked {0} {1}", property.Type, property.Value));

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
			Navigation.Pop ();
		}

		private void DownloadImage ()
		{
			var personInfo = (PersonViewModel)BindingContext;
			var person = personInfo.Person;

			if (person.HasEmail) {
				var imageUrl = Gravatar.GetImageUrl (person.Email, IMAGE_SIZE);

				var loader = new ImageLoader { Uri = imageUrl };
				photo.Source = loader;
			}
		}
	}
}