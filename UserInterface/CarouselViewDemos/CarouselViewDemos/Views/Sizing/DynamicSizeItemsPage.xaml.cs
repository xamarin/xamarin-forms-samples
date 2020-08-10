using System;
using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class DynamicSizeItemsPage : ContentPage
    {
        public DynamicSizeItemsPage()
        {
            InitializeComponent();
        }

        void OnImageTapped(object sender, EventArgs e)
        {
            Image image = sender as Image;
            image.HeightRequest = image.WidthRequest = image.HeightRequest.Equals(150) ? 200 : 150;
            Frame frame = ((Frame)image.Parent.Parent);
            frame.HeightRequest = frame.HeightRequest.Equals(300) ? 350 : 300;
        }
    }
}
