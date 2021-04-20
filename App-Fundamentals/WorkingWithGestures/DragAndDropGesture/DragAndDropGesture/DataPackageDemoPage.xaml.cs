using Xamarin.Forms;

namespace DragAndDropGesture
{
    public partial class DataPackageDemoPage : ContentPage
    {
        public DataPackageDemoPage()
        {
            InitializeComponent();
        }

        void OnMonkeyDragStarting(object sender, DragStartingEventArgs e)
        {
            e.Data.Text = "Monkey";
        }

        void OnCatDragStarting(object sender, DragStartingEventArgs e)
        {
            e.Data.Text = "Cat";
        }

        async void OnDrop(object sender, DropEventArgs e)
        {
            string text = await e.Data.GetTextAsync();

            if (text.Equals("Cat"))
            {
                await DisplayAlert("Correct", "Congratulations!", "OK");
            }
            else if (text.Equals("Monkey"))
            {
                await DisplayAlert("Incorrect", "Try again.", "OK");
            }
        }
    }
}
