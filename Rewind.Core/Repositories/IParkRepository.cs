using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Core.Repositories;

public interface IParkRepository
{
    Task<List<Park>> GetAllParks();

    Task<Park?> GetParkById(Guid id);

    Task<Park?> GetParkDetails(Guid id);
}