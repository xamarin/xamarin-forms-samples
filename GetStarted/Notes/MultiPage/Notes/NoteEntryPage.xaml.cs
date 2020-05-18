using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryView : ContentView
    {
        public NoteEntryView()
        {
            InitializeComponent();
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
                ((Note)BindingContext).Filename = filename;
            }
            else
            {
                // Update 
                File.WriteAllText(note.Filename, note.Text);
            }

            MainPage.Current.RefreshData();
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            BindingContext = new Note();
            MainPage.Current.RefreshData();
        }
    }
}
