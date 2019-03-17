using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OfflineCurrencyConverter.Views.Behaviors
{
    public class PlainNumericEntryBehavior : Behavior<Entry>
    {
        /// <summary>
        /// Check about value entered in the entry and convert it
        /// I use this for derived classes from this behavior.
        /// </summary>
        protected Action<Entry, string> AdditionalCheck;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += TextChanged_Handler;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        protected virtual void TextChanged_Handler(object sender, TextChangedEventArgs e)
        {
            // Short circuit for no value - accept it
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;
            else
                AdditionalCheck?.Invoke(((Entry)sender), e.OldTextValue);
        }
    }
}
