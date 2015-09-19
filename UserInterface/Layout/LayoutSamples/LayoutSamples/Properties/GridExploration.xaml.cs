using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class GridExploration : ContentPage
	{
		int rowHeightValue = 1;
		public GridExploration ()
		{
			InitializeComponent ();
			sliderHeight.ValueChanged += SliderHeight_ValueChanged;
		}

		void SliderHeight_ValueChanged (object sender, ValueChangedEventArgs e)
		{
			if (e.NewValue * 10 > rowHeightValue + .5 && rowHeightValue < 5) {
				rowHeightValue++;
			}
			if (e.NewValue * 10 < rowHeightValue - .5 && rowHeightValue > 1) {
				rowHeightValue--;
			}
			firstRow.Height = new GridLength (rowHeightValue, GridUnitType.Star);
		}
	}
}

