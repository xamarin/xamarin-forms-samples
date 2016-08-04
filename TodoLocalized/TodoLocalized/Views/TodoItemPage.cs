using TodoLocalized.Resx;
using Xamarin.Forms;

namespace TodoLocalized
{
    public class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var nameLabel = new Label (); // no Text! localized later
			var nameEntry = new Entry ();
			
			nameEntry.SetBinding (Entry.TextProperty, "Name");

			var notesLabel = new Label (); // no Text! localized later
			var notesEntry = new Entry ();
			notesEntry.SetBinding (Entry.TextProperty, "Notes");

			var doneLabel = new Label (); // no Text! localized later
			var doneEntry = new Switch ();
			doneEntry.SetBinding (Switch.IsToggledProperty, "Done");

			var saveButton = new Button (); // no Text! localized later
			saveButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.SaveItem(todoItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button (); // no Text! localized later
			deleteButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				App.Database.DeleteItem(todoItem.ID);
                this.Navigation.PopAsync();
			};
							
			var cancelButton = new Button (); // no Text! localized later
			cancelButton.Clicked += (sender, e) => {
                this.Navigation.PopAsync();
			};

			var speakButton = new Button (); // no Text! localized later
			speakButton.Clicked += (sender, e) => {
				var todoItem = (TodoItem)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};


			// TODO: Forms Localized text using two different methods:

			// refer to the codebehind for AppResources.resx.designer
			nameLabel.Text = AppResources.NameLabel;
			notesLabel.Text = AppResources.NotesLabel;
			doneLabel.Text = AppResources.DoneLabel;

			// using ResourceManager
			saveButton.Text = AppResources.SaveButton;
			deleteButton.Text = L10n.Localize ("DeleteButton", "Delete");
			cancelButton.Text = L10n.Localize ("CancelButton", "Cancel");
			speakButton.Text = L10n.Localize ("SpeakButton", "Speak");

			// HACK: included as a 'test' for localizing the picker
			// currently not saved to database
			//var dueDateLabel = new Label { Text = "Due" };
			//var dueDatePicker = new DatePicker ();

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, nameEntry, 
					notesLabel, notesEntry,
					doneLabel, doneEntry,
					//dueDateLabel, dueDatePicker,
					saveButton, deleteButton, cancelButton, speakButton
				}
			};
		}
	}
}