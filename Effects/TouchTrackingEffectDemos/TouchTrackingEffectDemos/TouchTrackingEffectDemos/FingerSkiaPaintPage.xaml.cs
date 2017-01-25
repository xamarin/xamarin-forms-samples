using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using TouchTracking;


namespace TouchTrackingEffectDemos
{
    public partial class FingerSkiaPaintPage : ContentPage
    {
        Color strokeColor = Color.Red;
        double strokeThickness = 1;


        public FingerSkiaPaintPage()
        {
            InitializeComponent();
        }

        void OnColorPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            Picker picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                string strColor = picker.Items[picker.SelectedIndex];
                strokeColor = (Color)typeof(Color).GetRuntimeField(strColor).GetValue(null);
            }
        }

        void OnThicknessPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            Picker picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                strokeThickness = new double[] { 1, 2, 5, 10, 20 }[picker.SelectedIndex];
            }
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
   //         absoluteLayout.Children.Clear();
        }

        void OnTouchEffectTouchAction(object sender, TouchActionEventArgs args)
        {
            AbsoluteLayout absoluteLayout = sender as AbsoluteLayout;
            TouchEffect touchEffect = (TouchEffect)absoluteLayout.Effects.First(e => e is TouchEffect);



            System.Diagnostics.Debug.WriteLine(args.Type);



            switch (args.Type)
            {
                case TouchActionType.Entered:
                case TouchActionType.Pressed:
                    if (args.IsInContact)
                    {
                        //if (!linesInProgress.ContainsKey(args.Id))
                        //{
                        //    FingerPaintInfo info = new FingerPaintInfo
                        //    {
                        //        StrokeColor = strokeColor,
                        //        StrokeThickness = strokeThickness,
                        //        PreviousPoint = args.Location
                        //    };
                        //    linesInProgress.Add(args.Id, info);
                        //}
                    }
                    break;

                case TouchActionType.Moved:
                    //if (linesInProgress.ContainsKey(args.Id))
                    //{
                    //    FingerPaintInfo info = linesInProgress[args.Id];
                    //    DrawSimulatedLine(absoluteLayout, info, args.Location);
                    //    info.PreviousPoint = args.Location;
                    //}
                    break;

                case TouchActionType.Released:
                case TouchActionType.Exited:
                case TouchActionType.Cancelled:
                    //if (linesInProgress.ContainsKey(args.Id))
                    //{
                    //    FingerPaintInfo info = linesInProgress[args.Id];
                    //    DrawSimulatedLine(absoluteLayout, info, args.Location);
                    //    linesInProgress.Remove(args.Id);
                    //}
                    break;
            }
        }

    }
}
