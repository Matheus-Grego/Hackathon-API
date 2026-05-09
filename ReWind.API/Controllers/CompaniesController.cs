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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyDetails(Guid id)
    {
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> login(LoginViewModel model)
    {
        return NoContent();
    } 
}