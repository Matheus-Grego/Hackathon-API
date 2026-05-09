using HackathonEquipe6.Application.Models;

namespace HackathonEquipe6.Application.Services;

public interface IWasteService
{
    Task Insert(WasteInputModel model);
}