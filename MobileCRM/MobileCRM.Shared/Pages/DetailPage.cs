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
using MobileCRM.Services;
using System.Net.NetworkInformation;

namespace MobileCRM.Shared.Pages
{
    public class DetailPage<T> : ContentPage where T: class, IContact, new()
    {
        readonly IValueConverter AddressConverter;
        readonly IValueConverter AddressToStringConverter;
        readonly IValueConverter DefaultConverter;
        readonly IValueConverter OwnerConverter;

        public DetailPage(T bindingContext)
        {
            AddressConverter = new AddressToPositionConverter();
            AddressToStringConverter = new AddressToStringConverter();
            OwnerConverter = new UserToStringConverter();
            DefaultConverter = new ConvertableConverter();

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
            Cell cell = null;

            var displayAttrib = pi.GetCustomAttribute<DisplayAttribute>();
            var label = displayAttrib != null ? displayAttrib.Name : pi.Name;

            // TODO: Refactor this into one or more factory classes.
            if (pi.PropertyType == typeof(bool)) {
                var switchCell = new SwitchCell();
                switchCell.SetValue(SwitchCell.TextProperty, label);
                switchCell.SetBinding(SwitchCell.OnProperty, pi.Name);
                cell = switchCell;
                cell.BindingContext = BindingContext;
            } else if (pi.PropertyType == typeof(int)) {
                var entryCell = new EntryCell();
                entryCell.SetValue(EntryCell.LabelProperty, label);
                entryCell.LabelColor = Color.FromHex("999999");
                entryCell.SetBinding(EntryCell.TextProperty, new Binding(pi.Name, mode: BindingMode.TwoWay, converter: DefaultConverter));
                cell = entryCell;
                cell.BindingContext = BindingContext;
            } else if (pi.PropertyType == typeof(decimal)) {
                var currencyAttrib = pi.GetCustomAttribute<CurrencyAttribute>();
                var entryCell = new EntryCell();
                entryCell.SetValue(EntryCell.LabelProperty, label);
                entryCell.LabelColor = Color.FromHex("999999");
                entryCell.SetBinding(EntryCell.TextProperty, new Binding(pi.Name, mode: BindingMode.TwoWay, converter: DefaultConverter, converterParameter: currencyAttrib));
                cell = entryCell;
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
                pin.PropertyChanged  += (sender, e) => 
                    Console.WriteLine("Pin." + e.PropertyName + " Changed");
                var map = new Map(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.1D)))
                {
                    IsShowingUser = false,
                    InputTransparent = false,
                    Pins = { pin }
                };
                map.PropertyChanging += (sender, e) => 
                    Console.WriteLine("Map." + e.PropertyName + " Changed");
                viewCell.View = map;
                cell = viewCell;
            } else if (pi.PropertyType == typeof(int)) {
                cell = new TextCell();
                cell.SetBinding(TextCell.TextProperty, label);
                cell.SetBinding(TextCell.DetailProperty, new Binding(pi.Name, converter: DefaultConverter));
                cell.BindingContext = BindingContext;
            } else if (pi.PropertyType == typeof(IUser)) {
                cell = new TextCell();
                cell.SetValue(TextCell.TextProperty, label);
                cell.SetBinding(TextCell.DetailProperty, new Binding(pi.Name, converter: OwnerConverter));
                cell.SetValue(TextCell.CommandProperty, new Command(async (a)=>{
                    var service = DependencyService.Get<UserRepository>();
                    var users = await service.All();
                    var page = new ContentPage {
                        Title = "Change Owner",
                        Content = new ListView {
                            ItemTemplate = new DataTemplate(typeof(TextCell)),
                            ItemsSource = users                            
                        }
                    };
                    await Navigation.PushModalAsync(new NavigationPage(page));
                }));
                cell.BindingContext = BindingContext;
            } else {
                var entryCell = new EntryCell();
                entryCell.LabelColor = Color.FromHex("999999");
                entryCell.SetValue(EntryCell.LabelProperty, label);
                entryCell.SetBinding(EntryCell.TextProperty, new Binding(pi.Name, BindingMode.TwoWay));
                cell = entryCell;
                cell.BindingContext = BindingContext;
            }

            cell.BindingContextChanged  += (sender, e) =>
                Console.WriteLine("cell.BindingContextChanged");
            cell.PropertyChanging += (sender, e) => 
                Console.WriteLine(e.PropertyName + " Changed");

            return cell;
        }
    }
}
