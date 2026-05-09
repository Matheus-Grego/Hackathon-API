using HackathonEquipe6.Application.Models;

namespace HackathonEquipe6.Application.Services;

public interface IParkService
{
    Task<List<ParkViewModel>> GetAllParks();

    Task<ParkViewModel?> GetParkById(Guid id);

    Task<ParkViewModel?> GetParkDetails(Guid id);
}