using System;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace WorkingWithBehaviors
{
	public class EmailValidationBehavior : Behavior<Entry>
	{
		static readonly BindablePropertyKey IsValidPropertyKey =
			BindableProperty.CreateReadOnly("IsValid", 
				typeof(bool), 
				typeof(EmailValidationBehavior),
				false);

		public static readonly BindableProperty IsValidProperty = 
			IsValidPropertyKey.BindableProperty;

		public bool IsValid
		{
			private set { SetValue(IsValidPropertyKey, value); }
			get { return (bool)GetValue(IsValidProperty); }
		}

		protected override void OnAttachedTo(Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(entry);
		}

		protected override void OnDetachingFrom(Entry entry)
		{
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(entry);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			Entry entry = (Entry)sender;
			IsValid = IsValidEmail(entry.Text);
		}

		bool IsValidEmail(string strIn)
		{
			if (String.IsNullOrEmpty(strIn))
				return false;

			try
			{
				return Regex.IsMatch(strIn,
					@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
					@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}
		}
	}
}

