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

namespace EmployeeDirectory
{
	/// <summary>
	/// Filter used to search an <see cref="IDirectoryService"/>.
	/// </summary>
	public abstract class Filter
	{
		/// <summary>
		/// Combines this filter with another using an AND relation.
		/// </summary>
		/// <remarks>
		/// This is a convenience function for creating an <see cref="AndFilter"/>.
		/// </remarks>
		/// <param name='filter'>
		/// The other filter in the AND relationship.
		/// </param>
		public AndFilter And (Filter filter)
		{
			if (filter == null) throw new ArgumentNullException ("filter");
			return new AndFilter (this, filter);
		}

		/// <summary>
		/// Combines this filter with another using an OR relation.
		/// </summary>
		/// <remarks>
		/// This is a convenience function for creating an <see cref="AndFilter"/>.
		/// </remarks>
		/// <param name='filter'>
		/// The other filter in the OR relationship.
		/// </param>
		public OrFilter Or (Filter filter)
		{
			if (filter == null) throw new ArgumentNullException ("filter");
			return new OrFilter (this, filter);
		}

		/// <summary>
		/// Negates this filter.
		/// </summary>
		/// <remarks>
		/// This is a convenience function for creating a <see cref="NotFilter"/>.
		/// </remarks>
		public NotFilter Not ()
		{
			return new NotFilter (this);
		}
	}

	/// <summary>
	/// Filter that enforces an AND relation on all its <see cref="Filters"/>.
	/// </summary>
	public class AndFilter : Filter
	{
		/// <summary>
		/// The list of filters that must all be true for this filter to be true.
		/// </summary>
		public List<Filter> Filters { get; set; }

		public AndFilter ()
		{
			Filters = new List<Filter> ();
		}

		public AndFilter (params Filter[] filters)
		{
			if (filters == null) throw new ArgumentNullException ("filters");
			Filters = new List<Filter> (filters);
		}
	}

	public class OrFilter : Filter
	{
		public List<Filter> Filters { get; set; }

		public OrFilter ()
		{
			Filters = new List<Filter> ();
		}

		public OrFilter (params Filter[] filters)
		{
			if (filters == null) throw new ArgumentNullException ("filters");
			Filters = new List<Filter> (filters);
		}
	}

	public class NotFilter : Filter
	{
		public Filter InnerFilter { get; set; }

		public NotFilter ()
		{
		}

		public NotFilter (Filter innerFilter)
		{
			if (innerFilter == null) throw new ArgumentNullException ("innerFilter");
			InnerFilter = innerFilter;
		}
	}

	public class EqualsFilter : Filter
	{
		public string PropertyName { get; set; }
		public string Value { get; set; }

		public EqualsFilter ()
		{
			PropertyName = "";
			Value = "";
		}

		public EqualsFilter (string propertyName, string value)
		{
			PropertyName = propertyName;
			Value = value;
		}
	}

	public class ContainsFilter : Filter
	{
		public string PropertyName { get; set; }
		public string Value { get; set; }

		public ContainsFilter ()
		{
			PropertyName = "";
			Value = "";
		}

		public ContainsFilter (string propertyName, string value)
		{
			PropertyName = propertyName;
			Value = value;
		}
	}
}

