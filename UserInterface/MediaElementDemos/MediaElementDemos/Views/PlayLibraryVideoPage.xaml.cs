using System;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class PlayLibraryVideoPage : ContentPage
    {
        public PlayLibraryVideoPage()
        {
            InitializeComponent();
        }

        async void OnShowVideoLibraryButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false;

            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                mediaElement.Source = new FileMediaSource
                {
                    File = filename
                };
            }            

            button.IsEnabled = true;
        }
    }
}
