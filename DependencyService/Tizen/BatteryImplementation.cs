using DependencyServiceSample.Tizen;
using Tizen.System;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryImplementation))]
namespace DependencyServiceSample.Tizen
{
    public class BatteryImplementation : IBattery
    {
        public BatteryImplementation()
        {
        }

        public int RemainingChargePercent
        {
            get
            {
                return Battery.Percent;
            }
        }

        public DependencyServiceSample.BatteryStatus Status
        {
            get
            {
                if(Battery.IsCharging)
                {
                    return BatteryStatus.Charging;
                }
                else
                {
                    switch (Battery.Level)
                    {
                        case BatteryLevelStatus.Full:
                            return BatteryStatus.Full;
                        case BatteryLevelStatus.Empty:
                            return BatteryStatus.Unknown;
                    }
                    return BatteryStatus.NotCharging;
                }
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                var status = Status;
                if (status == BatteryStatus.Full || status == BatteryStatus.Charging)
                {
                    return PowerSource.Ac;
                }
                return PowerSource.Battery;
            }
        }
    }
}

