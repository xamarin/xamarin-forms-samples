using EffectsDemo.Tizen;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(BackgroundColorEffect), "BackgroundColorEffect")]

namespace EffectsDemo.Tizen
{
	public class BackgroundColorEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				(Control as ElmSharp.Widget).BackgroundColor = ElmSharp.Color.Red;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}
	}
}