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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using EmployeeDirectory.Data;
using PCLStorage;

namespace EmployeeDirectory
{
	public class MemoryDirectoryService : IDirectoryService
	{
		List<Person> people;

		Dictionary<string, PropertyInfo> properties;

		public MemoryDirectoryService (IEnumerable<Person> people)
		{
			this.people = people.ToList ();
			this.properties = typeof (Person).GetRuntimeProperties ().ToDictionary (p => p.Name);
		}

		#region IDirectoryService implementation

		public void Dispose ()
		{
		}

		public Task LoginAsync (string username, string password, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew (() => { 
				//Just for testing
				//HACK: Thread.Sleep (2000);
			});
		}

		public Task<IList<Person>> SearchAsync (Filter filter, int sizeLimit, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew (() => {
				var s = Search (filter);
				var list = s.ToList ();
				return (IList<Person>)list;
			}, cancellationToken);
		}

		IEnumerable<Person> Search (Filter filter)
		{
			if (filter is OrFilter) {
				var f = (OrFilter)filter;
				var r = Enumerable.Empty<Person> ();
				foreach (var sf in f.Filters) {
					r = r.Concat (Search (sf));
				}
				return r.Distinct ();
			}
			else if (filter is AndFilter) {
				throw new NotImplementedException ();
			}
			else if (filter is NotFilter) {
				throw new NotImplementedException ();
			}
			else if (filter is EqualsFilter) {
				var f = (EqualsFilter)filter;
				var upper = f.Value.ToUpperInvariant ();
				var prop = properties[f.PropertyName];
				var q = from p in people
						let v = prop.GetValue (p, null)
						where v != null && v.ToString ().ToUpperInvariant () == upper
						select p;
				return q;
			}
			else if (filter is ContainsFilter) {
				var f = (ContainsFilter)filter;
				var re = new Regex (Regex.Escape(f.Value).Replace("\\ ", "|"), RegexOptions.IgnoreCase);
				var prop = properties[f.PropertyName];
				var q = from p in people
						let v = prop.GetValue (p, null)
						where v != null && re.IsMatch (v.ToString ())
						select p;
				return q;
			}
			else {
				throw new NotSupportedException ("Unsupported filter type: " + filter.GetType ());
			}
		}

		#endregion

		#region File IO

		public async static Task<MemoryDirectoryService> FromCsv (string path)
		{
			IFolder store = FileSystem.Current.LocalStorage;
			IFile file = await store.GetFileAsync (path);

			using (var reader = new StreamReader(await file.OpenAsync(FileAccess.Read))) {
				return FromCsv (reader);
			}
		}

		public static MemoryDirectoryService FromCsv (TextReader textReader)
		{
			var reader = new CsvReader<Person> (textReader);
			return new MemoryDirectoryService (reader.ReadAll ());
		}

		#endregion
	}
}

