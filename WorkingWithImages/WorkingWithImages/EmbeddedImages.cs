using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkingWithImages
{
    public class EmbeddedImages : ContentPage
    {
        public EmbeddedImages()
        {
			var embeddedImage = new Image { Aspect = Aspect.AspectFit };

			// resource identifiers start with assembly-name DOT filename
			embeddedImage.Source = ImageSource.FromResource("beach.jpg");
            
            Content = new StackLayout
            {
                Children = {
					new Label {Text = "ImageSource.FromResource", Font=Font.BoldSystemFontOfSize(NamedSize.Medium)},
					embeddedImage, 
					new Label {Text = "WorkingWithImages.beach.jpg embedded resource"}
                },
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
        }
    }
}
