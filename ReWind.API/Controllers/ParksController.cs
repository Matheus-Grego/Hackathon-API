using HackathonEquipe6.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/parks")]
public class ParksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllParks()
    {
        return NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetParkById(Guid id)
    {
        return NoContent();
    }
    
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetParkDetails(Guid id)
    {
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> login(LoginViewModel model)
    {
        return NoContent();
    } 
}