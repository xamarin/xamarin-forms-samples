using System;
using MobileCRM.Models;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Helpers;

[assembly:Dependency(typeof(ViewCellBuilderMap))]

namespace MobileCRM.Helpers
{
    public class ViewCellBuilderMap : Dictionary<Type,Func<PropertyInfo, IContact, Page, Cell>>
    {
        public ViewCellBuilderMap()
        {
            Add(typeof(bool), ViewCellFactory.BoolCell);
            Add(typeof(int),  ViewCellFactory.IntCell);
            Add(typeof(decimal), ViewCellFactory.DecimalCell);
            Add(typeof(Address), ViewCellFactory.AddressCell);
            Add(typeof(IUser), ViewCellFactory.UserCell);
            Add(typeof(string), ViewCellFactory.StringCell);
        }
    }
}

