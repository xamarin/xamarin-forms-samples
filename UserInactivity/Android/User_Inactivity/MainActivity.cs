using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace User_Inactivity
{
    [Activity(Label = "User_Inactivity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText set_time;
        Button start;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Inactivity_Timer.MainActivity = this;

            set_time = FindViewById<EditText>(Resource.Id.set_time);
            start = FindViewById<Button>(Resource.Id.start_btn);

            start.Click += Start_Click;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (set_time.Text.Length != 0)
            {
                Inactivity_Timer.time = Convert.ToInt32(set_time.Text);
                Inactivity_Timer.Reset();
                StartActivity(typeof(SecondActivity));
            }
        }
    }
}

