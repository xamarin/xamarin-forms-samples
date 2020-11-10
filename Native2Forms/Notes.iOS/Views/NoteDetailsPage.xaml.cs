using System;
using System.IO;
using Notes.iOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.iOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            grid.TranslateTo(0, 0, 600, Easing.BounceIn);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            grid.TranslateTo(0, -2000, 300, Easing.BounceOut);
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
