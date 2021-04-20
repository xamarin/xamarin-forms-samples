using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class DataPackageCommandDemoPage : ContentPage
    {
        public DataPackageCommandDemoPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<DataPackageViewModel, string>(this, "Correct", async (s, e) =>
            {
                await DisplayAlert("Correct", e, "OK");
            });

            MessagingCenter.Subscribe<DataPackageViewModel, string>(this, "Incorrect", async (s, e) =>
            {
                await DisplayAlert("Incorrect", e, "OK");
            });
        }
    }
}
