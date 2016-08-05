using System;
using System.Net;
using Xamarin.Forms;

namespace DeepLinking
{
	public class TodoItemPageCS : ContentPage
	{
		IAppLinkEntry appLink;
		bool isNewItem;

		public TodoItemPageCS() : this(false)
		{
		}

		public TodoItemPageCS(bool isNew = false)
		{
			isNewItem = isNew;

			var nameEntry = new Entry { Placeholder = "task name" };
			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var notesEntry = new Entry();
			notesEntry.SetBinding(Entry.TextProperty, "Notes");

			var doneSwitch = new Switch();
			doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += OnSaveActivated;
			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += OnDeleteActivated;
			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += OnCancelActivated;

			Title = "Todo Item";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Name" },
					nameEntry,
					new Label { Text = "Notes" },
					notesEntry,
					new Label { Text = "Done" },
					doneSwitch,
					saveButton,
					deleteButton,
					cancelButton
				}
			};
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
