using System;
using ExpanderDemos.Controls;
using Xamarin.Forms;

namespace ExpanderDemos.Views
{
    public partial class AnimationExpanderPage : ContentPage
    {

        public AnimationExpanderPage()
        {
            InitializeComponent();

			expandAnimationLengthPicker.SelectedIndex = 0;
			collapseAnimationLengthPicker.SelectedIndex = 0;
        }

        void OnExpandAnimationSelectedIndexChanged(object sender, EventArgs e)
        {
			EnumPicker enumPicker = sender as EnumPicker;
			string easingFunction = enumPicker.ItemsSource[enumPicker.SelectedIndex].ToString();
			expander.ExpandAnimationEasing = GetEasingFunction(easingFunction);
        }

		void OnCollapseAnimationSelectedIndexChanged(object sender, EventArgs e)
		{
			EnumPicker enumPicker = sender as EnumPicker;
			string easingFunction = enumPicker.ItemsSource[enumPicker.SelectedIndex].ToString();
			expander.CollapseAnimationEasing = GetEasingFunction(easingFunction);
		}

        void OnExpandAnimationLengthSelectedIndexChanged(object sender, EventArgs e)
        {
			expander.ExpandAnimationLength = Convert.ToUInt32((sender as Picker).SelectedItem);
        }

		void OnCollapseAnimationLengthSelectedIndexChanged(object sender, EventArgs e)
		{
			expander.CollapseAnimationLength = Convert.ToUInt32((sender as Picker).SelectedItem);
		}

		Easing GetEasingFunction(string name)
		{
			EasingFunction easingFunction = EnumUtils.ParseEnum<EasingFunction>(name);

			switch (easingFunction)
			{
				case EasingFunction.BounceIn:
					return Easing.BounceIn;
				case EasingFunction.BounceOut:
					return Easing.BounceOut;
				case EasingFunction.CubicIn:
					return Easing.CubicIn;
				case EasingFunction.CubicOut:
					return Easing.CubicOut;
				case EasingFunction.CubicInOut:
					return Easing.CubicInOut;
				case EasingFunction.SinIn:
					return Easing.SinIn;
				case EasingFunction.SinOut:
					return Easing.SinOut;
				case EasingFunction.SinInOut:
					return Easing.SinInOut;
				case EasingFunction.SpringIn:
					return Easing.SpringIn;
				case EasingFunction.SpringOut:
					return Easing.SpringOut;
				case EasingFunction.Custom1:
					return new Easing(t => (int)(5 * t) / 5.0);
				case EasingFunction.Custom2:
					return new Easing(t => 9 * t * t * t - 13.5 * t * t + 5.5 * t);
				case EasingFunction.Custom3:
					return new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t));
				case EasingFunction.Linear:
				default:
					return Easing.Linear;
			}
		}

	}
}
