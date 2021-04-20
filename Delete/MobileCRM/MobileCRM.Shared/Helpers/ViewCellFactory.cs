using System;
using System.Collections.Generic;
using System.Reflection;
using MobileCRM.Helpers;
using MobileCRM.Models;
using MobileCRM.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

[assembly:Dependency(typeof(ViewCellFactory))]

namespace MobileCRM.Helpers
{
    public class ViewCellFactory : ICellFactory
    {
        static readonly IValueConverter AddressConverter;
        static readonly IValueConverter AddressToStringConverter;
        static readonly IValueConverter DefaultConverter;
        static readonly IValueConverter OwnerConverter;

        static ViewCellFactory()
        {
            AddressConverter = new AddressToPositionConverter();
            AddressToStringConverter = new AddressToStringConverter();
            OwnerConverter = new UserConverter();
            DefaultConverter = new ConvertableConverter();
        }

        #region ICellFactory implementation

        public Cell CellForProperty (PropertyInfo info, IContact context, Page parent = null)
        {
            var map = DependencyService.Get<ViewCellBuilderMap>();

            Func<PropertyInfo, IContact, Page, Cell> func;
            var hasBuilder = map.TryGetValue(info.PropertyType, out func);
            if (!hasBuilder)
                throw new ArgumentOutOfRangeException("info", "No cell builder function found for type " + info.PropertyType.Name + ". Please register one with CellBuilderMap.");

            var cell = func(info, context, parent);
            return cell;
        }
                   
        #endregion

        static string CreateLabel (PropertyInfo property)
        {
            var displayAttrib = property.GetCustomAttribute<DisplayAttribute>();
            var label = displayAttrib != null ? displayAttrib.Name : property.Name;
            return label;
        }

        internal static Cell BoolCell (PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var switchCell = new SwitchCell();
            switchCell.SetValue(SwitchCell.TextProperty, label);
            switchCell.SetBinding(SwitchCell.OnProperty, property.Name);
            switchCell.BindingContext = context;
            return switchCell;
        }

        internal static Cell StringCell(PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var entryCell = new EntryCell();
            entryCell.LabelColor = Color.FromHex("999999");
            entryCell.SetValue(EntryCell.LabelProperty, label);
            entryCell.SetBinding(EntryCell.TextProperty, new Binding(property.Name, BindingMode.TwoWay));
            entryCell.BindingContext = context;
            return entryCell;
        }

        internal static Cell IntCell(PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var entryCell = new EntryCell();
            entryCell.SetValue(EntryCell.LabelProperty, label);
            entryCell.LabelColor = Color.FromHex("999999");
            entryCell.SetBinding(EntryCell.TextProperty, new Binding(property.Name, mode: BindingMode.TwoWay, converter: DefaultConverter));
            entryCell.BindingContext = context;
            return entryCell;
        }

        internal static Cell DecimalCell(PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var currencyAttrib = property.GetCustomAttribute<CurrencyAttribute>();
            var entryCell = new EntryCell();
            entryCell.SetValue(EntryCell.LabelProperty, label);
            entryCell.LabelColor = Color.FromHex("999999");
            entryCell.SetBinding(EntryCell.TextProperty, new Binding(property.Name, mode: BindingMode.TwoWay, converter: DefaultConverter, converterParameter: currencyAttrib));
            entryCell.BindingContext = context;
            return entryCell;
        }

        internal static Cell UserCell(PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var cell = new TextCell();
            cell.SetValue(TextCell.TextProperty, label);
            cell.SetBinding(TextCell.DetailProperty, new Binding(property.Name, converter: OwnerConverter));
            cell.SetValue(TextCell.CommandProperty, new Command(async (a)=>
                {
                    var service = DependencyService.Get<UserRepository>();
                    var users = await service.All();
                    var cellTemplate = new DataTemplate(typeof(TextCell));
                    cellTemplate.SetBinding(TextCell.TextProperty, new Binding(".", converter: OwnerConverter));
                    var list = new ListView {
                        ItemTemplate = cellTemplate,
                        ItemsSource = users
                    };
                    list.ItemSelected += async (sender, e)=>
                    {
                        context.Owner = e.SelectedItem as IUser;
                        await parent.Navigation.PopAsync();
                    };
                    var page = new ContentPage {
                        Title = "Change Owner",
                        Content = list
                    };
                    await parent.Navigation.PushAsync(page);
            }));
            cell.BindingContext = context;
            return cell;
        }

        internal static Cell AddressCell(PropertyInfo property, IContact context, Page parent = null)
        {
            var label = CreateLabel(property);
            var viewCell = new ViewCell 
            {
                Height = 150D
            };
            var pin = new Pin { Label = label };
            pin.SetBinding(Pin.AddressProperty, new Binding("Address", converter: AddressToStringConverter));
            pin.SetBinding(Pin.PositionProperty, new Binding("Address", converter: AddressConverter));
            pin.BindingContext = context;
            pin.PropertyChanged  += (sender, e) => 
                Console.WriteLine("Pin." + e.PropertyName + " Changed");
            var map = new Map(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.1D)))
            {
                IsShowingUser = false,
                InputTransparent = true,
                Pins = { pin }
            };
            map.PropertyChanging += (sender, e) => 
                Console.WriteLine("Map." + e.PropertyName + " Changed");
            viewCell.View = map;
            return viewCell;
        }

        internal static Cell DefaultCell(PropertyInfo property, IContact context, Page parent = null)
        {
            return StringCell(property, context, parent);
        }
    }
}

