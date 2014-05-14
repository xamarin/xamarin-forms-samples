using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationSampler
{
    public partial class FadingTextAnimationPage
    {
        public FadingTextAnimationPage()
        {
            InitializeComponent();
            SizeChanged += OnPageSizeChanged;

            // Start the animation going.
            AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            if (this.Width <= 0)
                return;

            label1.WidthRequest = this.Width;
            label2.WidthRequest = this.Width;

            Font font = Font.BoldSystemFontOfSize(0.3 * this.Width);
            label1.Font = font;
            label2.Font = font;
        }

        async void AnimationLoop()
        {
            while (true)
            {
                await Task.WhenAll(label1.FadeTo(0, 1000),
                                   label2.FadeTo(1, 1000));

                await Task.WhenAll(label1.FadeTo(1, 1000),
                                   label2.FadeTo(0, 1000));
            }
        }
    }
}
