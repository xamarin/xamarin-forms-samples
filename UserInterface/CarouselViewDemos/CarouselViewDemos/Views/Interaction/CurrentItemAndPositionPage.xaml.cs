using Xamarin.Forms;
using CarouselViewDemos.Models;

namespace CarouselViewDemos.Views
{
    public partial class CurrentItemAndPositionPage : ContentPage
    {
        Monkey previousItem;
        Monkey currentItem;
        int previousItemPosition;
        int currentItemPosition;

        public CurrentItemAndPositionPage()
        {
            InitializeComponent();
            UpdateLabels();
        }

        void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            previousItem = e.PreviousItem as Monkey;
            currentItem = e.CurrentItem as Monkey;
            UpdateLabels();
        }

        void OnPositionChanged(object sender, PositionChangedEventArgs e)
        {
            previousItemPosition = e.PreviousPosition;
            currentItemPosition = e.CurrentPosition;
            UpdateLabels();
        }

        void UpdateLabels()
        {
            previousItemLabel.Text = $"Previous item: {previousItem?.Name}";
            currentItemLabel.Text = $"Current item: {currentItem?.Name}";
            previousItemPositionLabel.Text = $"Previous item position: {previousItemPosition}";
            currentItemPositionLabel.Text = $"Current item position: {currentItemPosition}";
        }
    }
}
