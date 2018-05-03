using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace User_Inactivity
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        TextView counter;
        public static int decrease_time;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Second);

            counter = FindViewById<TextView>(Resource.Id.counter);
            counter.Text = Inactivity_Timer.time.ToString() + " " + "sec";
            decrease_time = Inactivity_Timer.time;


            // show timer countdown (it's just an example to show that code works)
            Timer_Start:
            if (decrease_time != 0)
            {
                await Task.Delay(1000);
                decrease_time = decrease_time - 1;
                counter.Text = decrease_time.ToString() + " " + "sec";
                if (counter.Text == "0 sec")
                {
                    Finish();
                }
                goto Timer_Start;
            }
        }
        /// <summary>
        /// if user tap somewhere call this function
        /// </summary>
        public override void OnUserInteraction()
        {
            counter.Text = Inactivity_Timer.time.ToString() + " " + "sec";
            decrease_time = Inactivity_Timer.time;
            // Reset timer because user is active 
            Inactivity_Timer.Reset();
        }
    }
}