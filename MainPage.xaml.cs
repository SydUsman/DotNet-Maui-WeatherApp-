namespace Wether_Maui
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        public async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEnter.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GeneratedRequestUrl(Constants.OpenWeatherMapEndPoint));
                BindingContext = weatherData;
            }

            string GeneratedRequestUrl(string endPoint)
            {
                string requestUri = endPoint;
                requestUri += $"?q={_cityEnter.Text}";
                requestUri += "&units=metric";
                requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
                return requestUri;
            }

        }

    }

}
