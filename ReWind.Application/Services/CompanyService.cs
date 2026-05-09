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

    public CompanyService(ICompanyRepository repository, IGoogleMapsService mapsService)
    {
        _repository = repository;
        _mapsService = mapsService;
    }

    public async Task<List<CompanyViewModel>> GetAllCompanies()
    {
        var entities = await _repository.GetAllCompanies();
        return entities.Select(ToViewModel).ToList();
    }

    public async Task<CompanyViewModel?> GetCompanyById(Guid id)
    {
        var entity = await _repository.GetCompanyById(id);
        return entity == null ? null : ToViewModel(entity);
    }

    public async Task<CompanyViewModel?> GetCompanyDetails(Guid id)
    {
        var entity = await _repository.GetCompanyDetails(id);
        return entity == null ? null : ToViewModel(entity);
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

    private CompanyViewModel ToViewModel(Company c) => new()
    {
        Id = c.Id,
        Name = c.Name,
        DocumentNumber = c.DocumentNumber,
        Address = c.Address,
        City = c.City,
        State = c.State,
        ZipCode = c.ZipCode,
        Phone = c.Phone,
        Email = c.Email,
        Latitude = c.Latitude,
        Longitude = c.Longitude
    };
}