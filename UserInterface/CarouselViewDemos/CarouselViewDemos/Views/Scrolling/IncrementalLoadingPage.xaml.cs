using System;
using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class IncrementalLoadingPage : ContentPage
    {
        public IncrementalLoadingPage()
        {
            InitializeComponent();
        }

        void OnCarouselViewRemainingItemsThresholdReached(object sender, EventArgs e)
        {
            // Retrieve more data here, or via the RemainingItemsThresholdReachedCommand.
            // This sample retrieves more data using the RemainingItemsThresholdReachedCommand.
        }
    }
}
