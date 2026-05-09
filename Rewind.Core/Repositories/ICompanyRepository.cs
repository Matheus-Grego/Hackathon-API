using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Core.Repositories;

public interface ICompanyRepository
{
    Task<List<Company>> GetAllCompanies();
    Task<Company?> GetCompanyById(Guid id);
    Task<Company?> GetCompanyDetails(Guid id);
    Task CreateAsync(Company company);
}