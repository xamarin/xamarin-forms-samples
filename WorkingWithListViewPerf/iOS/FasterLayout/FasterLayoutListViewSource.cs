using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace WorkingWithListViewPerf.iOS
{
	public class FasterLayoutListViewSource: UITableViewSource
	{
		// declare vars
		protected IList<DataSource> tableItems;
		protected NSString cellIdentifier = new NSString("TableCell");

		//public IList<string> Items {get;set;}
		public IEnumerable<DataSource> Items {
			//get{ }
			set{
				tableItems = value.ToList();
			}
		}

		public FasterLayoutListViewSource() {

		}

		public FasterLayoutListViewSource (List<DataSource> items)
		{
			tableItems = items;
		}

		#region -= data binding/display methods =-

		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		#endregion

		#region -= user interaction methods =-

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView("Row Selected", tableItems[indexPath.Row].Name, null, "OK", null).Show();
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
			FasterLayoutListViewCell cell = tableView.DequeueReusableCell (cellIdentifier) as FasterLayoutListViewCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new FasterLayoutListViewCell (cellIdentifier);
			}

			if (String.IsNullOrWhiteSpace (tableItems [indexPath.Row].ImageFilename)) {
				cell.UpdateCell (tableItems [indexPath.Row].Name
				, tableItems [indexPath.Row].Category
				, null);
			} else {
				cell.UpdateCell (tableItems[indexPath.Row].Name
					, tableItems[indexPath.Row].Category
					, UIImage.FromFile ("Images/" +tableItems[indexPath.Row].ImageFilename) );
			}

			return cell;
		}
	}
}

