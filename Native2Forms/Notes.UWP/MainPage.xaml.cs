using Notes.UWP.Models;
using Notes.UWP.Views;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Core;

namespace Notes.UWP
{
    public sealed partial class MainPage : Page
    {
        NotesPage notesPage;
        NoteEntryPage noteEntryPage;

        public static MainPage Instance;

        public static string FolderPath { get; private set; }

        public MainPage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            Instance = this;
            FolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            notesPage = new Notes.UWP.Views.NotesPage
            {
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };
            this.Content = notesPage.CreateFrameworkElement();

            this.Loaded += OnMainPageLoaded;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            notesPage.Parent = null;
        }

        void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
                noteEntryPage = null;
            }
        }

        void OnMainPageLoaded(object sender, RoutedEventArgs e)
        {
            this.Frame.SizeChanged += (o, args) =>
            {
                if (noteEntryPage != null)
                    noteEntryPage.Layout(new Xamarin.Forms.Rectangle(0, 0, args.NewSize.Width, args.NewSize.Height));
                else
                    notesPage.Layout(new Xamarin.Forms.Rectangle(0, 0, args.NewSize.Width, args.NewSize.Height));
            };
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            noteEntryPage = new Notes.UWP.Views.NoteEntryPage
            {
                BindingContext = note,
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };
            this.Frame.Navigate(noteEntryPage);
            noteEntryPage.Parent = null;
        }

        public void NavigateBack()
        {
            this.Frame.GoBack();
            noteEntryPage = null;
        }
    }
}
          