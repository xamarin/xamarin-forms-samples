using System;
using Xamarin.Forms;

namespace VisualDemos
{
    public class CustomEffect : RoutingEffect
    {
        public CustomEffect() : base($"Xamarin.{nameof(CustomEffect)}")
        {
        }
    }
}
