using System;
using Xamarin.Forms;

namespace FlexLayoutDemos
{
	public partial class BasisExperimentPage : ContentPage
	{
		public BasisExperimentPage ()
		{
			InitializeComponent ();
		}

        // Label 2 event handlers
        void OnLabel2AutoSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                System.Diagnostics.Debug.WriteLine("Switch 2 On");
                FlexLayout.SetBasis(label2, FlexBasis.Auto);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Switch 2 Off");
                FlexLayout.SetBasis(label2, new FlexBasis((float)slider2.Value, relativeSwitch2.IsToggled));
            }
        }

        void OnLabel2IsRelativeSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                // From absolute to relative
                double value = slider2.Value;
                slider2.Maximum = 1;
                slider2.Value = value / 1000;
            }
            else
            {
                // From relative to absolute
                double value = slider2.Value;
                slider2.Maximum = 1000;
                slider2.Value = 1000 * value;
            }
        }

        void OnLabel2SliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            FlexLayout.SetBasis(label2, new FlexBasis((float)args.NewValue, relativeSwitch2.IsToggled));
        }

        // Label 4 event handlers
        void OnLabel4AutoSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                System.Diagnostics.Debug.WriteLine("Switch 4 On");
                FlexLayout.SetBasis(label4, FlexBasis.Auto);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Switch 4 Off");
                FlexLayout.SetBasis(label4, new FlexBasis((float)slider4.Value, relativeSwitch4.IsToggled));
            }
        }

        void OnLabel4IsRelativeSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                // From absolute to relative
                double value = slider4.Value;
                slider4.Maximum = 1;
                slider4.Value = value / 1000;
            }
            else
            {
                // From relative to absolute
                double value = slider4.Value;
                slider4.Maximum = 1000;
                slider4.Value = 1000 * value;
            }
        }

        void OnLabel4SliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            FlexLayout.SetBasis(label4, new FlexBasis((float)args.NewValue, relativeSwitch4.IsToggled));
        }
    }
}