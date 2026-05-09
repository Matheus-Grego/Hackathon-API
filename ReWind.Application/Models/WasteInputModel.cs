using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Application.Models;

public class WasteInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public static Waste ToEntity(WasteInputModel w) => new (w.Title, w.Description);
    
}