using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace WorkingWithListviewNative.iOS
{
	public class NativeiOSListViewSource : UITableViewSource
	{
		// declare vars
		IList<DataSource2> tableItems;
		NativeListView2 listView;
		readonly NSString cellIdentifier = new NSString("TableCell");

		public IEnumerable<DataSource2> Items {
			//get{ }
			set{
				tableItems = value.ToList();
			}
		}

		public NativeiOSListViewSource (NativeListView2 view)
		{
			tableItems = view.Items.ToList();
			listView = view;
		}
			
		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		#region user interaction methods

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			listView.NotifyItemSelected (tableItems [indexPath.Row]);
			Console.WriteLine("Row " + indexPath.Row.ToString() + " selected");	
			tableView.DeselectRow (indexPath, true);
		}

		public override void RowDeselected (UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("Row " + indexPath.Row.ToString() + " deselected");	
		}

		#endregion

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			NativeiOSListViewCell cell = tableView.DequeueReusableCell (cellIdentifier) as NativeiOSListViewCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new NativeiOSListViewCell (cellIdentifier);
			}

			if (String.IsNullOrWhiteSpace (tableItems [indexPath.Row].ImageFilename)) {
				cell.UpdateCell (tableItems [indexPath.Row].Name
				, tableItems [indexPath.Row].Category
				, null);
			} else {
				cell.UpdateCell (tableItems[indexPath.Row].Name
					, tableItems[indexPath.Row].Category
					, UIImage.FromFile ("Images/" +tableItems[indexPath.Row].ImageFilename + ".jpg") );
			}

			return cell;
		}
	}
}

