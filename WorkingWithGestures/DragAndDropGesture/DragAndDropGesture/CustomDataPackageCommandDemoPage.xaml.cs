using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class CustomDataPackageCommandDemoPage : ContentPage
    {
        public CustomDataPackageCommandDemoPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<CustomDataPackageViewModel, string>(this, "Correct", async (s, e) =>
            {
                await DisplayAlert("Correct", e, "OK");
            });

            MessagingCenter.Subscribe<CustomDataPackageViewModel, string>(this, "Incorrect", async (s, e) =>
            {
                await DisplayAlert("Incorrect", e, "OK");
            });
        }
    }
}
