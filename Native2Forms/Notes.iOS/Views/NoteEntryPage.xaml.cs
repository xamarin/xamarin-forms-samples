using System;
using System.IO;
using Notes.iOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.iOS.Views
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
                var filename = Path.Combine(AppDelegate.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update 
                File.WriteAllText(note.Filename, note.Text);
            }

            AppDelegate.Instance.NavigateBack();
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            AppDelegate.Instance.NavigateBack();
        }
    }
}
