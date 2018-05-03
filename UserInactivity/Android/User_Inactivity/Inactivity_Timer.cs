using Android.App;
using System.Timers;

namespace User_Inactivity
{
    public static class Inactivity_Timer
    {
        /// <summary>
        /// the activity that gets opened if user is inactive
        /// </summary>
        public static Activity MainActivity;
        private static Timer inactivity_timer = new Timer();
        private static bool Event_Added = false;
        /// <summary>
        /// the amount of seconds user has to be inactive
        /// </summary>
        public static int time; 

        /// <summary>
        /// call this function if user is active
        /// </summary>
        public static void Reset()
        {
            // Add callback function to timer elapsed event if it isn't already added.
            if (!Event_Added)
            {
                inactivity_timer.Elapsed += Timer_Elapsed;
                Event_Added = true;
            }

            // Set user inactivity interval (how much time user has to be inactive)
            inactivity_timer.Interval = time * 1000;
            // Stop timer, so counter will start again
            inactivity_timer.Stop();
            // Start timer
            inactivity_timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Do something if time elapsed


            
            // Stop timer
            inactivity_timer.Stop();
        }
    }
}