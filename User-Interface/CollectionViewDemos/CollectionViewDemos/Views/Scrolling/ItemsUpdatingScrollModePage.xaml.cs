using CollectionViewDemos.Controls;
using CollectionViewDemos.ViewModels;
using System;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class ItemsUpdatingScrollModePage : ContentPage
    {
        public ItemsUpdatingScrollModePage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModelWithDelay();
        }

        void OnItemsUpdatingScrollModeChanged(object sender, EventArgs e)
        {
            collectionView.ItemsUpdatingScrollMode = (ItemsUpdatingScrollMode)(sender as EnumPicker).SelectedItem;
        }
    }
}
