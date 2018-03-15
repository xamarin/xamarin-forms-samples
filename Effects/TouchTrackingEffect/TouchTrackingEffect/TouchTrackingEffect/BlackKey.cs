using System;
using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{
    class BlackKey : Key
    {
        public BlackKey()
        {
            UpColor = new Color(0);
            DownColor = new Color(0.35);
            Color = UpColor;
        }
    }
}
