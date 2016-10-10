using System;
using System.Linq;
using Xamarin.Forms;

namespace TodoLocalized
{
	public static class RtlEffect
	{
		public static readonly BindableProperty ShouldObeyRtlProperty =
		  BindableProperty.CreateAttached("ShouldObeyRtl",
			  typeof(bool), typeof(RtlEffect), false,
			  propertyChanged: OnShouldObeyRtlChanged);


		// ShouldObeyRtl
		public static bool GetShouldObeyRtl(BindableObject view)
		{
			return (bool)view.GetValue(ShouldObeyRtlProperty);
		}
		public static void SetShouldObeyRtl(BindableObject view, bool value)
		{
			view.SetValue(ShouldObeyRtlProperty, value);
		}
		static void OnShouldObeyRtlChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var add = newValue != null;
			AddRemoveEffect(bindable, add);
		}
		// .. other properties
		// helper method
		static void AddRemoveEffect(BindableObject bindable, bool add)
		{
			var view = bindable as View;
			if (view == null)
			{
				return;
			}
			if (add)
			{
				if (view.Effects.Count == 0)
				{
					// shortcut to add if there are none already
					view.Effects.Add(new AddRtlEffect());
				}
				else
				{
					// more expensive check to see if it exists before adding
					var exists = view.Effects.First(e => e is AddRtlEffect);
					if (exists == null)
					{
						view.Effects.Add(new AddRtlEffect());
					}
				}
			}
			else
			{
				var toRemove = view.Effects.FirstOrDefault(e => e is AddRtlEffect);
				if (toRemove != null)
				{
					view.Effects.Remove(toRemove);
				}
			}
		}
		public class AddRtlEffect : RoutingEffect
		{
			// string identifier matches [assembly] attributes in the platform-specific projects
			public AddRtlEffect() : base("MyCompany.AddRtlEffect")
			{
			}
		}
	}
}
