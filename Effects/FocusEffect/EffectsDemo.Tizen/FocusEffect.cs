using EffectsDemo.Tizen;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using EColor = ElmSharp.Color;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace EffectsDemo.Tizen
{
	public class FocusEffect : PlatformEffect
	{
		EColor backgroundColor;

		protected override void OnAttached()
		{
			try
			{
				(Control as ElmSharp.Entry).BackgroundColor = backgroundColor = EColor.Lime;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			try
			{
				if (args.PropertyName == "IsFocused")
				{
					var control = Control as ElmSharp.Entry;
					if (control.BackgroundColor.Equals(backgroundColor))
					{
						control.BackgroundColor = EColor.White;
					}
					else
					{
						control.BackgroundColor = backgroundColor;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}
	}
}

