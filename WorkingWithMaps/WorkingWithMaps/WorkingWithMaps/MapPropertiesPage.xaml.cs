using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public partial class MapPropertiesPage : ContentPage
    {
        public MapPropertiesPage()
        {
            InitializeComponent();

            scrollEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            zoomEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            moveRegionCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.StyleId)
            {
                case "scrollEnabledCheckBox":
                    map.HasScrollEnabled = !map.HasScrollEnabled;
                    break;
                case "zoomEnabledCheckBox":
                    map.HasZoomEnabled = !map.HasZoomEnabled;
                    break;
                case "showUserCheckBox":
                    map.IsShowingUser = !map.IsShowingUser;
                    break;
                case "showTrafficCheckBox":
                    map.TrafficEnabled = !map.TrafficEnabled;
                    break;
                case "moveRegionCheckBox":
                    map.MoveToLastRegionOnLayoutChange = !map.MoveToLastRegionOnLayoutChange;
                    break;
            }
        }
    }
}
