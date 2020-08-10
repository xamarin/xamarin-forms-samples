using System;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewResourcePage : ContentPage
    {
        public SwipeViewResourcePage()
        {
            InitializeComponent();
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

