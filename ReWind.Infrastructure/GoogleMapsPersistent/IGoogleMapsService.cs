namespace HackathonEquipe6.Infrastructure.GoogleMapsPersistent;

public interface IGoogleMapsService
{
    Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address);
}