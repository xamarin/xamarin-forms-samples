using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSSwipeViewTransitionModePage : ContentPage
    {
        public iOSSwipeViewTransitionModePage()
        {
            InitializeComponent();
        }

        void OnSwipeViewTransitionModeChanged(object sender, EventArgs e)
        {
            SwipeTransitionMode transitionMode = (SwipeTransitionMode)(sender as EnumPicker).SelectedItem;
            swipeView.On<iOS>().SetSwipeTransitionMode(transitionMode);
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }
    }
}
