using HackathonEquipe6.Application.Models;

namespace HackathonEquipe6.Application.Services;

public interface ICompanyService
{
    Task<List<CompanyViewModel>> GetAllCompanies();
    Task<CompanyViewModel?> GetCompanyById(Guid id);
    Task<CompanyViewModel?> GetCompanyDetails(Guid id);
    Task CreateAsync(CompanyInputModel input);
}