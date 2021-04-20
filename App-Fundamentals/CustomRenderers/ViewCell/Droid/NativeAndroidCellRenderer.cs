using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeAndroidCellRenderer))]
namespace CustomRenderer.Droid
{
	public class NativeAndroidCellRenderer : ViewCellRenderer
	{
		NativeAndroidCell cell;

		protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
		{
			var nativeCell = (NativeCell)item;
			Console.WriteLine("\t\t" + nativeCell.Name);

			cell = convertView as NativeAndroidCell;
			if (cell == null)
			{
				cell = new NativeAndroidCell(context, nativeCell);
			}
			else
			{
				cell.NativeCell.PropertyChanged -= OnNativeCellPropertyChanged;
			}

			nativeCell.PropertyChanged += OnNativeCellPropertyChanged;

			cell.UpdateCell(nativeCell);
			return cell;
		}

		void OnNativeCellPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var nativeCell = (NativeCell)sender;
			if (e.PropertyName == NativeCell.NameProperty.PropertyName)
			{
				cell.HeadingTextView.Text = nativeCell.Name;
			}
			else if (e.PropertyName == NativeCell.CategoryProperty.PropertyName)
			{
				cell.SubheadingTextView.Text = nativeCell.Category;
			}
			else if (e.PropertyName == NativeCell.ImageFilenameProperty.PropertyName)
			{
				cell.SetImage(nativeCell.ImageFilename);
			}
		}
	}
}
