using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class SearchBarDemoPage
	{
		public SearchBarDemoPage()
		{
			InitializeComponent();
		}

		public string Results
		{
			get { return (string)GetValue( ResultsProperty ); }
			set { SetValue( ResultsProperty, value ); }
		}	public static readonly BindableProperty ResultsProperty = BindableProperty.Create( "Results", typeof(string), typeof (SearchBarDemoPage), default(string) );

		void SearchBar_OnSearchButtonPressed( object sender, EventArgs e )
		{
			// Get the search text.
			var searchBar = (SearchBar)sender;

			Results = DetermineResults( searchBar.Text );
		}

		string DetermineResults( string text )
		{
			 // Get Xamarin.Forms assembly.
			var xamarinFormsAssembly = typeof(View).GetTypeInfo().Assembly;

			// Loop through all the types.
			var list = ( from type in xamarinFormsAssembly.ExportedTypes 
						 let typeInfo = type.GetTypeInfo() 
						 where typeInfo.IsPublic 
						 from property in typeInfo.DeclaredProperties 
						 where property.Name.StartsWith( text ) 
						 select property ).ToList();

			var result = list.Any() ? Parse( list ) : string.Format( "No Xamarin.Forms properties with the name of '{0}' were found", text );
			return result;
		}

		static string Parse( IEnumerable<PropertyInfo> items )
		{
			var texts = items.Select( item => string.Format( "{0} type defines a property named '{1}' of type {2}",
				item.DeclaringType.Name, item.Name, item.PropertyType.Name ) );
			var message = string.Join( "; and the ", texts );
			var result = string.Format( "The {0}.", message );
			return result;
		}
	}
}
