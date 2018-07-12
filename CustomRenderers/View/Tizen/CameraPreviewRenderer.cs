using System.ComponentModel;
using Xamarin.Forms.Platform.Tizen;
using System.Linq;
using Tizen.Multimedia;

[assembly: ExportRenderer(typeof(CustomRenderer.CameraPreview), typeof(CustomRenderer.CameraPreviewRenderer))]

namespace CustomRenderer
{
    class CameraPreviewRenderer : VisualElementRenderer<CameraPreview>
    {
        protected Camera Camera;
        protected CameraDevice SelectedCamera;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);
            if (NativeView == null)
            {
                SelectedCamera = CameraDevice.Rear;
                try
                {
                    Camera = new Camera(SelectedCamera);
                    var mediaView = new MediaView(Forms.NativeParent);
                    Camera.Display = new Display(mediaView);
                    SetNativeView(mediaView);
                }
                catch (System.Exception ex)
                {
                    Camera?.Dispose();
                    Camera = null;
                    SetNativeView(new ElmSharp.Label(Forms.NativeParent)
                    {
                        Text = $"Camera preview is not available.<br><br>{ex}",
                        LineWrapType = ElmSharp.WrapType.Word
                    });
                }
            }
            if (e.OldElement != null)
            {
                if (Camera != null)
                {
                    if (Camera.State == CameraState.Captured)
                    {
                        Camera.StartPreview();
                        Camera.StopPreview();
                    }
                    else if (Camera.State == CameraState.Preview)
                    {
                        Camera.StopPreview();
                    }

                    Camera.Dispose();
                }
            }
            if (e.NewElement != null)
            {
                UpdateCameraProperty();
                Camera?.StartPreview();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CameraPreview.CameraProperty.PropertyName)
            {
                UpdateCameraProperty();
                return;
            }
            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateCameraProperty()
        {
            if (Camera == null)
                return;

            CameraDevice previousCamera = SelectedCamera;

            if (Element.Camera == CameraOptions.Rear)
                SelectedCamera = CameraDevice.Rear;
            else if (Element.Camera == CameraOptions.Front)
                SelectedCamera = CameraDevice.Front;

            if (SelectedCamera != previousCamera)
                Camera.ChangeDevice(SelectedCamera);
        }
    }
}
