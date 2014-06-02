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
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeDirectory.Data;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;

namespace EmployeeDirectory.ViewModels
{
	public class SearchViewModel : ViewModelBase
	{
		IDirectoryService service;
		Search search;

		public SearchViewModel (IDirectoryService service, Search search)
		{
			if (service == null) throw new ArgumentNullException ("service");
			this.service = service;

			if (search == null) throw new ArgumentNullException ("search");
			this.search = search;

			SetGroupedPeople ();
		}

		#region View Data

		public string Title {
			get {
				if (string.IsNullOrEmpty (search.Name)) {
					return "Search";
				}
				else {
					return System.IO.Path.GetFileName (search.Name);
				}
			}
		}

		public ObservableCollection<PeopleGroup> Groups { get; private set; }
		//HACK: for testing
		public ObservableCollection<Person> People { get; private set; }

		public SearchProperty SearchProperty {
			get { return search.Property; }
			set { search.Property = value; }
		}

		public string SearchText {
			get { return search.Text; }
			set { search.Text = value ?? ""; }
		}

		bool groupByLastName = true;
		public bool GroupByLastName {
			get { return groupByLastName; }
			set {
				if (groupByLastName != value) {
					groupByLastName = value;
					SetGroupedPeople ();
				}
			}
		}

		#endregion

		#region Commands

		CancellationTokenSource lastCancelSource = null;

		public void Search ()
		{
			//
			// Stop previous search
			//
			if (lastCancelSource != null) {
				lastCancelSource.Cancel ();
			}

			//
			// Perform the search
			//
			lastCancelSource = new CancellationTokenSource ();
			var token = lastCancelSource.Token;
			service.SearchAsync (search.Filter, 200, token).ContinueWith (
				t => OnSearchCompleted (SearchText, SearchProperty, t),
				token,
				TaskContinuationOptions.None,
				TaskScheduler.FromCurrentSynchronizationContext ());
		}

		async Task OnSearchCompleted (string searchText, SearchProperty searchProperty, Task<IList<Person>> searchTask)
		{
			if (searchTask.IsFaulted) {
				var ev = Error;
				if (ev != null) {
					ev (this, new ErrorEventArgs (searchTask.Exception));
				}
			} else {
				search.Results = new Collection<Person> (searchTask.Result);
				//HACK: uncomment this
//				await search.Save ();
				SetGroupedPeople ();				

				//HACK: just for testing
				People = new ObservableCollection<Person> (search.Results);

				var ev = SearchCompleted;
				if (ev != null) {
					ev (this, new SearchCompletedEventArgs { 
						SearchText = searchText,
						SearchProperty = searchProperty
					});
				}
			}
		}

		/// <summary>
		/// Groups people by the initial letter of their last name
		/// </summary>
		void SetGroupedPeople ()
		{
			Groups = PeopleGroup.CreateGroups (search.Results, groupByLastName);
			OnPropertyChanged ("Groups");
		}

		#endregion

		#region Events

		public new event EventHandler<ErrorEventArgs> Error;

		public event EventHandler<SearchCompletedEventArgs> SearchCompleted;

		#endregion
	}

	public class SearchCompletedEventArgs : EventArgs
	{
		public string SearchText { get; set; }
		public SearchProperty SearchProperty { get; set; }
	}
}
