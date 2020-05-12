using System;
using System.IO;
using Foundation;
using Notes.Controllers;
using Notes.iOS.Models;
using Notes.iOS.Views;
using Notes.Views;
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

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            UIViewController mainPage = new NotesPage().CreateViewController();
            mainPage.Title = "Notes";

            _navigation = new AppNavigationController(mainPage);

            _window.RootViewController = _navigation;
            _window.MakeKeyAndVisible();

            return true;
        }

        public void NavigateToNoteEntryPage()
        {
            var noteEntryPage = new NoteEntryPage
            {
                BindingContext = new Note()
            }.CreateViewController();
            noteEntryPage.Title = "Note Entry";
            _navigation.PushViewController(noteEntryPage, true);
        }

        public void NavigateToNoteDetails(Note note)
        {
            _navigation.PushViewController(new NoteDetailsViewController(note), true);
        }

        public void NavigateBack()
        {
            _navigation.PopViewController(true);
        }
    }

    public class NoteDetailsViewController : UIViewController
    {
        private readonly Note _note;
        private bool _appeared;
        private ContentPage _formsContentPage;
        private UIViewController _formsViewController;
        private bool _disposed;
        
        public NoteDetailsViewController(Note note)
        {
            _note = note;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _formsContentPage = new NoteDetailsPage {BindingContext = _note};

            _formsViewController = _formsContentPage.CreateViewController();
            _formsViewController.WillMoveToParentViewController(this);

            var nativeView = _formsViewController.View;
            nativeView.TranslatesAutoresizingMaskIntoConstraints = false;

            View.Add(nativeView);
            nativeView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            nativeView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            nativeView.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            nativeView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (_appeared || _disposed)
            {
                return;
            }

            _appeared = true;
            _formsViewController.ViewDidAppear(true);
            _formsViewController.DidMoveToParentViewController(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _formsViewController?.ViewWillAppear(true);
            _formsContentPage?.SendAppearing();
        }

        public override void ViewWillDisappear(bool animated)
        {
            _formsContentPage?.SendDisappearing();
            
            base.ViewWillDisappear(animated);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (_appeared)
                {
                    _formsContentPage.SendDisappearing();
                }

                _appeared = false;
                _formsContentPage = null;
                _disposed = true;
            }
        }
    }
}