using Xamarin.Forms;
using DependencyServiceSample.UWP;
using Windows.UI.ViewManagement;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]
namespace DependencyServiceSample.UWP
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientations GetOrientation()
        {
            var orientation = ApplicationView.GetForCurrentView().Orientation;
            if (orientation == ApplicationViewOrientation.Landscape)
                return DeviceOrientations.Landscape;
            else
                return DeviceOrientations.Portrait;
        }
    }
}
