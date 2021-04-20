using System;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewEventsPage : ContentPage
    {
        public SwipeViewEventsPage()
        {
            InitializeComponent();
        }

        void OnSwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            Console.WriteLine($"\tSwipeStarted: Direction - {e.SwipeDirection}");
        }

        void OnSwipeChanging(object sender, SwipeChangingEventArgs e)
        {
            Console.WriteLine($"\tSwipeChanging: Direction - {e.SwipeDirection}, Offset - {e.Offset}");
        }

        void OnSwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            Console.WriteLine($"\tSwipEnded: Direction - {e.SwipeDirection}");
        }
        
        void OnCloseRequested(object sender, EventArgs e)
        {
            Console.WriteLine("\tCloseRequested.");
        }

        void OnCloseButtonClicked(object sender, EventArgs e)
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
