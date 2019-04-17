using System;
using Xamarin.Forms;

namespace WebServiceTutorial
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
         
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
