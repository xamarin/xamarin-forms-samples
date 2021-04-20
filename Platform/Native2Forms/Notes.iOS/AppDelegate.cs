using System;
using System.IO;
using Foundation;
using Notes.Controllers;
using Notes.iOS.Models;
using Notes.iOS.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Notes.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public static AppDelegate Instance;
        UIWindow _window;
        AppNavigationController _navigation;

        public static string FolderPath { get; private set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            // Create app-level resource dictionary.
            Xamarin.Forms.Application.Current = new Xamarin.Forms.Application();
            Xamarin.Forms.Application.Current.Resources = new MyDictionary();

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            NotesPage notesPage = new NotesPage()
            {
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };

            UIViewController notesPageController = notesPage.CreateViewController();
            notesPageController.Title = "Notes";

            _navigation = new AppNavigationController(notesPageController);

            _window.RootViewController = _navigation;
            _window.MakeKeyAndVisible();

            notesPage.Parent = null;
            return true;
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            NoteEntryPage noteEntryPage = new NoteEntryPage
            {
                BindingContext = note,
                // Set the parent so that the app-level resource dictionary can be located.
                Parent = Xamarin.Forms.Application.Current
            };

            var noteEntryViewController = noteEntryPage.CreateViewController();
            noteEntryViewController.Title = "Note Entry";

            _navigation.PushViewController(noteEntryViewController, true);
            noteEntryPage.Parent = null;
        }

        public void NavigateBack()
        {
            _navigation.PopViewController(true);
        }
    }
}