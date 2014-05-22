using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class MasterDetailPageDemoPage :  MasterDetailPage
    {
        public MasterDetailPageDemoPage()
        {
            this.Master = new ContentPage
            {
                BackgroundColor = Color.Blue,

                Content = 
                
                
                
                new Label { Text = "Master" }
            };

            this.Detail = new ContentPage
            {
                BackgroundColor = Color.Red,

                Content = new Label { Text = "Detail" }
            };

            // 

            this.IsPresented = true;

        }
    }
}
