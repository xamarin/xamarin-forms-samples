using System;

namespace BoxViewClock.Views
{
    using Xamarin.Forms;

    interface IUpdateRotationable
    {
        void UpdateRotation(DateTime time);
    }
}
