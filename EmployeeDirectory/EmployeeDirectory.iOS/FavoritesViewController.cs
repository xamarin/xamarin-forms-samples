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
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using System.Drawing;

namespace EmployeeDirectory.iOS
{
	public class FavoritesViewController : UITableViewController
	{
		IFavoritesRepository favoritesRepository;
		FavoritesViewModel viewModel;
		SearchViewModel searchViewModel;

		UISearchBar searchBar;

		UISearchDisplayController searchController;

		public FavoritesViewController (IFavoritesRepository favoritesRepository, IDirectoryService service, Search savedSearch)
		{
			this.favoritesRepository = favoritesRepository;

			Title = "Favorites";

			viewModel = new FavoritesViewModel (favoritesRepository, groupByLastName: true);
			viewModel.PropertyChanged += HandleViewModelPropertyChanged;

			searchViewModel = new SearchViewModel (service, savedSearch);

			//
			// Configure this view
			//
			var favoritesDelegate = new PeopleGroupsDelegate (TableView);
			favoritesDelegate.PersonSelected += HandlePersonSelected;

			TableView.DataSource = new PeopleGroupsDataSource (viewModel.Groups);
			TableView.Delegate = favoritesDelegate;
			TableView.SectionIndexMinimumDisplayRowCount = 10;

			//
			// Configure the search bar
			//
			searchBar = new UISearchBar (new RectangleF (0, 0, 320, 44)) {
				ShowsScopeBar = true,
			};
			searchBar.ScopeButtonTitles = new[] { "Name", "Title", "Dept", "All" };

			searchController = new UISearchDisplayController (searchBar, this) {
				SearchResultsDataSource = new PeopleGroupsDataSource (searchViewModel.Groups),
				Delegate = new SearchDisplayDelegate (searchViewModel),
			};
			var searchDelegate = new PeopleGroupsDelegate (searchController.SearchResultsTableView);
			searchController.SearchResultsTableView.SectionIndexMinimumDisplayRowCount = 10;
			searchDelegate.PersonSelected += HandleSearchPersonSelected;
			searchController.SearchResultsDelegate = searchDelegate;

			TableView.TableHeaderView = searchBar;
		}

		void HandleViewModelPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Groups") {
				((PeopleGroupsDataSource)TableView.DataSource).Groups = viewModel.Groups;
				TableView.ReloadData ();
			}
		}

		void HandlePersonSelected (object sender, PersonSelectedEventArgs e)
		{
			var personViewController = new PersonViewController (e.Person, favoritesRepository);

			NavigationController.PushViewController (personViewController, true);
		}

		void HandleSearchPersonSelected (object sender, PersonSelectedEventArgs e)
		{
			var personViewController = new PersonViewController (e.Person, favoritesRepository);

			personViewController.NavigationItem.RightBarButtonItem =
				new UIBarButtonItem (UIBarButtonSystemItem.Done, delegate {
				DismissViewController (true, null);
			});

			PresentViewController (new UINavigationController (personViewController), true, null);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			//
			// Deselect all cells when appearing
			//
			var sel = TableView.IndexPathForSelectedRow;
			if (sel != null) {
				TableView.DeselectRow (sel, true);
			}
		}
	}
}

