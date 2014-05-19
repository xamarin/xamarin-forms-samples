using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

#pragma warning disable 4014        // for non-await'ed async call

namespace AnimationSampler
{
    class PalindromeAnimationPage : ContentPage
    {
        StackLayout stackLayout;

        public PalindromeAnimationPage()
        {
            string text = "NEVER ODD OR EVEN";
            double[] anchorX = { 0.5, 0.5, 0.5, 0.5, 1, 0,
                                 0.5, 1, 1, -1,
                                 0.5, 1, 0,
                                 0.5, 0.5, 0.5, 0.5 };

            stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                AnchorY = 1
            };

            for (int i = 0; i < text.Length; i++)
            {
                Label label = new Label
                {
                    Text = text[i].ToString(),
                    XAlign = TextAlignment.Center,
                    AnchorX = anchorX[i],
                    AnchorY = 1
                };
                stackLayout.Children.Add(label);
            }

            this.Content = stackLayout;
            this.SizeChanged += OnPageSizeChanged;

  //          AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Adjust the size and font based on the display width.
            double width = 0.8 * this.Width / stackLayout.Children.Count;
            Font font = Font.SystemFontOfSize(1.4 * width);

            foreach (Label label in stackLayout.Children.OfType<Label>()) 
            {
                label.Font = font;
                label.WidthRequest = width;
            }
        }


        // Problem -- if page reappears, setting isCurrentPage, animation loop might
        //  not yet be exited.

        bool isCurrentPage;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isCurrentPage = true;
            AnimationLoop();
            System.Diagnostics.Debug.WriteLine("OnAppearing");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isCurrentPage = false;
            System.Diagnostics.Debug.WriteLine("OnDisappearing");
        }
        async void AnimationLoop()
        {
            bool backwards = false;

            while (isCurrentPage)
            {
                // Let it sit here awhile.
                await Task.Delay(1000);

                IEnumerable<Label> labels = stackLayout.Children.OfType<Label>();

                foreach (View label in backwards ? labels.Reverse() : labels)
                {
                    uint flipTime = 250;

                    // First half of flip rotation.
                    await label.RelRotateTo(90, flipTime / 2);

                    if (label != (backwards ? labels.First() : labels.Last()))
                    {
                        // Second half awaited so overlaps with next.
                        label.RelRotateTo(90, flipTime / 2);
                    }
                    else
                    {
                        // Except for the last one.
                        await label.RelRotateTo(90, flipTime / 2);
                    }
                }

                // Rotate the entire stack
                await stackLayout.RelRotateTo(180, 1000);

                // Flip the backwards flag.
                backwards ^= true;

                System.Diagnostics.Debug.WriteLine("Done!");
            }
        }
    }
}
