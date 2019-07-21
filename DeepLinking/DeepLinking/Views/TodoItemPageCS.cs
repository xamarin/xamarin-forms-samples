using System;
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
            saveButton.Clicked += OnSaveClicked;
            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += OnDeleteClicked;
            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += OnCancelClicked;

            Title = "Todo Item";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = 
                {
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

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);

            appLink = GetAppLink(BindingContext as TodoItem);
            Application.Current.AppLinks.RegisterLink(appLink);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);

            Application.Current.AppLinks.DeregisterLink(appLink);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
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
                AppLinkUri = new Uri($"http://{App.AppName}/{pageType}?id={item.ID}", UriKind.RelativeOrAbsolute),
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
