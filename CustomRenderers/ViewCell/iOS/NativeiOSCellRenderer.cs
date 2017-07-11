using CustomRenderer;
using CustomRenderer.iOS;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeiOSCellRenderer))]
namespace CustomRenderer.iOS
{
	public class NativeiOSCellRenderer : ViewCellRenderer
	{
		NativeiOSCell cell;

		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var nativeCell = (NativeCell)item;
			Console.WriteLine("\t\t" + nativeCell.Name);

			cell = reusableCell as NativeiOSCell;
			if (cell == null)
			{
				cell = new NativeiOSCell(item.GetType().FullName, nativeCell);
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
				cell.HeadingLabel.Text = nativeCell.Name;
			}
			else if (e.PropertyName == NativeCell.CategoryProperty.PropertyName)
			{
				cell.SubheadingLabel.Text = nativeCell.Category;
			}
			else if (e.PropertyName == NativeCell.ImageFilenameProperty.PropertyName)
			{
				cell.CellImageView.Image = cell.GetImage(nativeCell.ImageFilename);
			}
		}
	}
}

