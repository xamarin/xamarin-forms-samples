using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class ImageDragDemoPage : ContentPage
    {
        public ImageDragDemoPage()
        {
            InitializeComponent();
        }

        async void OnCorrectDrop(object sender, DropEventArgs e)
        {
            await DisplayAlert("Correct", "Congratulations!", "OK");
        }

        void OnIncorrectDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.None;
        }
    }
}
