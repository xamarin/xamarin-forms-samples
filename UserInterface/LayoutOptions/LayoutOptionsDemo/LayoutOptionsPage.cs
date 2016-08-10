using System;
using Xamarin.Forms;

namespace LayoutOptionsDemo
{
	public partial class LayoutOptionsPage : ContentPage
	{
		public LayoutOptionsPage()
		{
			InitializeComponent();
		}

		void OnStartButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: Start";
			stackLayout.VerticalOptions = LayoutOptions.Start;
		}

		void OnCenterButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: Center";
			stackLayout.VerticalOptions = LayoutOptions.Center;
		}

		void OnEndButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: End";
			stackLayout.VerticalOptions = LayoutOptions.End;
		}

		void OnFillButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: Fill";
			stackLayout.VerticalOptions = LayoutOptions.Fill;
		}

		void OnStartAndExpandButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: StartAndExpand";
			stackLayout.VerticalOptions = LayoutOptions.StartAndExpand;
		}

		void OnCenterAndExpandButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: CenterAndExpand";
			stackLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
		}

		void OnEndAndExpandButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: EndAndExpand";
			stackLayout.VerticalOptions = LayoutOptions.EndAndExpand;
		}

		void OnFillAndExpandButtonClicked(object sender, EventArgs e)
		{
			Title = "StackLayout: FillAndExpand";
			stackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
		}
	}
}
