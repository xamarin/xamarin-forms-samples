using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Notes.Droid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(MainActivity.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            listView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
        }

        void OnNoteAddedClicked(object sender, EventArgs e)
        {
            MainActivity.Instance.NavigateToNoteEntryPage(new Note());
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                MainActivity.Instance.NavigateToNoteEntryPage(e.SelectedItem as Note);
            }
        }
    }
}
