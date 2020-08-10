using System.Linq;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class SelectWebVideoPage : ContentPage
    {
        public SelectWebVideoPage()
        {
            InitializeComponent();
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                string key = ((string)e.CurrentSelection.FirstOrDefault()).Replace(" ", string.Empty).Replace("'", string.Empty);
                mediaElement.Source = (UriMediaSource)Application.Current.Resources[key];
            }
        }
    }
}
