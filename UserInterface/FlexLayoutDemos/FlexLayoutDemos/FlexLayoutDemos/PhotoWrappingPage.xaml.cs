using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using Xamarin.Forms;

namespace FlexLayoutDemos
{
    public partial class PhotoWrappingPage : ContentPage
    {
        // Class for deserializing JSON list of sample bitmaps
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }

        public PhotoWrappingPage ()
        {
            InitializeComponent ();

            LoadBitmapCollection();
        }

        async void LoadBitmapCollection()
        {
            int imageDimension = Device.RuntimePlatform == Device.iOS ||
                                 Device.RuntimePlatform == Device.Android ? 240 : 120;

            string urlSuffix = String.Format("?width={0}&height={0}&mode=max", imageDimension);

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    // Download the list of stock photos
                    Uri uri = new Uri("http://docs.xamarin.com/demo/stock.json");
                    byte[] data = await webClient.DownloadDataTaskAsync(uri);

                    // Convert to a Stream object
                    using (Stream stream = new MemoryStream(data))
                    {
                        // Deserialize the JSON into an ImageList object
                        var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                        ImageList imageList = (ImageList)jsonSerializer.ReadObject(stream);

                        // Create an Image object for each bitmap
                        foreach (string filepath in imageList.Photos)
                        {
                            Image image = new Image
                            {
                                Source = ImageSource.FromUri(new Uri(filepath + urlSuffix))
                            };
                            flexLayout.Children.Add(image);
                        }
                    }
                }
                catch
                {
                    flexLayout.Children.Add(new Label
                    {
                        Text = "Cannot access list of bitmap files"
                    });
                }
            }

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
        }
    }
}
