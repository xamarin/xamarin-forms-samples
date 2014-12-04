using System;
using System.Collections.Generic;
using System.Reflection;
using MobileCRM.Models;
using MobileCRM.Services;
using Xamarin.Forms;
using MobileCRM.Helpers;

[assembly:Dependency(typeof(EditCellBuilderMap))]

namespace MobileCRM.Helpers
{
    public class EditCellBuilderMap : Dictionary<Type,Func<PropertyInfo, IContact, Page, Cell>>
    {
        public EditCellBuilderMap()
        {
            Add(typeof(bool), EditCellFactory.BoolCell);
            Add(typeof(int),  EditCellFactory.IntCell);
            Add(typeof(decimal), EditCellFactory.DecimalCell);
            Add(typeof(Address), EditCellFactory.AddressCell);
            Add(typeof(IUser), EditCellFactory.UserCell);
            Add(typeof(string), EditCellFactory.StringCell);
        }
    }
}

