using System;
using SwipeViewDemos.Controls;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewModeBehaviorPage : ContentPage
    {
        public SwipeViewModeBehaviorPage()
        {
            InitializeComponent();
        }

        void OnSwipeViewModeChanged(object sender, EventArgs e)
        {
            swipeView1.LeftItems.Mode = (SwipeMode)(sender as EnumPicker).SelectedItem;
            swipeView2.LeftItems.Mode = (SwipeMode)(sender as EnumPicker).SelectedItem;
        }

        void OnSwipeViewBehaviorChanged(object sender, EventArgs e)
        {
            swipeView1.LeftItems.SwipeBehaviorOnInvoked = (SwipeBehaviorOnInvoked)(sender as EnumPicker).SelectedItem;
            swipeView2.LeftItems.SwipeBehaviorOnInvoked = (SwipeBehaviorOnInvoked)(sender as EnumPicker).SelectedItem;
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }

        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }
    }
}

//      Auto,       // In Reveal mode, the SwipeView closes after an item is invoked. In Execute mode, the SwipeView remains open.
//		Close,      // The SwipeView closes after an item is invoked.
//		RemainOpen  // The SwipeView remains open after an item is invoked.