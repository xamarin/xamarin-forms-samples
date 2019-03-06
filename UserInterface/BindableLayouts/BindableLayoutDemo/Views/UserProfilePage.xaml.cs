using Xamarin.Forms;
using BindableLayoutDemo.ViewModels;

namespace BindableLayoutDemo.Views
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            BindingContext = new UserProfileViewModel();
        }
    }
}
