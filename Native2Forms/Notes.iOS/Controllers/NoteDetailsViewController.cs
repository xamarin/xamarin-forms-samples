using Notes.iOS.Models;
using Notes.iOS.Views;
using UIKit;
using Xamarin.Forms;

namespace Notes.Controllers
{
    public class NoteDetailsViewController : UIViewController
    {
        readonly Note _note;
        bool _appeared;
        ContentPage _formsContentPage;
        UIViewController _formsViewController;
        bool _disposed;

        public NoteDetailsViewController(Note note)
        {
            _note = note;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _formsContentPage = new NoteDetailsPage
            {
                BindingContext = _note
            };

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