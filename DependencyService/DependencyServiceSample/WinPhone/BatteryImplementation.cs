using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using DependencyServiceSample.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryImplementation))]
namespace DependencyServiceSample.WinPhone
{
    public class BatteryImplementation : IBattery
    {
        private int last;
        private BatteryStatus status = BatteryStatus.Unknown;

        public BatteryImplementation()
        {
            last = DefaultBattery.RemainingChargePercent;
        }


        Windows.Phone.Devices.Power.Battery battery;
        private Windows.Phone.Devices.Power.Battery DefaultBattery
        {
            get { return battery ?? (battery = Windows.Phone.Devices.Power.Battery.GetDefault()); }
        }
        public int RemainingChargePercent
        {
            get
            {
                return DefaultBattery.RemainingChargePercent;
            }
        }

        public BatteryStatus Status
        {
            get
            {
                return status;
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                if (status == BatteryStatus.Full || status == BatteryStatus.Charging)
                    return PowerSource.Ac;

                return PowerSource.Battery;
            }
        }
    }
}