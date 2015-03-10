using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class ProgressBarDemoPage
	{
		public ProgressBarDemoPage()
		{
			InitializeComponent();
		}

		bool IsActive { get; set; }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			IsActive = true;
			Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerCallback);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			IsActive = false;
		}

		bool TimerCallback()
		{
			ProgressBar.Progress += 0.01; 
			return IsActive || ProgressBar.Progress == 1;
		}
	}
}
