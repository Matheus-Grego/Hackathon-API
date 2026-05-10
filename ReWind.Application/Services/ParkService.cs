using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;

namespace HackathonEquipe6.Application.Services;

public class ParkService : IParkService
{
    
    private readonly IParkRepository _repository;

    public ParkService(IParkRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ParkViewModel>> GetAllParks()
    {
        var entities = await _repository.GetAllParks();
        return entities.Select(x => ParkViewModel.FromEntity(x)).ToList(); 
    }

    public async Task<ParkViewModel?> GetParkById(Guid id)
    {
        var entity = await _repository.GetParkById(id);
        return entity == null ? null : ParkViewModel.FromEntity(entity);
    }

    public async Task<ParkDetailsViewModel?> GetParkDetails(Guid id)
    {
        var  entity = await _repository.GetParkDetails(id);
        return entity == null ? null : ParkDetailsViewModel.FromEntity(entity);
    }
}