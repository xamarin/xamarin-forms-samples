using System;
using Newtonsoft.Json;
using Notes.Models;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(NavigationData), nameof(NavigationData))]
    public partial class NoteEntryPage : ContentPage
    {
        public string NavigationData
        {
            set
            {
                // URL-decode the JSON string passed to the page, deserialize it into
                // a Note object, and set it as the BindingContext of the page.
                BindingContext = JsonConvert.DeserializeObject<Note>(Uri.UnescapeDataString(value));
            }
        }

        public NoteEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }
    }
}
