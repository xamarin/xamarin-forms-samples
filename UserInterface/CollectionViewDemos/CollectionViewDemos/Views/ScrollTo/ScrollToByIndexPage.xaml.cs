using System;
using Xamarin.Forms;
using CollectionViewDemos.ViewModels;

namespace CollectionViewDemos.Views
{
    public partial class ScrollToByIndexPage : ContentPage
    {
        public ScrollToByIndexPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            collectionView.ScrollTo(12, position: (ScrollToPosition)enumPicker.SelectedItem, animate: animateSwitch.IsToggled);
        }
    }
}
