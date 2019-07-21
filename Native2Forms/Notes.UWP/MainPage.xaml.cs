using Notes.UWP.Models;
using Notes.UWP.Views;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.UWP;

namespace Notes.UWP
{
    public sealed partial class MainPage : Page
    {
        public static MainPage Instance;

        public static string FolderPath { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            Instance = this;
            FolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            this.Content = new Notes.UWP.Views.NotesPage().CreateFrameworkElement();
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            this.Frame.Navigate(new NoteEntryPage
            {
                BindingContext = note
            });
        }

        public void NavigateBack()
        {
            this.Frame.GoBack();
        }
    }
}
          