using System;
using Xamarin.Forms;

namespace WorkingWithPlatformSpecifics
{
	public partial class DevicePageXaml : ContentPage
	{
		public DevicePageXaml()
		{
			InitializeComponent();
		}

		void OpenUriClicked(object s, EventArgs e)
		{
			Device.OpenUri(new Uri("http://xamarin.com/evolve"));
		}

		void TimerClicked(object s, EventArgs e)
		{
			timer.Text = "timer running...";
			Device.StartTimer(new TimeSpan(0, 0, 10), () =>
			{
				// Do something every 10 seconds
				Device.BeginInvokeOnMainThread(() =>
				{
					// Interact with UI elements
					timer.Text = DateTime.Now.ToString("mm:ss") + " past the hour";
				});

				return true; // Runs again, or false to stop
			});
		}
	}
}

