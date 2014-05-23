using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MobileCRM.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;


[assembly: ExportRenderer(typeof(NavigationRenderer), typeof(BlueNavigationRenderer))]
namespace MobileCRM.iOS.Renderers
{
  public class BlueNavigationRenderer : NavigationRenderer
  {
    public BlueNavigationRenderer()
    {
      this.NavigationBar.TintColor = UIColor.White;
      this.NavigationBar.BarTintColor = MobileCRM.Shared.Helpers.Color.Blue.ToUIColor();
      this.NavigationBar.BarStyle = UIBarStyle.Black;


    }
  }
}