using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using DIContainerDemo;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(TouchTracking.iOS.TouchEffect), "TouchEffect")]
namespace TouchTracking.iOS
{
    public class TouchEffect : PlatformEffect
    {
        ILogger _logger;
        UIView view;
        TouchRecognizer touchRecognizer;

        public TouchEffect(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override void OnAttached()
        {
            _logger.Log("OnAttached invoked.");

            // Get the iOS UIView corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            TouchTracking.TouchEffect effect = (TouchTracking.TouchEffect)Element.Effects.FirstOrDefault(e => e is TouchTracking.TouchEffect);

            if (effect != null && view != null)
            {
                // Create a TouchRecognizer for this UIView
                touchRecognizer = new TouchRecognizer(Element, view, effect);
                view.AddGestureRecognizer(touchRecognizer);
            }
        }

        protected override void OnDetached()
        {
            _logger.Log("OnDetached invoked.");

            if (touchRecognizer != null)
            {
                // Clean up the TouchRecognizer object
                touchRecognizer.Detach();

                // Remove the TouchRecognizer from the UIView
                view.RemoveGestureRecognizer(touchRecognizer);
            }
        }
    }
}