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
        return await _dbContext.Park.ToListAsync();
    }
    public async Task<Park?> GetCompanyById(Guid id)
    {
        return await _dbContext.Park.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Park?> GetCompanyDetails(Guid id)
    {
        return await _dbContext.Park
            .Include(x => x.ParkWaste)
            .ThenInclude(x => x.Waste)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}