using System;
using CarouselViewDemos.Controls;
using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class SnapPointsPage : ContentPage
    {
        public SnapPointsPage()
        {
            InitializeComponent();
        }

        void OnSnapPointsTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsLayout itemsLayout = (ItemsLayout)carouselView.ItemsLayout;
            itemsLayout.SnapPointsType = (SnapPointsType)(sender as EnumPicker).SelectedItem;
        }

        void OnSnapPointsAlignmentSelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsLayout itemsLayout = (ItemsLayout)carouselView.ItemsLayout;
            itemsLayout.SnapPointsAlignment = (SnapPointsAlignment)(sender as EnumPicker).SelectedItem;            
        }
    }
}
