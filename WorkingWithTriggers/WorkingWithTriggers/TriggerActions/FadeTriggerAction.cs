using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithTriggers
{
	public class FadeTriggerAction : TriggerAction<VisualElement>
	{
		public FadeTriggerAction()
		{
		}
		
		public int StartsFrom { set; get; }

		protected override void Invoke (VisualElement visual)
		{
				visual.Animate("", new Animation( (d)=>{
					var val = StartsFrom==1 ? d : 1-d;
					visual.BackgroundColor = Color.FromRgb(1, val, 1);
					Debug.WriteLine(d);

				}),
				length:1000, // milliseconds
				easing: Easing.Linear);

		}
	}
}


