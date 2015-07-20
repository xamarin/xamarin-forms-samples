using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MobileCRM.Helpers;
using MobileCRM.Models;
using Xamarin.Forms;
using MobileCRM.Shared.ViewModels;
using Xamarin.Forms.Maps;

namespace MobileCRM.Shared.Pages
{
    public class DetailEditPage<T> : ContentPage where T: class, IContact, new()
    {
        public DetailEditPage(MasterViewModel<T> viewModel)
        {
            BindingContext = viewModel;
            // Use reflection to turn our object
            // into a property bag.
            var items = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi =>{
                    var value = pi.GetValue(viewModel.SelectedModel);
                    if (value == null) 
                        return false;
                    if (pi.Name == "FullName") // omits the FullName property
                        return false;
                    if (value is string || value is Address) 
                        return !string.IsNullOrWhiteSpace(value.ToString());
                    var enumerable = value as IEnumerable;
                    if (enumerable != null)
                        return enumerable.Cast<object>().Any ();
                    return true;
                });         

            // Create a TableView to properly visualize our record.
            var detailTable = CreateTableForProperties(items, viewModel.SelectedModel);
            ToolbarItems.Add(new ToolbarItem("Done", null, async ()=>{
                var confirmed = await DisplayAlert("Unsaved Changes", "Save changes?", "Save", "Discard");
                if (confirmed) {
                    viewModel.SaveSelectedModel.Execute(null);
                    await Navigation.PopAsync();
                } else {
                    Console.WriteLine("cancel changes!");
                }
            }));
            Content = detailTable;
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

        TableView CreateTableForProperties (IEnumerable<PropertyInfo> items, IContact context)
        {
            var table = new TableView {
                HasUnevenRows = true,
                Root = new TableRoot(),
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            table.Root.Add(new TableSection {
                items.Select((pi => ToTableCell(pi, context)))
            });

            return table;
        }

        Cell ToTableCell(PropertyInfo pi, IContact context)
        {
            var factory = DependencyService.Get<EditCellFactory>();
            var cell = factory.CellForProperty(pi, context, this);

            cell.BindingContextChanged  += (sender, e) =>
                Console.WriteLine("cell.BindingContextChanged fired");

            cell.PropertyChanging += (sender, e) => 
                Console.WriteLine("cell." + e.PropertyName + " Changed");

            return cell;
        }
    }
}
