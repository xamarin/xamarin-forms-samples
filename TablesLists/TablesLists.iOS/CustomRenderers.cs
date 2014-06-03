using System;
using System.Drawing;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer (typeof(TablesLists.View.MainView.ItemTemplate), 
	typeof(TablesLists.iOS.MainMenuCellRenderer))]

[assembly:ExportRenderer (typeof(TablesLists.View.AccessoryCheckmark.ItemTemplate), 
	typeof(TablesLists.iOS.CheckmarkCellRenderer))]

[assembly:ExportRenderer (typeof(TablesLists.View.AccessoryDisclosure.ItemTemplate), 
	typeof(TablesLists.iOS.DisclosureCellRenderer))]

[assembly:ExportRenderer (typeof(TablesLists.View.AccessoryDetailDisclosure.ItemTemplate), 
	typeof(TablesLists.iOS.DetailDisclosureCellRenderer))]
	
namespace TablesLists.iOS
{
	public class MainMenuCellRenderer : ViewCellRenderer
	{
		public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (item, tv);
			cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}
	}

	public class CheckmarkCellRenderer : ViewCellRenderer
	{
		public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (item, tv);
			cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.Checkmark;
			return cell;
		}
	}

	public class DisclosureCellRenderer : ViewCellRenderer
	{
		public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (item, tv);
			cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}
	}

	public class DetailDisclosureCellRenderer : ViewCellRenderer
	{
		public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (item, tv);
			cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DetailDisclosureButton;
			return cell;
		}
	}
}

