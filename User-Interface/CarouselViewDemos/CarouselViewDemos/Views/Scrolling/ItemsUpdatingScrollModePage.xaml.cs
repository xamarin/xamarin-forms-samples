using Xamarin.Forms;
using System;
using CarouselViewDemos.Controls;

namespace CarouselViewDemos.Views
{
    public partial class ItemsUpdatingScrollModePage : ContentPage
    {
        public ItemsUpdatingScrollModePage()
        {
            InitializeComponent();
        }

        void OnItemsUpdatingScrollModeChanged(object sender, EventArgs e)
        {
            carouselView.ItemsUpdatingScrollMode = (ItemsUpdatingScrollMode)(sender as EnumPicker).SelectedItem;
        }
    }
}
