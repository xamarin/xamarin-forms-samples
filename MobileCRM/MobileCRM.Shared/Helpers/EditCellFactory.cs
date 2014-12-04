using System;
using System.Collections.Generic;
using System.Reflection;
using MobileCRM.Helpers;
using MobileCRM.Models;
using MobileCRM.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq.Expressions;
using MobileCRM.Shared.ViewModels;
using System.Diagnostics;

[assembly:Dependency(typeof(EditCellFactory))]

namespace MobileCRM.Helpers
{
    public class EditCellFactory : ICellFactory
    {
        static readonly IValueConverter AddressConverter;
        static readonly IValueConverter AddressToStringConverter;
        static readonly IValueConverter DefaultConverter;
        static readonly IValueConverter OwnerConverter;

        static EditCellFactory()
        {
            AddressConverter = new AddressToPositionConverter();
            AddressToStringConverter = new AddressToStringConverter();
            OwnerConverter = new UserConverter();
            DefaultConverter = new ConvertableConverter();
        }

        #region ICellFactory implementation

        public Cell CellForProperty (PropertyInfo info, IContact context, Page parent = null)
        {
            var map = DependencyService.Get<EditCellBuilderMap>();

            Func<PropertyInfo, IContact, Page, Cell> func;
            var hasBuilder = map.TryGetValue(info.PropertyType, out func);
            if (!hasBuilder) {
                map.TryGetValue(typeof(object), out func);
                Debug.WriteLine("Using default cell for property " + info.PropertyType.Name);
            }
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
            switchCell.SetBinding(SwitchCell.OnProperty, new Binding(property.Name, BindingMode.TwoWay));
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
            cell.BindingContext = parent.BindingContext;
            cell.SetValue(TextCell.DetailProperty, label);
            cell.SetBinding(
                TextCell.TextProperty, 
                new Binding(
                    path: "SelectedModel." + property.Name,
                    mode: BindingMode.OneWay,
                    converter: OwnerConverter, 
                    converterParameter: parent.BindingContext
                )
            );
            cell.SetValue(TextCell.CommandProperty, new Command(async (a)=>{
                var cellTemplate = new DataTemplate(typeof(TextCell));
                cellTemplate.SetBinding(TextCell.TextProperty, new Binding(".", converter: OwnerConverter));
                var list = new ListView {
                    ItemTemplate = cellTemplate,
                };
                list.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Users");
                list.SetBinding(ListView.SelectedItemProperty, "SelectedModel." + property.Name);
                list.ItemSelected += async (sender, e)=>
                {
                    await parent.Navigation.PopAsync();
                };
                var page = new ContentPage {
                    Title = "Change Owner",
                    Content = list
                };
                page.BindingContext = parent.BindingContext;

                await parent.Navigation.PushAsync(page);
            }));
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
            pin.SetBinding(Pin.AddressProperty, new Binding(property.Name, converter: AddressToStringConverter));
            pin.SetBinding(Pin.PositionProperty, new Binding(property.Name, converter: AddressConverter));
            var map = new Map(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.1D)))
            {
                IsShowingUser = false,
                InputTransparent = false,
            };
            pin.PropertyChanged  += (sender, e) => {
                Console.WriteLine("Pin." + e.PropertyName + " Changed");
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.1D)));
            };
            map.PropertyChanging += (sender, e) => 
                Console.WriteLine("Map." + e.PropertyName + " Changed");
            pin.BindingContext = context;
            map.Pins.Add(pin);
            viewCell.View = map;
            return viewCell;
        }

        internal static Cell DefaultCell(PropertyInfo property, IContact context, Page parent = null)
        {
            return StringCell(property, context, parent);
        }
    }
}

