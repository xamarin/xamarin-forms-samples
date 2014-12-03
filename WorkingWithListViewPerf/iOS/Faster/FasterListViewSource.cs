using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using System.Collections;
using System.Linq;

namespace WorkingWithListViewPerf.iOS
{
	public class FasterListViewSource : UITableViewSource
	{
		// declare vars
		protected IList<string> tableItems;
		protected string cellIdentifier = "TableCell";

		//public IList<string> Items {get;set;}
		public IEnumerable<string> Items {
			//get{ }
			set{
				tableItems = value.ToList();
			}
		}

		public FasterListViewSource() {

		}

		public FasterListViewSource (List<string> items)
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
			new UIAlertView("Row Selected", tableItems[indexPath.Row], null, "OK", null).Show();
		}

		public override void RowDeselected (UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("Row " + indexPath.Row.ToString() + " deselected");	
		}

//		public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
//		{
//			Console.WriteLine("Accessory for Section, " + indexPath.Section.ToString() + " and Row, " + indexPath.Row.ToString() + " tapped");
//		}

		#endregion

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// declare vars
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			//string item = tableItems [indexPath.Row]; //.Items[indexPath.Row];

			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);

			// set the item text
			cell.TextLabel.Text = tableItems [indexPath.Row];//.Items[indexPath.Row].Heading;

			// if it's a cell style that supports a subheading, set it
//			if(item.CellStyle == UITableViewCellStyle.Subtitle 
//				|| item.CellStyle == UITableViewCellStyle.Value1
//				|| item.CellStyle == UITableViewCellStyle.Value2)
//			{ cell.DetailTextLabel.Text = item.SubHeading; }

			// if the item has a valid image, and it's not the contact style (doesn't support images)
//			if(!string.IsNullOrEmpty(item.ImageName) && item.CellStyle != UITableViewCellStyle.Value2)
//			{
//				if(File.Exists(item.ImageName))
//					cell.ImageView.Image = UIImage.FromBundle(item.ImageName);
//			}

			// set the accessory
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

	}
}

