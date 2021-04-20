using Android.App;
using Android.Content;

namespace LocalNotifications.Droid
{
    [BroadcastReceiver(Enabled = true, Label = "Reboot complete receiver")]
    [IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == "android.intent.action.BOOT_COMPLETED")
            {
                // Recreate alarms
            }
        }
    }
}

