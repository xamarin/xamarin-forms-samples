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

using MonoTouch.Foundation;
using MonoTouch.MessageUI;
using MonoTouch.UIKit;

using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Data;
using EmployeeDirectory.Utilities;
using System.Threading.Tasks;

namespace EmployeeDirectory.iOS
{
	public class PersonViewController : UITableViewController
	{
		PersonViewModel personViewModel;

		static readonly UIKitImageDownloader imageDownloader = new UIKitImageDownloader ();

		public PersonViewController (Person person, IFavoritesRepository favoritesRepository)
			: base (UITableViewStyle.Grouped)
		{
			personViewModel = new PersonViewModel (person, favoritesRepository);

			Title = person.SafeFirstName;

			TableView.DataSource = new PersonDataSource (this);
			TableView.Delegate = new PersonDelegate (this);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			DeselectAll ();
		}

		void DeselectAll ()
		{
			var sel = TableView.IndexPathForSelectedRow;
			if (sel != null) {
				TableView.DeselectRow (sel, true);
			}
		}

		void OnPhoneSelected (string phoneNumber)
		{
            var url = NSUrl.FromString("tel:" + Uri.EscapeDataString(phoneNumber));

            if (UIApplication.SharedApplication.CanOpenUrl(url))
                UIApplication.SharedApplication.OpenUrl(url);
            else
                new UIAlertView("Oops", "Phone is not available", null, "Ok").Show();
		}

		void OnEmailSelected (string emailAddress)
		{
			if (MFMailComposeViewController.CanSendMail) {
                var composer = new MFMailComposeViewController ();
                composer.SetToRecipients(new string[] { emailAddress });
				composer.Finished += (sender, e) => DismissViewController (true, null);
				PresentViewController (composer, true, null);
			} else {
                new UIAlertView("Oops", "Email is not available", null, "Ok").Show();
            }
		}

		void OnTwitterSelected (string twitterName)
		{
			var name = twitterName;
			if (name.StartsWith ("@")) {
				name = name.Substring (1);
			}
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://twitter.com/" + Uri.EscapeDataString (name)));
		}

		void OnUrlSelected (string url)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString (url));
		}

		void OnAddressSelected (string address)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://maps.google.com/maps?q=" + Uri.EscapeDataString (address)));
		}

		void OnPropertySelected (PersonViewModel.Property property)
		{
			switch (property.Type) {
			case PersonViewModel.PropertyType.Phone:
				OnPhoneSelected (property.Value);
				break;
			case PersonViewModel.PropertyType.Email:
				OnEmailSelected (property.Value);
				break;
			case PersonViewModel.PropertyType.Twitter:
				OnTwitterSelected (property.Value);
				break;
			case PersonViewModel.PropertyType.Url:
				OnUrlSelected (property.Value);
				break;
			case PersonViewModel.PropertyType.Address:
				OnAddressSelected (property.Value);
				break;
			}
			DeselectAll ();
		}

		class PersonDelegate : UITableViewDelegate
		{
			PersonViewController controller;
			public PersonDelegate (PersonViewController controller)
			{
				this.controller = controller;
			}
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var section = indexPath.Section;

				if (section == 1) {
					controller.personViewModel.ToggleFavorite ();

					tableView.DeselectRow (indexPath, true);
					tableView.ReloadRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
				}
				else if (section >= 2) {
					var prop = controller.personViewModel.PropertyGroups [section-2].Properties [indexPath.Row];
					controller.OnPropertySelected (prop);
				}
			}

			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				if (indexPath.Section == 0) {
					return 100;
				} else {
					return 44;
				}
			}
		}

		class PersonDataSource : UITableViewDataSource
		{
			static readonly UIColor ValueColor = UIColor.FromRGB (50, 79, 133);

			const string PlaceholderImagePath = "DetailsPlaceholder.jpg";

			static Lazy<UIImage> PlaceholderImage = new Lazy<UIImage> (
				() => UIImage.FromBundle (PlaceholderImagePath));

			const int ImageSize = 88*2;

			PersonViewController controller;

			public PersonDataSource (PersonViewController controller)
			{
				this.controller = controller;
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return controller.personViewModel.PropertyGroups.Count + 2;
			}

			public override int RowsInSection (UITableView tableView, int section)
			{
				if (section < 2)
					return 1;
				else
					return controller.personViewModel.PropertyGroups[section - 2].Properties.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var section = indexPath.Section;

				if (section == 0) {
					var cell = tableView.DequeueReusableCell ("N");
					if (cell == null) {
						cell = new UITableViewCell (UITableViewCellStyle.Default, "N");
						cell.SelectionStyle = UITableViewCellSelectionStyle.None;
						cell.ImageView.Layer.CornerRadius = 6;
						cell.ImageView.Layer.MasksToBounds = true;//.FillMode = 5;
					}

					var person = controller.personViewModel.Person;

					cell.TextLabel.Text = person.SafeDisplayName;

					if (person.HasEmail) {
						var imageUrl = Gravatar.GetImageUrl (controller.personViewModel.Person.Email, ImageSize);

						if (imageDownloader.HasLocallyCachedCopy (imageUrl)) {
							cell.ImageView.Image = (UIImage)imageDownloader.GetImageAsync (imageUrl).Result;
						}
						else {
							cell.ImageView.Image = PlaceholderImage.Value;
							imageDownloader.GetImageAsync (imageUrl).ContinueWith (t => {
								cell.ImageView.Image = (UIImage)t.Result;
							}, TaskScheduler.FromCurrentSynchronizationContext ());
						}
					}

					return cell;
				} else if (section == 1) {
					var cell = tableView.DequeueReusableCell ("F");
					if (cell == null) {
						cell = new UITableViewCell (UITableViewCellStyle.Default, "F");
						cell.TextLabel.TextColor = ValueColor;
					}

					cell.TextLabel.Text = "Favorite";
					cell.Accessory = controller.personViewModel.IsFavorite ?
						UITableViewCellAccessory.Checkmark :
						UITableViewCellAccessory.None;

					return cell;
				} else {
					var cell = tableView.DequeueReusableCell ("C");
					if (cell == null) {
						cell = new UITableViewCell (UITableViewCellStyle.Value2, "C");
					}

					var prop = controller.personViewModel.PropertyGroups [section - 2].Properties [indexPath.Row];

					cell.TextLabel.Text = prop.Name.ToLowerInvariant ();
					cell.DetailTextLabel.Text = prop.Value;

					cell.SelectionStyle = prop.Type == PersonViewModel.PropertyType.Generic ?
						UITableViewCellSelectionStyle.None :
						UITableViewCellSelectionStyle.Blue;

					return cell;
				}
			}
		}
	}
}

