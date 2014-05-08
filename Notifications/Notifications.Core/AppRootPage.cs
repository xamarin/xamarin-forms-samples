using System;
using Xamarin.Forms;

namespace Notifications.Core
{
	public class AppRootPage : ContentPage
    {
		static readonly string DefaultMessage = "Hello World!";

		IPushNotificationProxy PushProxy { get; set; }

		public AppRootPage (IPushNotificationProxy pushNotificatioProxy)
        {
			PushProxy = pushNotificatioProxy;

			Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					new Label {
						Text = DefaultMessage,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						XAlign = TextAlignment.Center,
						YAlign = TextAlignment.Center,
					},
					new Button {
						Text = "Send Notification",
						HeightRequest = 44,
						Command = new Command((b) => PushNotification.Send(this, new PushNotification { Title = DefaultMessage }))
					}
				} 
			};
        }
    }
}

