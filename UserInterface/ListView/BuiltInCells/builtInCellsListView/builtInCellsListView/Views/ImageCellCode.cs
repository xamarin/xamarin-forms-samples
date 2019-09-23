using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public class ImageCellCode : ContentPage
    {
        public ImageCellCode()
        {
            Padding = 10;
            Title = "ImageCell Code Demo";

            ListView listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(ImageCell));
            listView.ItemTemplate.SetBinding(ImageCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(ImageCell.DetailProperty, "Comment");
            listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "Image");

            listView.ItemsSource = Constants.Veggies;
            Content = listView;
        }
    }
}