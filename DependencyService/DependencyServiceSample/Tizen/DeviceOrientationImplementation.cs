using DependencyServiceSample.Tizen;
using Xamarin.Forms.Platform.Tizen;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationImplementation))]
namespace DependencyServiceSample.Tizen
{
    public class DeviceOrientationImplementation : IDeviceOrientation
	{
		public DeviceOrientations GetOrientation()
		{
            var rotation = Forms.Context.MainWindow.Rotation;
            bool isLandscape = rotation == 90 || rotation == 270;
			return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
		}
	}
}

