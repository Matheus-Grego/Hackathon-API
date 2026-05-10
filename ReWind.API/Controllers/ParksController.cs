using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Application.Services;
using HackathonEquipe6.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/parks")]
public class ParksController : ControllerBase
{

    private readonly IParkService _service;
    public ParksController(IParkService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllParks()
    {
        var result = await _service.GetAllParks();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetParkById(Guid id)
    {
        var result = await _service.GetParkById(id);
        return Ok(result);
    }
    
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetParkDetails(Guid id)
    {
        var result = await _service.GetParkDetails(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> login(LoginViewModel model)
    {
        return NoContent();
    } 
}