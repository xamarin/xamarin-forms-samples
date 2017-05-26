using System;
using Android;
using Android.Content;
using Android.App;
using Android.OS;
using BatteryStatus = Android.OS.BatteryStatus;
using DependencyServiceSample.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (BatteryImplementation))]
namespace DependencyServiceSample.Droid
{
	public class BatteryImplementation : IBattery
	{
		public BatteryImplementation ()
		{
		}

		public int RemainingChargePercent{
			get { 
				try{
					using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
					{
						using (var battery = Application.Context.RegisterReceiver(null, filter))
						{
							var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
							var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);

							return (int)Math.Floor(level * 100D / scale);
						}
					}
				}
				catch{
					System.Diagnostics.Debug.WriteLine ("Ensure you have android.permission.BATTERY_STATS");
					throw;
				}
			}
		}

		public DependencyServiceSample.BatteryStatus Status
		{
			get
			{
				try
				{
					using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
					{
						using (var battery = Application.Context.RegisterReceiver(null, filter))
						{
							int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
							var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;

							var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
							var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
							var acCharge = chargePlug == (int)BatteryPlugged.Ac;
							bool wirelessCharge = false;
							wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

							isCharging = (usbCharge || acCharge || wirelessCharge);
							if (isCharging)
								return DependencyServiceSample.BatteryStatus.Charging;

							switch(status)
							{
							case (int)BatteryStatus.Charging:
								return DependencyServiceSample.BatteryStatus.Charging;
							case (int)BatteryStatus.Discharging:
								return DependencyServiceSample.BatteryStatus.Discharging;
							case (int)BatteryStatus.Full:
								return DependencyServiceSample.BatteryStatus.Full;
							case (int)BatteryStatus.NotCharging:
								return DependencyServiceSample.BatteryStatus.NotCharging;
							default:
								return DependencyServiceSample.BatteryStatus.Unknown;
							}
						}
					}
				}
				catch
				{
					System.Diagnostics.Debug.WriteLine ("Ensure you have android.permission.BATTERY_STATS");
					throw;
				}
			}
		}

		public PowerSource PowerSource {
			get {
				try {
					using (var filter = new IntentFilter (Intent.ActionBatteryChanged)) {
						using (var battery = Application.Context.RegisterReceiver (null, filter)) {
							int status = battery.GetIntExtra (BatteryManager.ExtraStatus, -1);
							var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;

							var chargePlug = battery.GetIntExtra (BatteryManager.ExtraPlugged, -1);
							var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
							var acCharge = chargePlug == (int)BatteryPlugged.Ac;

							bool wirelessCharge = false;
							wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

							isCharging = (usbCharge || acCharge || wirelessCharge);

							if (!isCharging)
								return DependencyServiceSample.PowerSource.Battery;
							else if (usbCharge)
								return DependencyServiceSample.PowerSource.Usb;
							else if (acCharge)
								return DependencyServiceSample.PowerSource.Ac;
							else if (wirelessCharge)
								return DependencyServiceSample.PowerSource.Wireless;
							else
								return DependencyServiceSample.PowerSource.Other;
						}
					}
				} catch {
					System.Diagnostics.Debug.WriteLine ("Ensure you have android.permission.BATTERY_STATS");
					throw;
				}
			}
		}
	}
}

