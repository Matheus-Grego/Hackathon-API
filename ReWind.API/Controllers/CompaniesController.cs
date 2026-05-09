using HackathonEquipe6.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    public CompaniesController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        return NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(Guid id)
    {
        return NoContent();
    }
    
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetCompanyDetails(Guid id)
    {
        return NoContent();
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