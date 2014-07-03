using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;

namespace EmployeeDirectory.iOS
{
	public class Theme
	{
		/// <summary>
		/// Apply this theme to everything that it can.
		/// </summary>
		public static void Apply (string options = null)
		{
			Apply (UINavigationBar.Appearance, options);
			Apply (UITabBar.Appearance, options);
			Apply (UIToolbar.Appearance, options);
			Apply (UIBarButtonItem.Appearance, options);
			Apply (UISlider.Appearance, options);
			Apply (UISegmentedControl.Appearance, options);
			Apply (UIProgressView.Appearance, options);
			Apply (UISearchBar.Appearance, options);
			Apply (UISwitch.Appearance, options);
			Apply (UIRefreshControl.Appearance, options);
		}

		#region UIView

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UIView view, string options = null)
		{
			view.BackgroundColor = UIColor.FromRGB (85, 85, 85);
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		/// <param name='options'>
		/// Can be "gunmetal", "mesh", or null
		/// </param>
		public static void Apply (UIView.UIViewAppearance appearance, string options = null)
		{
			appearance.BackgroundColor = UIColor.FromRGB (85, 85, 85);
		}

		#endregion

		#region UINavigationBar

		static Lazy<UIImage> navigationBarBackground = new Lazy<UIImage> (
			() => UIImage.FromBundle ("topnav.png"));
		static Lazy<UIImage> blueNavigationBarBackground = new Lazy<UIImage> (
			() => UIImage.FromBundle ("bluebar.png"));

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UINavigationBar view, string options = null)
		{
			if (options == "blue") {
				view.SetBackgroundImage (blueNavigationBarBackground.Value, UIBarMetrics.Default);
			} else {
				view.SetBackgroundImage (navigationBarBackground.Value, UIBarMetrics.Default);
			}
			view.SetTitleTextAttributes (new UITextAttributes {
				TextColor = UIColor.FromRGBA (255, 255, 255, 255),
				TextShadowColor = UIColor.FromRGBA (0, 0, 0, 0.8f),
				TextShadowOffset = new UIOffset (0, -1),
			});
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UINavigationBar.UINavigationBarAppearance appearance, string options = null)
		{
			if (options == "blue") {
				appearance.SetBackgroundImage (blueNavigationBarBackground.Value, UIBarMetrics.Default);
			} else {
				appearance.SetBackgroundImage (navigationBarBackground.Value, UIBarMetrics.Default);
			}
			appearance.SetTitleTextAttributes (new UITextAttributes {
				TextColor = UIColor.FromRGBA (255, 255, 255, 255),
				TextShadowColor = UIColor.FromRGBA (0, 0, 0, 0.8f),
				TextShadowOffset = new UIOffset (0, -1),
			});
		}

		#endregion

		#region UITabBar

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UITabBar view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UITabBar.UITabBarAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UIToolbar

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UIToolbar view, string options = null)
		{
			if (options == "blue") {
				view.SetBackgroundImage (blueNavigationBarBackground.Value, UIToolbarPosition.Any, UIBarMetrics.Default);
			} else {
				view.SetBackgroundImage (navigationBarBackground.Value, UIToolbarPosition.Any, UIBarMetrics.Default);
			}
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UIToolbar.UIToolbarAppearance appearance, string options = null)
		{
			if (options == "blue") {
				appearance.SetBackgroundImage (blueNavigationBarBackground.Value, UIToolbarPosition.Any, UIBarMetrics.Default);
			} else {
				appearance.SetBackgroundImage (navigationBarBackground.Value, UIToolbarPosition.Any, UIBarMetrics.Default);
			}
		}

		#endregion

		#region UIBarButtonItem

		static Lazy<UIImage> barButtonBackground = new Lazy<UIImage> (() => UIImage.FromBundle ("topnavbtn.png").CreateResizableImage (new UIEdgeInsets (0, 4, 0, 4)));
		static Lazy<UIImage> backButtonBackBackground = new Lazy<UIImage> (() => UIImage.FromBundle ("backbutton.png").CreateResizableImage (new UIEdgeInsets (0, 14, 0, 4)));
		static Lazy<UIImage> blueBarButtonBackground = new Lazy<UIImage> (() => UIImage.FromBundle ("bluenavbtn.png").CreateResizableImage (new UIEdgeInsets (0, 4, 0, 4)));
		static Lazy<UIImage> blueBackButtonBackBackground = new Lazy<UIImage> (() => UIImage.FromBundle ("backbutton.png").CreateResizableImage (new UIEdgeInsets (0, 14, 0, 4)));

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UIBarButtonItem view, string options = null)
		{
			if (options == "blue") {
				view.SetBackgroundImage (blueBarButtonBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
				view.SetBackButtonBackgroundImage (blueBackButtonBackBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
			} else {
				view.SetBackgroundImage (barButtonBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
				view.SetBackButtonBackgroundImage (backButtonBackBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
			}
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		/// <param name="options">
		/// "blue", or null
		/// </para>
		public static void Apply (UIBarButtonItem.UIBarButtonItemAppearance appearance, string options = null)
		{
			if (options == "blue") {
				appearance.SetBackgroundImage (blueBarButtonBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
				appearance.SetBackButtonBackgroundImage (blueBackButtonBackBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
			} else {
				appearance.SetBackgroundImage (barButtonBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
				appearance.SetBackButtonBackgroundImage (backButtonBackBackground.Value, UIControlState.Normal, UIBarMetrics.Default);
			}
		}

		#endregion

		#region UIButton

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UIButton view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UIButton.UIButtonAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UISlider

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UISlider view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UISlider.UISliderAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UILabel

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UILabel view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UILabel.UILabelAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UITextField

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UITextField view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UITextField.UITextFieldAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UISegmentedControl

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UISegmentedControl view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UISegmentedControl.UISegmentedControlAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UIProgressView

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UIProgressView view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UIProgressView.UIProgressViewAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UISearchBar

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UISearchBar view, string options = null)
		{
			view.TintColor = UIColor.DarkGray;
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UISearchBar.UISearchBarAppearance appearance, string options = null)
		{
			appearance.TintColor = UIColor.DarkGray;
		}

		#endregion

		#region UISwitch

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UISwitch view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UISwitch.UISwitchAppearance appearance, string options = null)
		{
		}

		#endregion

		#region UIRefreshControl

		/// <summary>
		/// Apply this theme to a specific view.
		/// </summary>
		public static void Apply (UIRefreshControl view, string options = null)
		{
		}

		/// <summary>
		/// Apply this theme to all views with the given appearance.
		/// </summary>
		public static void Apply (UIRefreshControl.UIRefreshControlAppearance appearance, string options = null)
		{
		}

		#endregion
	}
}
