using System;
using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{
    class WhiteKey : Key
    {
        public WhiteKey()
        {
            UpColor = new Color(0.9);
            DownColor = new Color(1.0);
            Color = UpColor;
        }
    }
}
