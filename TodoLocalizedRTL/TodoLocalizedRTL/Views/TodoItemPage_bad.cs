using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace Todo
{
	public class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new Entry () {HorizontalOptions = LayoutOptions.FillAndExpand};
			nameEntry.SetBinding (Entry.TextProperty, "Name");

			var notesLabel = new Label { Text = "Notes" };
			var notesEntry = new Entry () {HorizontalOptions = LayoutOptions.FillAndExpand};
			notesEntry.SetBinding (Entry.TextProperty, "Notes");

			var doneLabel = new Label { Text = "Done" };
			var doneEntry = new Switch () {HorizontalOptions = LayoutOptions.FillAndExpand};
			doneEntry.SetBinding (Switch.IsToggledProperty, "Done");

			var saveButton = new Button { Text = "Save", HorizontalOptions = LayoutOptions.FillAndExpand };
			saveButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.SaveItem(todoItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete", HorizontalOptions = LayoutOptions.FillAndExpand };
			deleteButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.DeleteItem(todoItem.ID);
                this.Navigation.PopAsync();
			};
							
			var cancelButton = new Button { Text = "Cancel", HorizontalOptions = LayoutOptions.FillAndExpand };
			cancelButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
                this.Navigation.PopAsync();
			};


			var speakButton = new Button { Text = "Speak", HorizontalOptions = LayoutOptions.FillAndExpand };
			speakButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};


			nameLabel.Text = L10n.Localize("NameLabel", "Name");
			notesLabel.Text = L10n.Localize("NotesLabel", "Notes");
			doneLabel.Text = L10n.Localize("DoneLabel", "Done");
			saveButton.Text = L10n.Localize ("SaveButton", "Save");
			deleteButton.Text = L10n.Localize ("DeleteButton", "Delete");

			// TODO: included as a 'test' for localizing the picker
			// currently not saved to database
			var dueDateLabel = new Label { Text = "Due" };
			var dueDatePicker = new DatePicker ();


			var namesp = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {nameLabel, nameEntry}
			};
			var notesp = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {notesLabel, notesEntry}
			};
			var donesp = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {doneLabel, doneEntry}
			};
			var duesp = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {dueDateLabel, dueDatePicker}
			};
			var buttons = new StackLayout { 
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {saveButton, deleteButton, cancelButton, speakButton}
			};
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					namesp,
					notesp,
					donesp,
					duesp,
					buttons
//					nameLabel, nameEntry, 
//					notesLabel, notesEntry,
//					doneLabel, doneEntry,
//					dueDateLabel, dueDatePicker,
//					saveButton, deleteButton, cancelButton,
//					speakButton
				}
			};
		}
	}
}