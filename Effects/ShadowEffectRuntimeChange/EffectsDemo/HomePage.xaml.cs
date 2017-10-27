using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EffectsDemo
{
    [Preserve(AllMembers = true)]
    public partial class HomePage : ContentPage
    {
        bool isLabelTeal = false;

        public HomePage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            if (isLabelTeal)
            {
                Color color = Color.Default;
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        color = Color.Black;
                        break;
                    case Device.Android:
                        color = Color.White;
                        break;
                    case Device.UWP:
                        color = Color.Red;
                        break;
                }

                ShadowEffect.SetColor(label, color);
                isLabelTeal = false;
            }
            else
            {
                ShadowEffect.SetColor(label, Color.Teal);
                isLabelTeal = true;
            }
        }
    }
}
