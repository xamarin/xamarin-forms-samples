using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class EmptyViewSwapPage : ContentPage
    {
        public EmptyViewSwapPage()
        {
            InitializeComponent();
            ToggleEmptyView(false);
        }

        void OnEmptyViewSwitchToggled(object sender, ToggledEventArgs e)
        {
            ToggleEmptyView((sender as Switch).IsToggled);
        }

        void ToggleEmptyView(bool isToggled)
        {
            carouselView.EmptyView = isToggled ? Resources["BasicEmptyView"] : Resources["AdvancedEmptyView"];
        }
    }
}
