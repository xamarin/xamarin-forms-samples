using Xamarin.Forms;
using System.Linq;

namespace WorkingWithBehaviors
{
	public class NumericValidationBehavior : Behavior<Entry>
	{
		public static readonly BindableProperty AttachBehaviorProperty = 
			BindableProperty.CreateAttached ("AttachBehavior", typeof(bool), typeof(NumericValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

		public static bool GetAttachBehavior (BindableObject view)
		{
			return (bool)view.GetValue (AttachBehaviorProperty);
		}

		public static void SetAttachBehavior (BindableObject view, bool value)
		{
			view.SetValue (AttachBehaviorProperty, value);
		}

		static void OnAttachBehaviorChanged (BindableObject view, object oldValue, object newValue)
		{
			var entry = view as Entry;
			if (entry == null) {
				return;
			}

			bool attachBehavior = (bool)newValue;
			if (attachBehavior) {
				entry.Behaviors.Add (new NumericValidationBehavior ());
			} else {
				var toRemove = entry.Behaviors.FirstOrDefault (b => b is NumericValidationBehavior);
				if (toRemove != null) {
					entry.Behaviors.Remove (toRemove);
				}
			}
		}

		protected override void OnAttachedTo (Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo (entry);
		}

		protected override void OnDetachingFrom (Entry entry)
		{
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom (entry);
		}

		void OnEntryTextChanged (object sender, TextChangedEventArgs args)
		{
			double result;
			bool isValid = double.TryParse (args.NewTextValue, out result);
			((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
		}
	}
}

