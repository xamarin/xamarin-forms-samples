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
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using PCLStorage; // ported from IsolatedStorage

namespace EmployeeDirectory.Data
{
	/// <summary>
	/// Represents a saved search: a filter and the latest results.
	/// </summary>
	public class Search
	{
		public string Name { get; set; }

		public string Text { get; set; }

		public SearchProperty Property { get; set; }

		public Collection<Person> Results { get; set; }

		public Search ()
			: this ("")
		{
		}

		public Search (string name)
		{
			this.Name = name;
			this.Text = "";
			this.Property = SearchProperty.Name;
			this.Results = new Collection<Person> ();
		}

		public Filter Filter
		{
			get
			{
				var trimmed = Text.Trim ();
				if (Property == SearchProperty.All) {
					return new OrFilter (
						new ContainsFilter ("Name", trimmed),
						new ContainsFilter ("Title", trimmed),
						new ContainsFilter ("Department", trimmed));
				}
				else {
					var propName = Property.ToString ();
					return new ContainsFilter (propName, trimmed);
				}
			}
		}

		public async static Task<Search> Open (string name)
		{
			if (string.IsNullOrWhiteSpace (name)) {
				throw new ArgumentException ("Name must be given.", "name");
			}

			IFolder store = FileSystem.Current.LocalStorage;
			//var store = IsolatedStorageFile.GetUserStoreForApplication ();
			var serializer = new XmlSerializer (typeof (Search));

			IFile file = await store.GetFileAsync (name);
			using (var stream = new StreamReader(await file.OpenAsync(FileAccess.Read))) {
				var s = (Search)serializer.Deserialize (stream);
				s.Name = name;
				return s;
			}
		}

		public async Task Save ()
		{
			if (string.IsNullOrWhiteSpace (Name)) {
				throw new InvalidOperationException ("Name must be set.");
			}

			IFolder store = FileSystem.Current.LocalStorage;
			//var store = IsolatedStorageFile.GetUserStoreForApplication ();
			var serializer = new XmlSerializer (typeof (Search));

			IFile file = await store.GetFileAsync (Name);
			using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite)) {
				serializer.Serialize (stream, this);
			}
		}
	}
}

