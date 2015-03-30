using System;
using Xamarin.Forms;

namespace WorkingWithPlatformSpecifics
{
	public class DevicePage : ContentPage
	{
		/// <summary>
		/// This page demonstrates the different ways to use the Device class
		/// to perform platform-specific operations like changing the UI
		/// based on which 
		/// </summary>
		public DevicePage ()
		{

			var heading = new Label { 
				Text = "Heading", 
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
			};

			switch (Device.Idiom)
			{
			case TargetIdiom.Phone:
				heading.Text += " Phone ";
				break;
			case TargetIdiom.Tablet:
				heading.Text += " Tablet ";
				break;
			case TargetIdiom.Desktop:
				heading.Text += " Desktop ";
				break;
			default:
				heading.Text += " unknown ";
				break;
			}
			//
			// Device.OS == TargetPlatform iOS Android WinPhone
			//
			if (Device.OS == TargetPlatform.iOS) {
				heading.Text += "iOS";
			} else { // could be TargetPlatform.Android or TargetPlatform.WinPhone
				heading.Text += Device.OS;
			}

			var timer = new Label { 
				Text = "click start below"
			};


			//
			// Device.OnPlatform (Action)
			//
			var box = new BoxView {
				Color = Color.Green,
				WidthRequest = Device.OnPlatform (30, 40, 50),
				HorizontalOptions = LayoutOptions.Center
			};
			Device.OnPlatform(
				iOS: () =>{
					box.Color = box.Color.MultiplyAlpha(0.5);
					heading.TextColor = Color.Blue;
				},
				Android: () =>{
					box.Color = box.Color.AddLuminosity(0.3);
					heading.TextColor = Color.FromRgb(115, 129, 130);
				},
				WinPhone: () =>{
					box.Color = box.Color.AddLuminosity(0.3);
					heading.TextColor = Color.Accent;
				}, 
				Default: () =>{
					heading.Text = "what platform is this?!" + Device.OS;
				}
			);




			//
			// Device.OnPlatform<T>
			//
			var timerButton = new Button { 
				Text = "Start Timer",
				BackgroundColor = Color.Gray.MultiplyAlpha(0.5),
				HorizontalOptions = LayoutOptions.Center
			};
			timerButton.WidthRequest = Device.OnPlatform (200, 300, 100);


			//
			// Device.StartTimer     and     Device.BeginInvokeOnMainThread
			//
			timerButton.Clicked += (sender, e) => {
				timer.Text = "timer running...";
				Device.StartTimer (new TimeSpan (0, 0, 10), () => {
					// do something every 10 seconds

					Device.BeginInvokeOnMainThread ( () => {
						// interact with UI elements
						timer.Text = 
							DateTime.Now.ToString("mm:ss") + " past the hour";
					});


					return true; // runs again, or false to stop
				});
			};



			//
			// Device.OpenUri
			//
			var webButton = new Button { 
				Text = "Open Uri"
			};
			webButton.Clicked += ((sender, e) => 
				Device.OpenUri(new Uri("http://xamarin.com/evolve")));



			//
			// Device.OnPlatform<T>
			//
			Content = new StackLayout { 
				Padding = new Thickness (5, Device.OnPlatform(20,0,0), 5, 0),
				Children = {
					heading,
					box,
					webButton,
					timer,
					timerButton
				}
			};
		}
	}
}

