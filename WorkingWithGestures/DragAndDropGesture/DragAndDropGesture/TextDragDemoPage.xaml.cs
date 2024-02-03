using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class TextDragDemoPage : ContentPage
    {
        public TextDragDemoPage()
        {
            InitializeComponent();
        }

        async void OnDropGestureRecognizerDrop(object sender, DropEventArgs e)
        {            
            await DisplayAlert("Correct", "Congratulations!", "OK");
            //await DisplayAlert("Incorrect", "Better luck next time.", "OK");
        }

        void OnDropGestureRecognizerDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }
    }
}
