using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class PlatformSpecificsPageCS : ContentPage
    {
        Page _originalRoot;

		public ICommand NavigateCommand { get; private set; }

        public PlatformSpecificsPageCS()
        {
			NavigateCommand = new Command<Type>(async (pageType) => await NavigateToPage(pageType));
            BindingContext = this;

            Title = "Platform Specifics Demo";
            Content = new TableView
            {
                Intent = TableIntent.Menu,
                Root = new TableRoot
                {
                    new TableSection("iOS")
                    {
                        new TextCell { Text="Visual Element Blur Effect", Command = NavigateCommand, CommandParameter = typeof(iOSBlurEffectPageCS) },
                        new TextCell { Text="Large Title Display", Command = NavigateCommand, CommandParameter = typeof(iOSLargeTitlePageCS) },
                        new TextCell { Text="Safe Area Layout Guide", Command = NavigateCommand, CommandParameter = typeof(iOSSafeAreaPageCS) },
                        new TextCell { Text="Translucent Navigation Bar", Command = NavigateCommand, CommandParameter = typeof(iOSTranslucentNavigationBarPageCS) },
                        new TextCell { Text="Entry FontSize and CursorColor", Command = NavigateCommand, CommandParameter = typeof(iOSEntryPageCS) },
                        new TextCell { Text="Hide Status Bar", Command = NavigateCommand, CommandParameter = typeof(iOSStatusBarPageCS) },
                        new TextCell { Text="Picker UpdateMode", Command = NavigateCommand, CommandParameter = typeof(iOSPickerPageCS) },
                        new TextCell { Text="ScrollView DelayContentTouches", Command = NavigateCommand, CommandParameter = typeof(iOSScrollViewPageCS) },
                        new TextCell { Text="NavigationPage Status Bar Text Color Mode", Command = NavigateCommand, CommandParameter = typeof(iOSStatusBarTextColorModePageCS) },
                        new TextCell { Text = "ListView Platform-Specifics", Command = NavigateCommand, CommandParameter = typeof(iOSListViewPageCS) },
                        new TextCell { Text = "ListView/Cell Platform-Specifics", Command = NavigateCommand, CommandParameter = typeof(iOSListViewWithCellPageCS) },
                        new TextCell { Text = "VisualElement Legacy Color Mode", Command = NavigateCommand, CommandParameter = typeof(LegacyColorModePageCS) },
                        new TextCell { Text = "VisualElement Shadow Effect", Command = NavigateCommand, CommandParameter = typeof(iOSShadowEffectPageCS) },
                        new TextCell { Text = "Application PanGestureRecognizer", Command = NavigateCommand, CommandParameter = typeof(iOSPanGestureRecognizerPageCS) },
                        new TextCell { Text = "Slider Update on Tap", Command = NavigateCommand, CommandParameter = typeof(iOSSliderUpdateOnTapPageCS) },
                        new TextCell { Text = "NavigationPage NavigationBarSeparator", Command = NavigateCommand, CommandParameter = typeof(iOSTitleViewPageCS) },
                        new TextCell { Text = "iPad Page Modal FormSheet Page", Command = NavigateCommand, CommandParameter = typeof(iOSModalFormSheetPageCS) },
                        new TextCell { Text = "Hide Home Indicator on Page", Command = NavigateCommand, CommandParameter = typeof(iOSHideHomeIndicatorPageCS) },
                        new TextCell { Text = "SwipeView SwipeTransitionMode", Command = NavigateCommand, CommandParameter = typeof(iOSSwipeViewTransitionModePageCS) },
                        new TextCell { Text = "DatePicker UpdateMode", Command = NavigateCommand, CommandParameter = typeof(iOSDatePickerPageCS) },
                        new TextCell { Text = "TimePicker UpdateMode", Command = NavigateCommand, CommandParameter = typeof(iOSTimePickerPageCS) },
                        new TextCell { Text = "VisualElement First Responder", Command = NavigateCommand, CommandParameter = typeof(iOSFirstResponderPageCS) },
                        new TextCell { Text = "TabbedPage Translucent TabBar", Command = NavigateCommand, CommandParameter = typeof(iOSTranslucentTabbedPageCS) }
                    },
                    new TableSection("Android")
                    {
                        new TextCell { Text = "Soft Input Mode Adjust", Command = NavigateCommand, CommandParameter = typeof(AndroidSoftInputModeAdjustPageCS) },
                        new TextCell { Text = "Pause and Resume Lifecyle Events", Command = NavigateCommand, CommandParameter = typeof(AndroidLifecycleEventsPageCS) },
                        new TextCell { Text = "TabbedPage Swipe, Smooth Scroll, Toolbar Placement", Command = NavigateCommand, CommandParameter = typeof(AndroidTabbedPageSwipePageCS) },
                        new TextCell { Text = "ListView Fast Scroll", Command = NavigateCommand, CommandParameter = typeof(AndroidListViewFastScrollPageCS) },
                        new TextCell { Text = "Elevation", Command = NavigateCommand, CommandParameter = typeof(AndroidElevationPageCS) },
                        new TextCell { Text = "Entry ImeOptions", Command = NavigateCommand, CommandParameter = typeof(AndroidEntryPageCS) },
                        new TextCell { Text = "WebView Mixed Content", Command = NavigateCommand, CommandParameter = typeof(AndroidWebViewPageCS) },
                        new TextCell { Text = "VisualElement Legacy Color Mode", Command = NavigateCommand, CommandParameter = typeof(LegacyColorModePageCS) },
                        new TextCell { Text = "Button Default Padding/Shadow", Command = NavigateCommand, CommandParameter = typeof(AndroidButtonPageCS) },
                        new TextCell { Text = "NavigationPage BarHeight", Command = NavigateCommand, CommandParameter = typeof(AndroidTitleViewPageCS) },
                        new TextCell { Text = "ImageButton Shadow Effect", Command = NavigateCommand, CommandParameter = typeof(AndroidImageButtonPageCS) },
                        new TextCell { Text = "WebView Zoom Controls", Command = NavigateCommand, CommandParameter = typeof(AndroidWebViewZoomPageCS) },
                        new TextCell { Text = "ViewCell Context Actions", Command = NavigateCommand, CommandParameter = typeof(AndroidViewCellPageCS) },
                        new TextCell { Text = "SwipeView SwipeTransitionMode", Command = NavigateCommand, CommandParameter = typeof(AndroidSwipeViewTransitionModePageCS) }
                    },
                    new TableSection("UWP")
                    {
                        new TextCell { Text = "TabbedPage Toolbar Location", Command = NavigateCommand, CommandParameter = typeof(WindowsTabbedPageCS) },
                        new TextCell { Text = "NavigationPage Toolbar Location", Command = NavigateCommand, CommandParameter = typeof(WindowsNavigationPageCS) },
                        new TextCell { Text = "MasterDetailPage Toolbar Location", Command = NavigateCommand, CommandParameter = typeof(WindowsMasterDetailPageCS) },
                        new TextCell { Text = "WebView JavaScript Alert", Command = NavigateCommand, CommandParameter = typeof(WindowsWebViewPageCS) },
                        new TextCell { Text = "Text Reading Order", Command = NavigateCommand, CommandParameter = typeof(WindowsReadingOrderPageCS) },
                        new TextCell { Text = "SearchBar Spell Check", Command = NavigateCommand, CommandParameter = typeof(WindowsSearchBarPageCS) },
                        new TextCell { Text = "VisualElement Legacy Color Mode", Command = NavigateCommand, CommandParameter = typeof(WindowsLegacyColorModePageCS) },
                        new TextCell { Text = "ListView Selection Mode", Command = NavigateCommand, CommandParameter = typeof(WindowsListViewPageCS) },
                        new TextCell { Text = "VisualElement Access Keys", Command = NavigateCommand, CommandParameter = typeof(WindowsVisualElementAccessKeysPageCS) },
                        new TextCell { Text = "TabbedPage Icons", Command = NavigateCommand, CommandParameter = typeof(WindowsTabbedPageIconsCS) },
                        new TextCell { Text = "RefreshView Pull Direction", Command = NavigateCommand,  CommandParameter = typeof(WindowsRefreshViewPageCS) },
                        new TextCell { Text = "Image Search Directory", Command = NavigateCommand, CommandParameter = typeof(WindowsImageSearchDirectoryPageCS) }
                    }
                }
            };         
        }

		async Task NavigateToPage(Type pageType)
        {
            Type[] types = new Type[] { typeof(Command) };
            ConstructorInfo info = pageType.GetConstructor(types);
            if (info != null)
            {
                Page page = (Xamarin.Forms.Page)Activator.CreateInstance(pageType, new Command(RestoreOriginal));
                if (page is iOSLargeTitlePageCS || page is iOSTranslucentNavigationBarPageCS)
                {
                    page = new iOSNavigationPage(page);
                }
                else if (page is iOSTitleViewPageCS)
                {
                    page = new iOSTitleViewNavigationPage(page);
                }
                else if (page is AndroidTitleViewPageCS)
                {
                    page = new AndroidNavigationPageCS(page);
                }
                SetRoot(page);
            }
            else
            {
                Page page = (Xamarin.Forms.Page)Activator.CreateInstance(pageType);
                if (page is iOSModalFormSheetPageCS)
                {
                    await Navigation.PushModalAsync(page);
                }
                else
                {
                    await Navigation.PushAsync(page);
                }
            }
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
