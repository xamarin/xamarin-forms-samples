using System;
using System.IO;
using Xamarin.Forms;

namespace DependencyServiceDemos
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnGetDeviceOrientationButtonClicked(object sender, EventArgs e)
        {
            DeviceOrientation orientation = DependencyService.Get<IDeviceOrientationService>().GetOrientation();
            orientationLabel.Text = orientation.ToString();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }

        async void OnSpeakButtonClicked(object sender, EventArgs e)
        {
            ITextToSpeechService service = DependencyService.Get<ITextToSpeechService>(DependencyFetchTarget.NewInstance);
            using (service as IDisposable)
            {
                await service.SpeakAsync("Hello world");
            }
        }
    }
}
