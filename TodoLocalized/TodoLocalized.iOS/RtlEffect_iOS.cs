using System;
using TodoLocalized;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(AddRtlEffect), "AddRtlEffect")]

namespace TodoLocalized
{
	/// <summary>Add right-to-left properties to Xamarin.Forms controls in iOS</summary>
	public class AddRtlEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			// feature isn't relevant if we're rendering Left-to-Right
			if (UIApplication.SharedApplication.UserInterfaceLayoutDirection == UIUserInterfaceLayoutDirection.LeftToRight)
				return;
			
			try
			{
				if (RtlEffect.GetShouldObeyRtl(Element))
				{
					if (Element is StackLayout) { 
						var sl = (StackLayout)Element;
						if (sl.HorizontalOptions.Alignment == LayoutAlignment.Start)
							sl.HorizontalOptions = LayoutOptions.EndAndExpand;
					}
					if (Control is UILabel)
					{
						((UILabel)Control).TextAlignment = UITextAlignment.Right;
					}
					else if (Control is UITextView)
					{
						((UITextView)Control).TextAlignment = UITextAlignment.Right;
					}
					else if (Control is UITextField)
					{
						((UITextField)Control).TextAlignment = UITextAlignment.Right;
					}
					else
					{
						Console.WriteLine("Control was " + Control?.ToString());
					}
				}
				else
				{
					if (Element is StackLayout)
					{
						var sl = (StackLayout)Element;
						if (sl.HorizontalOptions.Alignment == LayoutAlignment.End)
							sl.HorizontalOptions = LayoutOptions.StartAndExpand;
					}
					if (Control is UILabel)
					{
						((UILabel)Control).TextAlignment = UITextAlignment.Left;
					}
					if (Control is UITextView)
					{
						((UITextView)Control).TextAlignment = UITextAlignment.Left;
					}
					if (Control is UITextField)
					{
						((UITextField)Control).TextAlignment = UITextAlignment.Left;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: " + ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			// feature isn't relevant if we're rendering Left-to-Right
			if (UIApplication.SharedApplication.UserInterfaceLayoutDirection == UIUserInterfaceLayoutDirection.LeftToRight)
				return;
			
			if (args.PropertyName == RtlEffect.ShouldObeyRtlProperty.PropertyName)
			{
				if (RtlEffect.GetShouldObeyRtl(Element))
				{
					if (Element is StackLayout)
					{
						var sl = (StackLayout)Element;
						if (sl.HorizontalOptions.Alignment == LayoutAlignment.Start)
							sl.HorizontalOptions = LayoutOptions.EndAndExpand;
					}
					if (Control is UILabel)
					{
						((UILabel)Control).TextAlignment = UITextAlignment.Right;
					}
					else if (Control is UITextView)
					{
						((UITextView)Control).TextAlignment = UITextAlignment.Right;
					}
					else if (Control is UITextField)
					{
						((UITextField)Control).TextAlignment = UITextAlignment.Right;
					}
					else 
					{
						Console.WriteLine("Control was " + Control?.ToString());
					}
				}
				else
				{
					if (Element is StackLayout)
					{
						var sl = (StackLayout)Element;
						if (sl.HorizontalOptions.Alignment == LayoutAlignment.End)
							sl.HorizontalOptions = LayoutOptions.StartAndExpand;
					}
					if (Control is UILabel)
					{
						((UILabel)Control).TextAlignment = UITextAlignment.Left;
					}
					if (Control is UITextView)
					{
						((UITextView)Control).TextAlignment = UITextAlignment.Left;
					}
					if (Control is UITextField)
					{
						((UITextField)Control).TextAlignment = UITextAlignment.Left;
					}
				}
			}
			// ... other properties
			else
			{
				base.OnElementPropertyChanged(args);
			}
		}
	}
}

