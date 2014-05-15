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
using EmployeeDirectory.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EmployeeDirectory.ViewModels
{
	public class PersonViewModel : ViewModelBase
	{
		readonly IFavoritesRepository favoritesRepository;

		public PersonViewModel (Person person, IFavoritesRepository favoritesRepository)
		{
			if (person == null) {
				throw new ArgumentNullException ("person");
			}
			if (favoritesRepository == null) {
				throw new ArgumentNullException ("favoritesRepository");
			}

			Person = person;
			this.favoritesRepository = favoritesRepository;

			PropertyGroups = new ObservableCollection<PropertyGroup> ();

			var general = new PropertyGroup ("General");
			general.Add ("Title", person.Title, PropertyType.Generic);
			general.Add ("Department", person.Department, PropertyType.Generic);
			general.Add ("Company", person.Company, PropertyType.Generic);
			general.Add ("Manager", person.Manager, PropertyType.Generic);
			general.Add ("Description", person.Description, PropertyType.Generic);
			if (general.Properties.Count > 0) {
				PropertyGroups.Add (general);
			}

			var phone = new PropertyGroup ("Phone");
			foreach (var p in person.TelephoneNumbers) {
				phone.Add ("Phone", p, PropertyType.Phone);
			}
			foreach (var p in person.HomeNumbers) {
				phone.Add ("Home", p, PropertyType.Phone);
			}
			foreach (var p in person.MobileNumbers) {
				phone.Add ("Mobile", p, PropertyType.Phone);
			}
			if (phone.Properties.Count > 0) {
				PropertyGroups.Add (phone);
			}

			var online = new PropertyGroup ("Online");
			online.Add ("Email", person.Email, PropertyType.Email);
			online.Add ("WebPage", CleanUrl (person.WebPage), PropertyType.Url);			
			online.Add ("Twitter", CleanTwitter (person.Twitter), PropertyType.Twitter);
			if (online.Properties.Count > 0) {
				PropertyGroups.Add (online);
			}

			var address = new PropertyGroup ("Address");
			address.Add ("Office", person.Office, PropertyType.Generic);
			address.Add ("Address", AddressString, PropertyType.Address);
			if (address.Properties.Count > 0) {
				PropertyGroups.Add (address);
			}
		}

		static string CleanUrl (string url)
		{
			var trimmed = (url ?? "").Trim ();
			if (trimmed.Length == 0) return "";

			var upper = trimmed.ToUpperInvariant ();
			if (!upper.StartsWith ("HTTP")) {
				return "http://" + trimmed;
			}
			else {
				return trimmed;
			}
		}

		static string CleanTwitter (string username)
		{
			var trimmed = (username ?? "").Trim ();
			if (trimmed.Length == 0) return "";

			if (!trimmed.StartsWith ("@")) {
				return "@" + trimmed;
			}
			else {
				return trimmed;
			}
		}

		#region View Data

		public Person Person { get; private set; }

		public ObservableCollection<PropertyGroup> PropertyGroups { get; private set; }

		public bool IsFavorite {
			get { return favoritesRepository.IsFavorite (Person); }
		}
		public bool IsNotFavorite {
			get { return !favoritesRepository.IsFavorite (Person); }
		}

		string AddressString {
			get {
				var sb = new StringBuilder ();
				if (!string.IsNullOrWhiteSpace (Person.Street)) {
					sb.AppendLine (Person.Street.Trim ());
				}
				if (!string.IsNullOrWhiteSpace (Person.POBox)) {
					sb.AppendLine (Person.POBox.Trim ());
				}
				if (!string.IsNullOrWhiteSpace (Person.City)) {
					sb.AppendLine (Person.City.Trim ());
				}
				if (!string.IsNullOrWhiteSpace (Person.State)) {
					sb.AppendLine (Person.State.Trim ());
				}
				if (!string.IsNullOrWhiteSpace (Person.PostalCode)) {
					sb.AppendLine (Person.PostalCode.Trim ());
				}
				if (!string.IsNullOrWhiteSpace (Person.Country)) {
					sb.AppendLine (Person.Country.Trim ());
				}
				return sb.ToString ();
			}
		}

		public class PropertyGroup : IEnumerable<Property>
		{
			public string Title { get; private set; }
			public ObservableCollection<Property> Properties { get; private set; }

			public PropertyGroup (string title)
			{
				Title = title;
				Properties = new ObservableCollection<Property> ();
			}

			public void Add (string name, string value, PropertyType type)
			{
				if (!string.IsNullOrWhiteSpace (value)) {
					Properties.Add (new Property (name, value, type));
				}
			}

			IEnumerator<Property> IEnumerable<Property>.GetEnumerator ()
			{
				return Properties.GetEnumerator ();
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
			{
				return Properties.GetEnumerator ();
			}
		}

		public class Property
		{
			public string Name { get; private set; }
			public string Value { get; private set; }
			public PropertyType Type { get; private set; }

			public Property (string name, string value, PropertyType type)
			{
				Name = name;
				Value = value.Trim ();
				Type = type;
			}

			public override string ToString ()
			{
				return string.Format ("{0} = {1}", Name, Value);
			}
		}

		public enum PropertyType
		{
			Generic,
			Phone,
			Email,
			Url,
			Twitter,
			Address,
		}

		#endregion

		#region Commands

		public void ToggleFavorite ()
		{			
			if (favoritesRepository.IsFavorite (Person)) {
				favoritesRepository.Delete (Person);
			}
			else {
				favoritesRepository.InsertOrUpdate (Person);
			}
			OnPropertyChanged ("IsFavorite");
		}

		#endregion
	}
}

