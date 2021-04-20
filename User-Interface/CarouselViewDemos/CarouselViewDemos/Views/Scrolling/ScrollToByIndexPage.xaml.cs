using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class ScrollToByIndexPage : ContentPage
    {
        public ScrollToByIndexPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            carouselView.ScrollTo(6, position: (ScrollToPosition)enumPicker.SelectedItem, animate: animateSwitch.IsToggled);
        }

        void OnCarouselViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Debug.WriteLine("HorizontalDelta: " + e.HorizontalDelta);
            Debug.WriteLine("VerticalDelta: " + e.VerticalDelta);
            Debug.WriteLine("HorizontalOffset: " + e.HorizontalOffset);
            Debug.WriteLine("VerticalOffset: " + e.VerticalOffset);
            Debug.WriteLine("FirstVisibleItemIndex: " + e.FirstVisibleItemIndex);
            Debug.WriteLine("CenterItemIndex: " + e.CenterItemIndex);
            Debug.WriteLine("LastVisibleItemIndex: " + e.LastVisibleItemIndex);
        }
    }
}
