using System;
using Xamarin.Forms;
using System.Reflection;
using MobileCRM.Models;

namespace MobileCRM
{
	public interface ICellFactory
	{
        Cell CellForProperty (PropertyInfo info, IContact context, Page parent = null);
    }
}

