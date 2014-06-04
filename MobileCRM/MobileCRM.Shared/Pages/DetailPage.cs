using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using MobileCRM.Shared.CustomViews;
using System.Collections;
using Xamarin.Forms.Maps;

namespace MobileCRM.Shared.Pages
{
    public class DetailPage<T> : ContentPage where T: class, IContact, new()
    {
        static string ConvertToString (object obj)
        {
            if (obj is string) return (string)obj;
            var list = obj as IEnumerable;
            if (list != null)
                return string.Join (" ", list.Cast<object>().Count() > 0 ? list.Cast<object>() : new object[] { String.Empty });
            if (obj is Address)
                return ((Address)obj).ToString();
            return Convert.ToString(obj);
        }

        IValueConverter AddressConverter;

        IValueConverter AddressToStringConverter;

        public DetailPage(T bindingContext)
        {
            AddressConverter = new AddressToPositionConverter();
            AddressToStringConverter = new AddressToStringConverter<Address,String>();
            BindingContext = bindingContext;
            // Use reflection to turn our object
            // into a property bag.
            var detailList = new ListView();
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

            detailList.ItemsSource = items;

            // Create a TableView to properly visualize our record.
            var detailTable = CreateTableForProperties(items);

            Content = detailTable;
            Title = BindingContext.ToString();
        }

        TableView CreateTableForProperties (IEnumerable<PropertyInfo> items)
        {
            var table = new TableView {
                Intent = TableIntent.Settings,
                HasUnevenRows = true,
                Root = new TableRoot(BindingContext.ToString()),
            };

            table.Root.Add(new TableSection {
                items.Select(ToTableCell)
            });

            return table;
        }

        Cell ToTableCell(PropertyInfo pi)
        {
            Cell cell = null;

            if (pi.PropertyType == typeof(bool)) {
                cell = new SwitchCell();
                cell.SetValue(SwitchCell.TextProperty, pi.Name);
                cell.SetBinding(SwitchCell.OnProperty, pi.Name);
            } else if (pi.PropertyType == typeof(int)) {
                cell = new EntryCell();
                cell.SetValue(EntryCell.LabelProperty, pi.Name);
                cell.SetBinding(EntryCell.TextProperty, new Binding(pi.Name, converter: new OwnerToStringConverter()));
                cell.BindingContext = BindingContext;
            } else if (pi.PropertyType == typeof(Address)) {
                var viewCell = new ViewCell 
                {
                    Height = 150D
                };
                var pin = new Pin { Label = BindingContext.ToString() };
                pin.SetBinding(Pin.AddressProperty, new Binding("Address", converter: AddressToStringConverter));
                pin.SetBinding(Pin.PositionProperty, new Binding("Address", converter: AddressConverter));
                pin.BindingContext = BindingContext;
                var map = new Map(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.1D)))
                {
                    IsShowingUser = false,
                    InputTransparent = true,
                    Pins = { pin }
                };
                viewCell.View = map;
                cell = viewCell;

            } else if (pi.PropertyType == typeof(int)) {
                cell = new TextCell();
                cell.SetBinding(TextCell.TextProperty, pi.Name);
                cell.SetBinding(TextCell.DetailProperty, Convert.ToString(pi.GetValue(BindingContext)));
                cell.BindingContext = BindingContext;
            } else {
                cell = new EntryCell();
                cell.SetValue(EntryCell.LabelProperty, pi.Name);
                cell.SetBinding(EntryCell.TextProperty, pi.Name);
            }

            return cell;
        }
    }
}
