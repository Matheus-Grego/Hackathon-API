using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using HackathonEquipe6.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Waste>> GetAllWastes()
    {
        return await _dbContext.Wastes.Where(x => !x.IsDeleted).ToListAsync();
    }
}