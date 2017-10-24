using System;
using Xamarin.Forms;

namespace WorkingWithPlatformSpecifics
{	
	public partial class DevicePageXaml : ContentPage
	{	
		public DevicePageXaml ()
		{
			InitializeComponent ();
		}

		void OpenUriClicked (object s, EventArgs e)
        {
			Device.OpenUri(new Uri("https://xamarin.com/about"));
		}

		void TimerClicked (object s, EventArgs e)
        {
			timer.Text = "timer running...";
			Device.StartTimer (new TimeSpan (0, 0, 10), () => 
            {
				// do something every 10 seconds
				Device.BeginInvokeOnMainThread ( () => 
                {
					// interact with UI elements
					timer.Text = 
						DateTime.Now.ToString("mm:ss") + " past the hour";
				});
				return true; // runs again, or false to stop
			});
		}
	}
}

