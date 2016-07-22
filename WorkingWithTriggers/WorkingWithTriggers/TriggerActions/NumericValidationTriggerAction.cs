using System;
using Xamarin.Forms;

namespace WorkingWithTriggers
{
	/// <summary>
	/// This class is used by BOTH the C# and the XAML examples
	/// </summary>
	public class NumericValidationTriggerAction : TriggerAction<Entry> 
	{
		protected override void Invoke (Entry entry)
		{
			double result;
			bool isValid = Double.TryParse (entry.Text, out result);
			entry.TextColor = isValid ? Color.Default : Color.Red;
		}
	}
}

