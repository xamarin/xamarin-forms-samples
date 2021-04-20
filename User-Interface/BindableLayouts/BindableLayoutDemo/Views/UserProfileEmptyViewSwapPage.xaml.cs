using Xamarin.Forms;

namespace BindableLayoutDemo.Views
{
    public partial class UserProfileEmptyViewSwapPage : ContentPage
    {
        public UserProfileEmptyViewSwapPage()
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
            object view = isToggled ? Resources["BasicEmptyView"] : Resources["AdvancedEmptyView"];
            BindableLayout.SetEmptyView(achievementsStackLayout, view);
        }
    }
}
