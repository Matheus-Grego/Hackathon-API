using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Core.Repositories;

public interface IWasteRepository
{
    Task Insert(Waste entity);
    Task<List<Waste>> GetAllWastes();
}