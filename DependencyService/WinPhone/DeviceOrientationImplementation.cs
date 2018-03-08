using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using DependencyServiceSample.WindowsPhone; 

[assembly: Dependency(typeof(DeviceOrientationImplementation))]
namespace DependencyServiceSample.WindowsPhone
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientationImplementation() { }
        public static void Init() 
        {
        }

        public DeviceOrientations GetOrientation()
        {
            var o = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation;
            if (o == Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape)
                return DeviceOrientations.Landscape;
            else
                return DeviceOrientations.Portrait;
        }
    }
}