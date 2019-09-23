using Xamarin.Forms;

namespace BasicFormsListView
{
    public class ListViewCode : ContentPage
    {
        public ListViewCode()
        {
            Title = "ListView Code Demo";
            Padding = 10;

            var listView = new ListView();
            listView.ItemsSource = Constants.Items;
            Content = listView;
        }
    }
}


