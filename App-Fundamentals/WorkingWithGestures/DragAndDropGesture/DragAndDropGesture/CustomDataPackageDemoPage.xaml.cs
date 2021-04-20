using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace DragAndDropGesture
{
    public partial class CustomDataPackageDemoPage : ContentPage
    {
        const double area = 200 * 200;

        public CustomDataPackageDemoPage()
        {
            InitializeComponent();
        }

        void OnDragStarting(object sender, DragStartingEventArgs e)
        {
            Shape shape = (sender as Element).Parent as Shape;
            e.Data.Properties.Add("Square", new Square(shape.Width, shape.Height));
        }

        async void OnDrop(object sender, DropEventArgs e)
        {
            Square square = (Square)e.Data.Properties["Square"];

            if (square.Area.Equals(area))
            {
                await DisplayAlert("Correct", "Congratulations!", "OK");
            }
            else
            {
                await DisplayAlert("Incorrect", "Try again.", "OK");
            }
        }
    }
}
