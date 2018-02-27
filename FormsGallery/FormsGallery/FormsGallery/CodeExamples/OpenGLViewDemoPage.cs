using System;
using Xamarin.Forms;

// OpenGLView is only supported in iOS and Android projects.
// To enable it, add a new Reference in the iOS and Android
//  projects to a Framework assembly. In the list, select
//  openTK-1.0 (for iOS) and OpenTK 1.0.0.0 (for Android).

namespace FormsGallery.CodeExamples
{
    public class OpenGLViewDemoPage : ContentPage
    {
        OpenGLView openGLView;

        public OpenGLViewDemoPage()
        {
            IOpenGLViewSharedCode sharedCode = DependencyService.Get<IOpenGLViewSharedCode>();

            Label header = new Label
            {
                Text = "OpenGLView",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label regretsLabel = null;

            if (sharedCode != null)
            {
                openGLView = new OpenGLView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                openGLView.OnDisplay = sharedCode.RenderLoop;
                openGLView.Display();
            }
            else
            {
                regretsLabel = new Label
                {
                    Text = "Sorry, OpenGLView cannot be used on this device!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(10, 0)
                };
            }

            // Build the page.
            Title = "OpenGLView Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    sharedCode != null ? (View)openGLView : regretsLabel
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (openGLView != null)
            {
                openGLView.HasRenderLoop = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (openGLView != null)
            {
                openGLView.HasRenderLoop = false;
            }
        }
    }
}