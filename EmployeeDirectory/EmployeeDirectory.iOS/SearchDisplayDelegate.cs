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

using MonoTouch.UIKit;

using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory.iOS
{
	public class SearchDisplayDelegate : UISearchDisplayDelegate
	{
		SearchViewModel searchViewModel;

		string lastSearchText = "";
		SearchProperty lastSearchProperty = SearchProperty.All;
		UITableView lastTableView;

		Lazy<ActivityView> activity = new Lazy<ActivityView> (
			() => new ActivityView { Text = "Searching..." });

		public SearchDisplayDelegate (SearchViewModel searchViewModel)
		{
			this.searchViewModel = searchViewModel;

			searchViewModel.SearchCompleted += HandleSearchCompleted;
			searchViewModel.Error += HandleError;
		}

		void HandleError (object sender, ErrorEventArgs e)
		{
			activity.Value.Stop ();
		}

		void HandleSearchCompleted (object sender, SearchCompletedEventArgs e)
		{
			// Only update the UI if these are the results for the last search
			if (e.SearchText == lastSearchText && e.SearchProperty == lastSearchProperty) {

				activity.Value.Stop ();

				if (lastTableView != null) {
					var data = (PeopleGroupsDataSource)lastTableView.DataSource;
					data.Groups = searchViewModel.Groups;
					lastTableView.ReloadData ();
				}
			}
		}

		public override bool ShouldReloadForSearchString (UISearchDisplayController controller, string forSearchString)
		{
			if (string.IsNullOrWhiteSpace (forSearchString)) {
				return true;
			} else {
				searchViewModel.SearchText = forSearchString;

				BeginSearch (controller);
				return false; // We'll search asynchronously
			}
		}

		public override bool ShouldReloadForSearchScope (UISearchDisplayController controller, int forSearchOption)
		{
			switch (forSearchOption) {
			case 0:
				searchViewModel.SearchProperty = SearchProperty.Name;
				break;
			case 1:
				searchViewModel.SearchProperty = SearchProperty.Title;
				break;
			case 2:
				searchViewModel.SearchProperty = SearchProperty.Department;
				break;
			case 3:
				searchViewModel.SearchProperty = SearchProperty.All;
				break;
			}

			BeginSearch (controller);
			return false; // We'll search asynchronously
		}

		void BeginSearch (UISearchDisplayController controller)
		{
			// Remember the search criteria so we can respond only to relevant events
			lastTableView = controller.SearchResultsTableView;
			lastSearchText = searchViewModel.SearchText;
			lastSearchProperty = searchViewModel.SearchProperty;

			// Display an activity indicator
			if (lastTableView != null) {
				if (!activity.Value.IsRunning) {
					activity.Value.StartInView (lastTableView);
				}
				lastTableView.BringSubviewToFront (activity.Value);
			}

			// Begin the search
			searchViewModel.Search ();
		}
	}
}

