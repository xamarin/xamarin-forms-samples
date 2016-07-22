using System;

namespace DependencyServiceSample
{
	public enum BatteryStatus
	{
		Charging,
		Discharging,
		Full,
		NotCharging,
		Unknown
	}

	public enum PowerSource
	{
		Battery,
		Ac,
		Usb,
		Wireless,
		Other
	}

	public interface IBattery
	{
		int RemainingChargePercent { get; }
		BatteryStatus Status { get; }
		PowerSource PowerSource { get; }
	}
}

