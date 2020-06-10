using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class StackLayoutDemo : ContentPage
	{
		int currentState = 0;
		int maxStates = 2;
		public StackLayoutDemo ()
		{
			InitializeComponent ();
			StackChangeButton.Clicked += StackChangeButton_Clicked;
		}

		void StackChangeButton_Clicked (object sender, EventArgs e)
		{
			currentState++;
			if (currentState > maxStates) {
				currentState = 0;
			}

			switch (currentState) {
			case 0:
				layout.Spacing = 0;
				StackChangeButton.Text = "Spacing: 0";
				break;
			case 1:
				layout.Spacing = 1;
				StackChangeButton.Text = "Spacing: 1";
				break;
			case 2:
				layout.Spacing = 10;
				StackChangeButton.Text = "Spacing: 10";
				break;
			}


		}
	}
}

