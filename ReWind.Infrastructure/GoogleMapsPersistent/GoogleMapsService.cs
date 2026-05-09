using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace HackathonEquipe6.Infrastructure.GoogleMapsPersistent;

public class GoogleMapsService : IGoogleMapsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GoogleMapsService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["GoogleMaps:ApiKey"];
    }

    public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
    {
        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

        var response = await _httpClient.GetStringAsync(url);
        var json = JsonDocument.Parse(response);

        var location = json.RootElement
            .GetProperty("results")[0]
            .GetProperty("geometry")
            .GetProperty("location");

        var lat = location.GetProperty("lat").GetDouble();
        var lng = location.GetProperty("lng").GetDouble();

        return (lat, lng);
    }
}