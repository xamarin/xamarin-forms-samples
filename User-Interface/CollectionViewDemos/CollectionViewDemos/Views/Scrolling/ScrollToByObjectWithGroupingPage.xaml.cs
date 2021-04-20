using System;
using System.Diagnostics;
using System.Linq;
using CollectionViewDemos.Models;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class ScrollToByObjectWithGroupingPage : ContentPage
    {
        public ScrollToByObjectWithGroupingPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            GroupedAnimalsViewModel viewModel = BindingContext as GroupedAnimalsViewModel;
            AnimalGroup group = viewModel.Animals.FirstOrDefault(a => a.Name == "Monkeys");
            Animal monkey = group.FirstOrDefault(m => m.Name == "Proboscis Monkey");
            collectionView.ScrollTo(monkey, group, (ScrollToPosition)enumPicker.SelectedItem, animateSwitch.IsToggled);
        }

        void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
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
