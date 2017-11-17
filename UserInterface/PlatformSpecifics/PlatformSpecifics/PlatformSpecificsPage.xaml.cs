using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class PlatformSpecificsPage : ContentPage
    {
        Page _originalRoot;

        public PlatformSpecificsPage()
        {
            InitializeComponent();
        }

        async void OnBlurEffectButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new iOSBlurEffectPage());
        }

        void OnLargeTitleDisplayButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new iOSNavigationPage(new iOSLargeTitlePage(new Command(RestoreOriginal))));
        }

        async void OnSafeAreaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new iOSSafeAreaPage());
        }

        void OnTranslucentNavigationBarButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new iOSNavigationPage(new iOSTranslucentNavigationBarPage(new Command(RestoreOriginal))));
        }

        async void OnEntryFontSizeChangesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new iOSEntryPage());
        }

        async void OnHideStatusBarButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new iOSStatusBarPage());
        }

        async void OnPickerUpdateModeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new iOSPickerPage());
        }

        void OnScrollViewButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new iOSScrollViewPage(new Command(RestoreOriginal)));
        }

        void OnStatusBarTextColorModeClicked(object sender, EventArgs e)
        {
            SetRoot(new iOSStatusBarTextColorModePage(new Command(RestoreOriginal)));
        }

        async void OnSoftInputModeAdjustButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidSoftInputModeAdjustPage());
        }

        async void OnPageLifecycleEventsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidLifecycleEventsPage());
        }

        void OnTabbedPageSwipeButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new AndroidTabbedPageSwipePage(new Command(RestoreOriginal)));
        }

        async void OnListViewFastScrollButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidListViewFastScrollPage());
        }

        async void OnElevationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AndroidElevationPage());
        }

        void OnTabbedPageButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new WindowsTabbedPage(new Command(RestoreOriginal)));
        }

        void OnNavigationPageButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new WindowsNavigationPage(new Command(RestoreOriginal)));
        }

        void OnMasterDetailPageButtonClicked(object sender, EventArgs e)
        {
            SetRoot(new WindowsMasterDetailPage(new Command(RestoreOriginal)));
        }

        void SetRoot(Page page)
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
