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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.iOS
{
	public class PeopleGroupsDataSource : UITableViewDataSource
	{
		const string PlaceholderImagePath = "Placeholder.jpg";

		public ObservableCollection<PeopleGroup> Groups { get; set; }

		public PeopleGroupsDataSource (ObservableCollection<PeopleGroup> groups)
		{
			if (groups == null) {
				throw new ArgumentNullException ("groups");
			}
			Groups = groups;
		}

		public Person GetPerson (NSIndexPath indexPath)
		{
			try
			{
				var personGroup = Groups [indexPath.Section];
				return personGroup.People[indexPath.Row];
			}
			catch (Exception exc)
			{
				Console.WriteLine ("Error in GetPerson: " + exc.Message);

				//Occasionally we get an index out of range here
				return null;
			}
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return Groups [section].Title;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return Groups.Select (x => x.Title).ToArray ();
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return Groups.Count;
		}

		public override int RowsInSection (UITableView tableView, int section)
		{
			return Groups [section].People.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("P") as PersonCell;
			if (cell == null) {
				cell = new PersonCell ("P");
			}

			var person = GetPerson (indexPath);
			if (person != null) {
				cell.Person = person;

				UIImage image;
				if (images.TryGetValue (person.Id, out image)) {
					cell.ImageView.Image = image;
				} else {
					if (!tableView.Dragging && !tableView.Decelerating && person.HasEmail) {
						StartImageDownload (tableView, indexPath, person);
					}
					cell.ImageView.Image = UIImage.FromBundle (PlaceholderImagePath);
				}
			}

			return cell;
		}

		#region Image Support

		readonly Dictionary<string, UIImage> images = new Dictionary<string, UIImage> ();
		readonly List<string> imageDownloadsInProgress = new List<string> ();
		readonly ImageDownloader imageDownloader = new UIKitImageDownloader ();

		public void LoadImagesForOnscreenRows (UITableView tableView)
		{
			if (Groups.Count > 0) {

				var visiblePaths = tableView.IndexPathsForVisibleRows;

				foreach (var indexPath in visiblePaths) {
					var person = ((PeopleGroupsDataSource)tableView.DataSource).GetPerson (indexPath);
					if (person != null) {
						if (person.HasEmail) {
							if (!images.ContainsKey (person.Id)) {
								StartImageDownload (tableView, indexPath, person);
							}
						}
						else {
							FinishImageDownload (tableView, indexPath, person, UIImage.FromBundle (PlaceholderImagePath));
						}
					}
				}
			}
		}

		void StartImageDownload (UITableView tableView, NSIndexPath indexPath, Person person)
		{
			if (imageDownloadsInProgress.Contains (person.Id)) return;
			imageDownloadsInProgress.Add (person.Id);

			imageDownloader.GetImageAsync (Gravatar.GetImageUrl (person.Email, 88)).ContinueWith (t => {
				if (!t.IsFaulted) {
					FinishImageDownload (tableView, indexPath, person, (UIImage)t.Result);
				}
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}

		void FinishImageDownload (UITableView tableView, NSIndexPath indexPath, Person person, UIImage image)
		{
			images [person.Id] = image;
			imageDownloadsInProgress.Remove (person.Id);

			if (indexPath.Section < Groups.Count &&
			    indexPath.Row < Groups [indexPath.Section].People.Count) {

				var cell = tableView.CellAt (indexPath);
				if (cell != null) {
					cell.ImageView.Image = image;
				}
			}
		}

		#endregion
	}
}

