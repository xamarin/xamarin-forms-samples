//
//  Copyright 2012, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.Windows;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Shell;
using System.Linq;
using EmployeeDirectory.Utilities;
using EmployeeDirectory.WinPhone.Utilities;

namespace EmployeeDirectory.WinPhone
{
	public partial class PersonPage : PhoneApplicationPage
	{
		public PersonPage ()
		{
			InitializeComponent ();
		}

		protected override void OnNavigatedTo (System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo (e);

			// Find the person
			var id = NavigationContext.QueryString ["id"];

			var person = App.Current.FavoritesRepository.FindById (id);
			if (person == null) {
				person = App.Current.SavedSearch.Results.FirstOrDefault (x => x.Id == id);
			}

			// If we found them, display their details
			if (person != null) {
				var vm = new PersonViewModel (person, App.Current.FavoritesRepository);
				vm.PropertyChanged += delegate {
					UpdateFavoriteButtonIcon ();
				};
				DataContext = vm;
				UpdateFavoriteButtonIcon ();
			}
		}

		PersonViewModel ViewModel { get { return (PersonViewModel)DataContext; } }

		void UpdateFavoriteButtonIcon ()
		{
			if (ViewModel == null) return;

			if (ViewModel.IsFavorite) {
				((ApplicationBarIconButton)ApplicationBar.Buttons [0]).IconUri = new Uri ("/Images/appbar.favs.removefrom.rest.png", UriKind.RelativeOrAbsolute);
				((ApplicationBarIconButton)ApplicationBar.Buttons [0]).Text = "remove";
			}
			else {
				((ApplicationBarIconButton)ApplicationBar.Buttons [0]).IconUri = new Uri ("/Images/appbar.favs.addto.rest.png", UriKind.RelativeOrAbsolute);
				((ApplicationBarIconButton)ApplicationBar.Buttons [0]).Text = "favorite";
			}
		}

		void OnAddressTap (string address)
		{
			var task = new BingMapsTask () {
				SearchTerm = address,
			};
			task.Show ();
		}

		void OnPhoneTap (string phoneNumber)
		{
			var task = new PhoneCallTask () {
				PhoneNumber = phoneNumber,
			};
			task.Show ();
		}

		void OnEmailTap (string to)
		{
			var task = new EmailComposeTask () {
				To = to,
			};
			task.Show ();
		}

		void OnUrlTap (Uri url)
		{
			var task = new WebBrowserTask () {
				Uri = url,
			};
			task.Show ();
		}

		void OnTwitterTap (string username)
		{
			var task = new WebBrowserTask () {
				Uri = new Uri ("http://twitter.com/" + username.Substring (1), UriKind.Absolute),
			};
			task.Show ();
		}

		void OnPropertyTap (object sender, System.Windows.Input.GestureEventArgs e)
		{
			var prop = ((FrameworkElement)sender).DataContext as PersonViewModel.Property;
			if (prop == null) return;

			switch (prop.Type) {
				case PersonViewModel.PropertyType.Address:
					OnAddressTap (prop.Value);
					break;
				case PersonViewModel.PropertyType.Phone:
					OnPhoneTap (prop.Value);
					break;
				case PersonViewModel.PropertyType.Email:
					OnEmailTap (prop.Value);
					break;
				case PersonViewModel.PropertyType.Url:
					OnUrlTap (new Uri (prop.Value));
					break;
				case PersonViewModel.PropertyType.Twitter:
					OnTwitterTap (prop.Value);
					break;
			}
		}

		private void OnFavoriteClick (object sender, EventArgs e)
		{
			if (ViewModel == null) return;

			ViewModel.ToggleFavorite ();
		}

		private void OnPinClick (object sender, EventArgs e)
		{
			if (ViewModel == null) return;

			var person = ViewModel.Person;
			
			// Download an image for the tile,
			// once that is done we create the tile
			if (person.HasEmail) {
				var image = new System.Windows.Media.Imaging.BitmapImage ();
				image.ImageOpened += delegate {
					var imageUri = image.SaveAsTile ("Person-" + Uri.EscapeDataString (person.Id));
					CreateTile (person, imageUri);
				};
				image.ImageFailed += delegate {
					CreateTile (person, null);
				};
				image.CreateOptions = System.Windows.Media.Imaging.BitmapCreateOptions.None;
				image.UriSource = Gravatar.GetImageUrl (person.Email, 173);
			}
			else {
				CreateTile (person, null);
			}
		}

		void CreateTile (Person person, Uri imageUri)
		{
			var uri = "/PersonPage.xaml?id=" + Uri.EscapeDataString (person.Id);

			// Make sure they are in our favorites list
			if (!ViewModel.IsFavorite) {
				ViewModel.ToggleFavorite ();
			}

			// Delete any old tile
			var foundTile = ShellTile.ActiveTiles.FirstOrDefault (x => x.NavigationUri.ToString ().Contains (uri));

			if (foundTile != null) {
				foundTile.Delete ();
			}

			// Create the new tile
			var tile = new StandardTileData {
				Title = person.SafeDisplayName,
				BackContent = person.TitleAndDepartment,
				BackTitle = person.SafeDisplayName,
				BackgroundImage = (imageUri != null) ? imageUri : new Uri ("/Background.png", UriKind.RelativeOrAbsolute),
			};

			ShellTile.Create (new Uri (uri, UriKind.Relative), tile);
		}
	}
}
