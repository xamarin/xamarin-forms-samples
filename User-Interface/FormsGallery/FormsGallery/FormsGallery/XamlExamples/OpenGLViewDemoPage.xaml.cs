using System;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class OpenGLViewDemoPage : ContentPage
    {
        IOpenGLViewSharedCode sharedCode = DependencyService.Get<IOpenGLViewSharedCode>();

        public OpenGLViewDemoPage()
        {
            InitializeComponent();

            openGLView.IsVisible = sharedCode != null;
            regretsLabel.IsVisible = sharedCode == null;

            if (sharedCode != null)
            {
                openGLView.OnDisplay = sharedCode.RenderLoop;
                openGLView.Display();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (sharedCode != null)
            {
                openGLView.HasRenderLoop = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (sharedCode != null)
            {
                openGLView.HasRenderLoop = false;
            }
        }

    }
}