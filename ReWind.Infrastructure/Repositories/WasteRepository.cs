using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using HackathonEquipe6.Infrastructure.Persistance;

namespace HackathonEquipe6.Infrastructure.Repositories;

public class WasteRepository : IWasteRepository
{
    private readonly ReWindDbContext _dbContext;

    public WasteRepository(ReWindDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task Insert(Waste entity)
    { 
        await _dbContext.Wastes.AddAsync(entity);
    }
}