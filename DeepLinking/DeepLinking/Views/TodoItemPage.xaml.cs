using System;
using System.Net;
using Xamarin.Forms;

namespace DeepLinking
{
	public partial class TodoItemPage : ContentPage
	{
		IAppLinkEntry appLink;
		bool isNewItem;

		public TodoItemPage() : this(false)
		{
		}

		public TodoItemPage(bool isNew = false)
		{
			InitializeComponent();
			isNewItem = isNew;
		}

		protected override void OnAppearing()
		{
			appLink = GetAppLink(BindingContext as TodoItem);
			if (appLink != null)
			{
				appLink.IsLinkActive = true;
			}
		}

		protected override void OnDisappearing()
		{
			if (appLink != null)
			{
				appLink.IsLinkActive = false;
			}
		}

		async void OnSaveActivated(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;

			if (isNewItem)
			{
				App.Database.Insert(todoItem);
			}
			else {
				App.Database.Update(todoItem);
			}

			appLink = GetAppLink(BindingContext as TodoItem);
			Application.Current.AppLinks.RegisterLink(appLink);

			await Navigation.PopAsync();
		}

		async void OnDeleteActivated(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Database.Delete(todoItem.ID);
			Application.Current.AppLinks.DeregisterLink(appLink);

			await Navigation.PopAsync();
		}

		async void OnCancelActivated(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		AppLinkEntry GetAppLink(TodoItem item)
		{
			var pageType = GetType().ToString();
			var pageLink = new AppLinkEntry
			{
				Title = item.Name,
				Description = item.Notes,
				AppLinkUri = new Uri(string.Format("http://{0}/{1}?id={2}", App.AppName, pageType, WebUtility.UrlEncode(item.ID)), UriKind.RelativeOrAbsolute),
				IsLinkActive = true,
				Thumbnail = ImageSource.FromFile("monkey.png")
			};

			pageLink.KeyValues.Add("contentType", "TodoItemPage");
			pageLink.KeyValues.Add("appName", App.AppName);
			pageLink.KeyValues.Add("companyName", "Xamarin");

			return pageLink;
		}
	}
}
