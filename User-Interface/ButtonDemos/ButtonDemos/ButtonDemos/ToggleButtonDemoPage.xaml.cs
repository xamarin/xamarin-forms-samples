using System;
using Xamarin.Forms;

namespace ButtonDemos
{
	public partial class ToggleButtonDemoPage : ContentPage
	{
		public ToggleButtonDemoPage ()
		{
			InitializeComponent ();
		}

        void OnItalicButtonToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldButtonToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}