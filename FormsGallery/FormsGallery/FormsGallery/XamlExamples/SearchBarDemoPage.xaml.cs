using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class SearchBarDemoPage : ContentPage
    {
        public SearchBarDemoPage()
        {
            InitializeComponent();
        }

        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            // Get the search text.
            SearchBar searchBar = (SearchBar)sender;
            string searchText = searchBar.Text;

            // Create a List and initialize the results Label.
            var list = new List<Tuple<Type, Type>>();
            resultsLabel.Text = "";

            // Get Xamarin.Forms assembly.
            Assembly xamarinFormsAssembly = typeof(View).GetTypeInfo().Assembly;

            // Loop through all the types.
            foreach (Type type in xamarinFormsAssembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                // Public types only.
                if (typeInfo.IsPublic)
                {
                    // Loop through the properties.
                    foreach (PropertyInfo property in typeInfo.DeclaredProperties)
                    {
                        // Check for a match
                        if (property.Name.Equals(searchText))
                        {
                            // Add it to the list.
                            list.Add(Tuple.Create<Type, Type>(type, property.PropertyType));
                        }
                    }
                }
            }

            if (list.Count == 0)
            {
                resultsLabel.Text =
                    String.Format("No Xamarin.Forms properties with " +
                                  "the name of {0} were found",
                                  searchText);
            }
            else
            {
                resultsLabel.Text = "The ";

                foreach (Tuple<Type, Type> tuple in list)
                {
                    resultsLabel.Text +=
                        String.Format("{0} type defines a property named {1} of type {2}",
                                      tuple.Item1.Name, searchText, tuple.Item2.Name);

                    if (tuple != list.Last())
                    {
                        resultsLabel.Text += "; and the ";
                    }
                }

                resultsLabel.Text += ".";
            }
        }
    }
}