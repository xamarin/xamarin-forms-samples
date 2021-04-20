using System;
using System.IO;
using Notes.Droid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(MainActivity.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update 
                File.WriteAllText(note.Filename, note.Text);
            }

            MainActivity.Instance.NavigateBack();
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            MainActivity.Instance.NavigateBack();
        }
    }
}
