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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Globalization;

namespace EmployeeDirectory
{
	public class CsvReader<T>
		where T : new ()
	{
		IFormatProvider formatProvider;
		TextReader reader;

		string[] headerNames;

		public CsvReader (TextReader reader)
		{
			this.formatProvider = CultureInfo.InvariantCulture;
			this.reader = reader;
		}

		public IEnumerable<T> ReadAll ()
		{
			//
			// Associate header names with properties
			//
			headerNames = reader.ReadLine ().Split (',');

			var props = new PropertyInfo[headerNames.Length];
			for (var hi = 0; hi < props.Length; hi++) {
				//var p = typeof(T).GetProperty (headerNames[hi]);
				var p = typeof(T).GetRuntimeProperty (headerNames[hi]);
				if (p == null) throw new Exception (
					"Property '" + headerNames[hi] + "' not found in " + typeof (T).Name);
				props[hi] = p;
			}

			//
			// Read all the records
			//
			var r = new T ();
			var i = 0;

			var ch = reader.Read ();
			while (ch > 0) {
				if (ch == '\n') {
					yield return r;
					r = new T ();
					i = 0;
					ch = reader.Read ();
				}
				else if (ch == '\r') {
					ch = reader.Read ();
				}
				else if (ch == '"') {
					ch = ReadQuoted (r, props[i]);
				}
				else if (ch == ',') {
					i++;
					ch = reader.Read ();
				}
				else {
					ch = ReadNonQuoted (r, props[i], (char)ch);
				}
			}
		}

		int ReadNonQuoted (T r, PropertyInfo prop, char first)
		{
			var sb = new StringBuilder ();

			sb.Append (first);

			var ch = reader.Read ();

			while (ch >= 0 && ch != ',' && ch != '\r' && ch != '\n') {
				sb.Append ((char)ch);
				ch = reader.Read ();
			}

			var valueString = sb.ToString ().Trim ();

			if (typeof(System.Collections.IList).GetTypeInfo().IsAssignableFrom (prop.PropertyType.GetTypeInfo())) {
				var coll = (System.Collections.IList)prop.GetValue (r, null);
				coll.Add (valueString);
			} else {
				prop.SetValue (
					r,
					Convert.ChangeType (
						valueString, 
						prop.PropertyType, 
						formatProvider),
					null);
			}

			return ch;
		}

		int ReadQuoted (T r, PropertyInfo prop)
		{
			var sb = new StringBuilder ();

			var ch = reader.Read ();

			var hasQuote = false;

			while (ch >= 0) {

				if (ch == '"') {
					if (hasQuote) {
						sb.Append ('"');
						hasQuote = false;
					}
					else {
						hasQuote = true;
					}
				}
				else {
					if (hasQuote) {
						prop.SetValue (r, Convert.ChangeType (sb.ToString ().Trim (), prop.PropertyType, formatProvider), null);
						return ch;
					}
					else {
						sb.Append ((char)ch);
					}
				}

				ch = reader.Read ();
			}

			prop.SetValue (r, Convert.ChangeType (sb.ToString ().Trim (), prop.PropertyType, formatProvider), null);
			return ch;
		}
	}
}

