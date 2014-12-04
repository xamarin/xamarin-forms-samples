using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MobileCRM.Models;
using MobileCRM.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using MobileCRM.Helpers;

namespace MobileCRM.Shared.Pages
{
    public class DetailPage<T> : ContentPage where T: class, IContact, new()
    {
        public DetailPage(T bindingContext)
        {
            BindingContext = bindingContext;
            // Use reflection to turn our object
            // into a property bag.
            var items = BindingContext.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi =>{
                    var value = pi.GetValue(BindingContext);
                    if (value == null) return false;
                    if (value is string || value is Address) return !string.IsNullOrWhiteSpace(value.ToString());
                    if (value is IEnumerable)
                        return ((IEnumerable)value).Cast<object>().Any ();
                    return true;
                });                

            // Create a TableView to properly visualize our record.
            var detailTable = CreateTableForProperties(items);

            Content = detailTable;
            Title = BindingContext.ToString();
        }

        protected async override void OnDisappearing ()
        {
            var confirmed = await DisplayAlert("Unsaved Changes", "Save changes?", "Save", "Discard");
            if (confirmed)
                base.OnDisappearing ();
            else
                Console.WriteLine("cancel changes!");
        }

        protected override void OnPropertyChanging (string propertyName = null)
        {
            Console.WriteLine(propertyName + " is changing");
            base.OnPropertyChanging (propertyName);
        }

        protected override void OnPropertyChanged (string propertyName = null)
        {
            Console.WriteLine(propertyName + " is changed");
            base.OnPropertyChanging (propertyName);
        }

        protected override void OnBindingContextChanged ()
        {
            base.OnBindingContextChanged ();
            Console.WriteLine("BindingContext Changed");

        }

        TableView CreateTableForProperties (IEnumerable<PropertyInfo> items)
        {
            var table = new TableView {
                HasUnevenRows = true,
                Root = new TableRoot(BindingContext.ToString()),
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            table.Root.Add(new TableSection {
                items.Select(ToTableCell)
            });

            return table;
        }

        Cell ToTableCell(PropertyInfo pi)
        {
            var factory = DependencyService.Get<ViewCellFactory>();
            var cell = factory.CellForProperty(pi, (IContact)BindingContext, this);

            cell.BindingContextChanged  += (sender, e) =>
                Console.WriteLine("cell.BindingContextChanged fired");

            cell.PropertyChanging += (sender, e) => 
                Console.WriteLine("cell." + e.PropertyName + " Changed");

            return cell;
        }
    }
}
