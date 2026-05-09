using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HackathonEquipe6.Infrastructure.Repositories;

public class CompanyRepository
{
    private readonly ReWindDbContext _dbContext;

    public CompanyRepository(ReWindDbContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Company>> GetAllCompanies()
    {
       return await _dbContext.Company.ToListAsync();
    }
    public async Task<Company?> GetCompanyById(Guid id)
    {
        return await _dbContext.Company.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Company?> GetCompanyDetails(Guid id)
    {
        return await _dbContext.Company
            .Include(x => x.WantedWaste)
            .Include(x => x.CompanySegments)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}