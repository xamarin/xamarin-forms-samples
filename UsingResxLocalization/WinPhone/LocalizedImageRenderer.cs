using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(Image), typeof(UsingResxLocalization.WinPhone.LocalizedImageRenderer))]

/*
 * This code is provided as a suggestion for how to support localized images on Windows Phone.
 * 
 * You are encouraged to modify it to suit your specific localization needs, in particular
 * error handling and fall-back when a specific image file is not available.
 */
namespace UsingResxLocalization.WinPhone
{
    public class LocalizedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var s = e.NewElement.Source as FileImageSource;
                if (s != null)
                {
                    var fileName = s.File;
                    string ci = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
                    if (ci == "pt-BR") {
                        // use the complete string 'as is'
                    } else if (ci == "zh-CN") {
                        ci = "zh-Hans"; // we could have named the image directories differently, but this keeps them consisent with RESX naming
                    } else if (ci == "zh-TW" || ci == "zh-HK") {
                        ci = "zh-Hant";
                    } else { 
                        // for all others, just use the two-character language code
                        ci = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                    }
                    e.NewElement.Source = Path.Combine("Assets/" + ci + "/" + fileName);
                }
            }
        }
    }
}
