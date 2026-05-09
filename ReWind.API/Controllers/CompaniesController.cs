using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;
    public CompaniesController(ICompanyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var result = await _service.GetAllCompanies();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(Guid id)
    {
        var result = await _service.GetCompanyById(id);
        return Ok(result);
    }
    
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetCompanyDetails(Guid id)
    {
        var result = await _service.GetCompanyDetails(id);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> login(LoginViewModel model)
    {
        return NoContent();
    } 
    
    [HttpPost("RegisterWaste")]
    public async Task<IActionResult> InsertWaste(WasteViewModel model)
    {
        return NoContent();
    } 
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(CompanyViewModel model)
    {
        return NoContent();
    } 
}