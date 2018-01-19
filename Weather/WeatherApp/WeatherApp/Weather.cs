namespace WeatherApp
{
    public class Weather
    {
        // Because labels bind to these values, set them to an empty string to
        // ensure that the label appears on all platforms by default.
        public string Title { get; set; } = " ";
        public string Temperature { get; set; } = " ";
        public string Wind { get; set; } = " ";
        public string Humidity { get; set; } = " ";
        public string Visibility { get; set; } = " ";
        public string Sunrise { get; set; } = " ";
        public string Sunset { get; set; } = " ";
    }
}
