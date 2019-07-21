using System;
using System.IO;
using Foundation;
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
        public static string FolderPath { get; private set; }

        public static AppDelegate Instance;

        UIWindow _window;
        UINavigationController _navigation;
        UIViewController _noteEntryPage;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            UIViewController mainPage = new NotesPage().CreateViewController();
            mainPage.Title = "Notes";

            _navigation = new UINavigationController(mainPage);
            _window.RootViewController = _navigation;
            _window.MakeKeyAndVisible();

            return true;
        }

        public void NavigateToNoteEntryPage(Note note)
        {
            _noteEntryPage = new NoteEntryPage
            {
                BindingContext = note
            }.CreateViewController();
            _noteEntryPage.Title = "Note Entry";
            _navigation.PushViewController(_noteEntryPage, true);
        }

        public void NavigateBack()
        {
            _navigation.PopViewController(true);
        }

        public void DisposeNoteEntryPage()
        {
            _noteEntryPage.Dispose();
            _noteEntryPage = null;
        }
    }
}
