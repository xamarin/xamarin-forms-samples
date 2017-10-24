using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class PlatformSpecificsPageCS : ContentPage
    {
        public PlatformSpecificsPageCS()
        {
            var blurButton = new Button { Text = "Blur Effect (iOS only)" };
            blurButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSBlurEffectPageCS());
            var translucentButton = new Button { Text = "Translucent Navigation Bar (iOS only) " };
            translucentButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var entryButton = new Button { Text = "Entry Font Size Adjusts to Text Width (iOS only)" };
            entryButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSEntryPageCS());
            var hideStatusBarButton = new Button { Text = "Hide Status Bar (iOS only) " };
            hideStatusBarButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSStatusBarPageCS());
            var pickerUpdateModeButton = new Button { Text = "Picker UpdateMode (iOS only)" };
            pickerUpdateModeButton.Clicked += async (sender, e) => await Navigation.PushAsync(new iOSPickerPageCS());
            var scrollViewButton = new Button { Text = "ScrollView DelayContentTouches (iOS only)" };
            scrollViewButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var statusBarTextColorModeButton = new Button { Text = "Navigation Page Status Bar Text Color Mode (iOS only)" };
            statusBarTextColorModeButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var inputModeButton = new Button { Text = "Soft Input Mode Adjust (Android only)" };
            inputModeButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidSoftInputModeAdjustPageCS());
            var lifecycleEventsButton = new Button { Text = "Pause and Resume Lifecycle Events (Android only)" };
            lifecycleEventsButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidLifecycleEventsPageCS());
            var tabbedPageSwipeButton = new Button { Text = "Tabbed Page Swipe (Android only)" };
            tabbedPageSwipeButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var listViewFastScrollButton = new Button { Text = "ListView FastScroll (Android only)" };
            listViewFastScrollButton.Clicked += async (sender, e) => await Navigation.PushAsync(new AndroidListViewFastScrollPageCS());
            var tabbedPageButton = new Button { Text = "Tabbed Page Toolbar Location Adjust (Windows only)" };
            tabbedPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var navigationPageButton = new Button { Text = "Navigation Page Toolbar Location Adjust (Windows only)" };
            navigationPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");
            var masterDetailPageButton = new Button { Text = "Master Detail Page Toolbar Location Adjust (Windows only)" };
            masterDetailPageButton.Clicked += async (sender, e) => await DisplayAlert("Alert", "Edit App.xaml.cs to view this platform specific.", "OK");

            Title = "Platform Specifics Demo";
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = { blurButton, translucentButton, entryButton, hideStatusBarButton, pickerUpdateModeButton, scrollViewButton, statusBarTextColorModeButton, inputModeButton, lifecycleEventsButton, listViewFastScrollButton, tabbedPageButton, navigationPageButton, masterDetailPageButton }
                }
            };
        }
    }
}

