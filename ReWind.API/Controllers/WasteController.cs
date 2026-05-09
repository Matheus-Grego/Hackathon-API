using HackathonEquipe6.Application.Models;
using HackathonEquipe6.Application.Services;
using HackathonEquipe6.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HackathonEquipe6.API.Controllers;

[ApiController]
[Route("api/waste")]
public class WasteController : ControllerBase
{

    private readonly IWasteService _service;
    public WasteController(IWasteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Insert(WasteInputModel model)
    {
       await _service.Insert(model);
       return NoContent();
    }
}