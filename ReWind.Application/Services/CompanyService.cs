using HackathonEquipe6.Infrastructure.GoogleMapsPersistent;
using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Repositories;
using BCrypt.Net;

namespace HackathonEquipe6.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IGoogleMapsService _mapsService;

    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CompanyViewModel>> GetAllCompanies()
    {
        var entities = await _repository.GetAllCompanies();
        return entities.Select(x => CompanyViewModel.ToViewModel(x)).ToList();
    }

    public async Task<CompanyViewModel?> GetCompanyById(Guid id)
    {
        var entity = await _repository.GetCompanyById(id);
        return entity == null ? null : CompanyViewModel.ToViewModel(entity);
    }

    public async Task<CompanyViewModel?> GetCompanyDetails(Guid id)
    {
        var entity = await _repository.GetCompanyDetails(id);
        return entity == null ? null : CompanyViewModel.ToViewModel(entity);
    }

    public async Task CreateAsync(CompanyInputModel input)
    {
        var (lat, lng) = await _mapsService.GetCoordinatesAsync(input.Address);

        var entity = new Company
        {
            Name = input.Name,
            Latitude = lat,  
            Longitude = lng,
            DocumentNumber = input.DocumentNumber,
            Address = input.Address,
            City = input.City,
            State = input.State,
            ZipCode = input.ZipCode,
            Phone = input.Phone,
            Email = input.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(input.Password)
        };

        await _repository.CreateAsync(entity);
    }
}