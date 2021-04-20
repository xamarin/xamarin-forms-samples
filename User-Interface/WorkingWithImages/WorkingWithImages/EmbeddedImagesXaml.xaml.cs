using Xamarin.Forms;
using System.Reflection;

namespace WorkingWithImages
{
    public partial class EmbeddedImagesXaml : ContentPage
    {
        public EmbeddedImagesXaml()
        {
            InitializeComponent();

            // debugging embedded resources
            // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/images/#Debugging_Embedded_Images
            var assembly = typeof(EmbeddedImages).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }
    }
}

