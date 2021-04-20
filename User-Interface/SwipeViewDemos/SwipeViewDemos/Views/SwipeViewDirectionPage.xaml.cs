using System;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewDirectionPage : ContentPage
    {
        public SwipeViewDirectionPage()
        {
            InitializeComponent();
        }

        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }

        async void OnShareSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Share invoked.", "OK");
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }
    }
}
