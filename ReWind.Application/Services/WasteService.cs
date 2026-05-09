using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Repositories;

namespace HackathonEquipe6.Application.Services;

public class WasteService
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
}