using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/parks")]
public class ParksController : ControllerBase
{

    private readonly IParkRepository _repository;
    public ParksController(IParkRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllParks()
    {
        var result = await _repository.GetAllParks();
        return Ok(result);
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