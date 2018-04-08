using System;

namespace DependencyServiceSample
{
	public enum DeviceOrientations
	{
		Undefined,
		Landscape,
		Portrait
	}

	public interface IDeviceOrientation
	{
		DeviceOrientations GetOrientation();
	}
}

