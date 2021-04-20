using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using NavigationPageTitleView.iOS;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(SearchBarEffect), "SearchBarEffect")]
namespace NavigationPageTitleView.iOS
{
    public class SearchBarEffect : PlatformEffect
    {
        UIColor _defaultBackColor;
        UIColor _defaultTintColor;
        UIImage _defaultBackImage;

        protected override void OnAttached()
        {
            if (_defaultBackColor == null)
            {
                _defaultBackColor = Control.BackgroundColor;
            }
            Control.BackgroundColor = Color.Cornsilk.ToUIColor();

            if (Control is UISearchBar searchBar)
            {
                if (_defaultTintColor == null)
                {
                    _defaultTintColor = searchBar.BarTintColor;
                }
                if (_defaultBackImage == null)
                {
                    _defaultBackImage = searchBar.BackgroundImage;
                }
                searchBar.BarTintColor = Color.Cornsilk.ToUIColor();
                searchBar.BackgroundImage = new UIImage();
            }
        }

        protected override void OnDetached()
        {
            Control.BackgroundColor = _defaultBackColor;
            if (Control is UISearchBar searchBar)
            {
                searchBar.BarTintColor = _defaultTintColor;
                searchBar.BackgroundImage = _defaultBackImage;
            }
        }
    }
}
