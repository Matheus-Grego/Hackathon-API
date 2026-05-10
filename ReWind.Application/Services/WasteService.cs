using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Repositories;

namespace HackathonEquipe6.Application.Services;

public class WasteService : IWasteService
{
    private readonly IWasteRepository _repository;

    public WasteService(IWasteRepository repository)
    {
        _repository = repository;
    }
    public async Task Insert(WasteInputModel model)
    {
        var entity = WasteInputModel.ToEntity(model);
        await _repository.Insert(entity);
    }

    public async Task<List<WasteInputModel>> GetAllWastes()
    {
        var entities =  await _repository.GetAllWastes();
        return entities.Select(x => WasteInputModel.FromEntity(x)).ToList();

    }
}