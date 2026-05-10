using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using HackathonEquipe6.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HackathonEquipe6.Infrastructure.Repositories;

public class ParkRepository : IParkRepository
{
    private readonly ReWindDbContext _dbContext;

    public ParkRepository(ReWindDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<List<Park>> GetAllParks()
    {
        return await _dbContext.Parks.AsNoTracking().ToListAsync();
    }
    public async Task<Park?> GetParkById(Guid id)
    {
        return await _dbContext.Parks.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Park?> GetParkDetails(Guid id)
    {
        return await _dbContext.Parks
            .Include(x => x.ParkWaste)
            .ThenInclude(x => x.Waste)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}