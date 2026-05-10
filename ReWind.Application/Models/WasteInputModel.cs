using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Application.Models;

public class WasteInputModel
{
    public WasteInputModel(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    
    public static Waste ToEntity(WasteInputModel w) => new (w.Title, w.Description);

    public static WasteInputModel FromEntity(Waste w) => new(w.Title, w.Description);
}