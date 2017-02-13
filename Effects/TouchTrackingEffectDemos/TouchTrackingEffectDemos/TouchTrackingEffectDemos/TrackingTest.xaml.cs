using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using TouchTracking;

namespace TouchTrackingEffectDemos
{
    public partial class TrackingTest : ContentPage
    {
        const uint length = 5000;

        public TrackingTest()
        {
            InitializeComponent();
        }

        void OnTouchAction(object sender, TouchActionEventArgs args)
        {
            string id = (sender as View).StyleId;

            switch (args.Type)
            {
                case TouchActionType.Entered:
                    entered.Text = String.Format("Entered:  {0}  {1:F0} {2:F0}", id, args.Location.X, args.Location.Y);
                    ViewExtensions.CancelAnimations(entered);
                    entered.Opacity = 1;
                    entered.FadeTo(0, length);
                    break;

                case TouchActionType.Pressed:
                    pressed.Text = String.Format("Pressed:  {0}  {1:F0} {2:F0}", id, args.Location.X, args.Location.Y);
                    ViewExtensions.CancelAnimations(pressed);
                    pressed.Opacity = 1;
                    pressed.FadeTo(0, length);
                    break;

                case TouchActionType.Moved:
                    moved.Text = String.Format("Moved:  {0}  {1:F0} {2:F0}", id, args.Location.X, args.Location.Y);
                    ViewExtensions.CancelAnimations(moved);
                    moved.Opacity = 1;
                    moved.FadeTo(0, length);
                    break;


                case TouchActionType.Released:
                    released.Text = String.Format("Released:  {0}  {1:F0} {2:F0}", id, args.Location.X, args.Location.Y);
                    ViewExtensions.CancelAnimations(released);
                    released.Opacity = 1;
                    released.FadeTo(0, length);
                    break;

                case TouchActionType.Exited:
                    exited.Text = String.Format("Exited:  {0}  {1:F0} {2:F0}", id, args.Location.X, args.Location.Y);
                    ViewExtensions.CancelAnimations(exited);
                    exited.Opacity = 1;
                    exited.FadeTo(0, length);
                    break;
            }
        }
    }
}
