using System;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewProgrammaticPage : ContentPage
    {
        public SwipeViewProgrammaticPage()
        {
            InitializeComponent();
        }

        void OnOpenSwipeViewClicked(object sender, EventArgs e)
        {
            swipeView.Open(OpenSwipeItem.LeftItems);
        }

        void OnCloseSwipeViewClicked(object sender, EventArgs e)
        {
            swipeView.Close();
        }

        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }
    }
}
