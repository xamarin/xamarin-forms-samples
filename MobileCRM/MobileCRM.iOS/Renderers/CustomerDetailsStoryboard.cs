
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using MobileCRM.Shared.Models;

namespace MobileCRM.iOS.Renderers
{
  public partial class CustomerDetailsStoryboard : UIViewController
  {
    static bool UserInterfaceIdiomIsPhone
    {
      get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
    }

    public CustomerDetailsStoryboard(IntPtr handle)
      : base(handle)
    {
    }

    public override void DidReceiveMemoryWarning()
    {
      // Releases the view if it doesn't have a superview.
      base.DidReceiveMemoryWarning();

      // Release any cached data, images, etc that aren't in use.
    }

    private VisualElement model;
    public VisualElement Model
    {
        get { return model; }
        set 
        {
            model = value;
            this.model.BindingContextChanged += (sender, args) =>
                {
                    var poi = (POI)model.BindingContext;
                    LabelCustomerCategory.Text = poi.DisplayLabel;
                    LabelCustomerName.Text = poi.DisplayCategory;

                }; 
 
        }
    }

    #region View lifecycle

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      if (model.BindingContext != null)
      {
          var poi = (POI)model.BindingContext;
          LabelCustomerCategory.Text = poi.DisplayLabel;
          LabelCustomerName.Text = poi.DisplayCategory;
      }
      // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);
    }

    public override void ViewDidAppear(bool animated)
    {
      base.ViewDidAppear(animated);
    }

    public override void ViewWillDisappear(bool animated)
    {
      base.ViewWillDisappear(animated);
    }

    public override void ViewDidDisappear(bool animated)
    {
      base.ViewDidDisappear(animated);
    }

    #endregion

    partial void UISwitch12_ValueChanged(UISwitch sender)
    {
        if (!sender.On)
            return;

        var alert = new UIAlertView("Customer Inactive", "Please ensure data is accurate", null, "OK");
        alert.Show();
    }
  }
}