using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;

namespace HackathonEquipe6.Application.Services;

public class ParkService : IParkService
{
    
    private readonly IParkRepository _repository;
    private readonly ICNPJBizPersistance.ICNPJBizPersistance _cnpjBizPersistent;

    public ParkService(IParkRepository repository, ICNPJBizPersistance.ICNPJBizPersistance cnpjBizPersistent)
    {
        _repository = repository;
        _cnpjBizPersistent = cnpjBizPersistent;
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
        var model = entity == null ? null : ParkDetailsViewModel.FromEntity(entity);
        if (!String.IsNullOrEmpty(entity.Password))
        {
            var search = await _cnpjBizPersistent.GetEmpresaByCNPJAsync(entity.Password);
            model.Email = search.Email;
            model.Address = search.Address;
            model.ZipCode = search.ZipCode;
            model.Phones = search.Telefones;
        }
        
        
        return model;
    }
}