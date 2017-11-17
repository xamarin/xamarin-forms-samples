using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class PlatformSpecificsPageCS : ContentPage
    {
        Xamarin.Forms.Page _originalRoot;

        public PlatformSpecificsPageCS()
        {
            var blurButton = new Button { Text = "Blur Effect (iOS only)" };
            blurButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSBlurEffectPageCS());
            var largeTitleButton = new Button { Text = "Large Title Display (iOS only)" };
            largeTitleButton.Clicked += (sender, e) =>
            {
                var navigationPage = new Xamarin.Forms.NavigationPage(new iOSLargeTitlePageCS(new Command(RestoreOriginal)));
                navigationPage.On<iOS>().SetPrefersLargeTitles(true);
                SetRoot(navigationPage);
            };
            var safeAreaButton = new Button { Text = "Safe Area Layout Guide (iOS only)" };
            safeAreaButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSSafeAreaPageCS());
            var translucentButton = new Button { Text = "Translucent Navigation Bar (iOS only) " };
            translucentButton.Clicked += (sender, e) => SetRoot(new Xamarin.Forms.NavigationPage(new iOSTranslucentNavigationBarPageCS(new Command(RestoreOriginal))));
            var entryButton = new Button { Text = "Entry Font Size Adjusts to Text Width (iOS only)" };
            entryButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSEntryPageCS());
            var hideStatusBarButton = new Button { Text = "Hide Status Bar (iOS only) " };
            hideStatusBarButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSStatusBarPageCS());
            var pickerUpdateModeButton = new Button { Text = "Picker UpdateMode (iOS only)" };
            pickerUpdateModeButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSPickerPageCS());
            var scrollViewButton = new Button { Text = "ScrollView DelayContentTouches (iOS only)" };
            scrollViewButton.Clicked += (sender, e) => SetRoot(new iOSScrollViewPageCS(new Command(RestoreOriginal)));
            var statusBarTextColorModeButton = new Button { Text = "Navigation Page Status Bar Text Color Mode (iOS only)" };
            statusBarTextColorModeButton.Clicked += (sender, e) => SetRoot(new iOSStatusBarTextColorModePageCS(new Command(RestoreOriginal)));
            var inputModeButton = new Button { Text = "Soft Input Mode Adjust (Android only)" };
            inputModeButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidSoftInputModeAdjustPageCS());
            var lifecycleEventsButton = new Button { Text = "Pause and Resume Lifecycle Events (Android only)" };
            lifecycleEventsButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidLifecycleEventsPageCS());
            var tabbedPageSwipeButton = new Button { Text = "Tabbed Page Swipe (Android only)" };
            tabbedPageSwipeButton.Clicked += (sender, e) => SetRoot(new AndroidTabbedPageSwipePageCS(new Command(RestoreOriginal)));
            var listViewFastScrollButton = new Button { Text = "ListView FastScroll (Android only)" };
            listViewFastScrollButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidListViewFastScrollPageCS());
            var elevationButton = new Button { Text = "Elevation (Android only)" };
            elevationButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidElevationPageCS());
            var tabbedPageButton = new Button { Text = "Tabbed Page Toolbar Location Adjust (Windows only)" };
            tabbedPageButton.Clicked += (sender, e) => SetRoot(new WindowsTabbedPageCS(new Command(RestoreOriginal)));
            var navigationPageButton = new Button { Text = "Navigation Page Toolbar Location Adjust (Windows only)" };
            navigationPageButton.Clicked += (sender, e) => SetRoot(new WindowsNavigationPageCS(new Command(RestoreOriginal)));
            var masterDetailPageButton = new Button { Text = "Master Detail Page Toolbar Location Adjust (Windows only)" };
            masterDetailPageButton.Clicked += (sender, e) => SetRoot(new WindowsMasterDetailPageCS(new Command(RestoreOriginal)));

            Title = "Platform Specifics Demo";
            Content = new Xamarin.Forms.ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = { blurButton, largeTitleButton, safeAreaButton, translucentButton, entryButton, hideStatusBarButton, pickerUpdateModeButton, scrollViewButton, statusBarTextColorModeButton, inputModeButton, lifecycleEventsButton, tabbedPageSwipeButton, listViewFastScrollButton, elevationButton, tabbedPageButton, navigationPageButton, masterDetailPageButton }
                }
            };
        }

        void SetRoot(Xamarin.Forms.Page page)
        {
            var app = Application.Current as App;
            if (app == null)
            {
                return;
            }

            _originalRoot = app.MainPage;
            app.SetMainPage(page);
        }

        void RestoreOriginal()
        {
            if (_originalRoot == null)
            {
                return;
            }

            var app = Application.Current as App;
            app?.SetMainPage(_originalRoot);
        }
    }
}
