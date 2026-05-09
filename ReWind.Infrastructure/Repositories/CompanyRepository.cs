using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using HackathonEquipe6.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HackathonEquipe6.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ReWindDbContext _dbContext;

    public CompanyRepository(ReWindDbContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Company>> GetAllCompanies()
    {
       return await _dbContext.Companies.Where(x => !x.IsDeleted).ToListAsync();
    }
    public async Task<Company?> GetCompanyById(Guid id)
    {
        return await _dbContext.Companies.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Company?> GetCompanyDetails(Guid id)
    {
        return await _dbContext.Companies
            .Include(x => x.WantedWaste)
            .Include(x => x.CompanySegments)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task CreateAsync(Company company)
    {
        _dbContext.Companies.Add(company);
        await _dbContext.SaveChangesAsync();
    }
}