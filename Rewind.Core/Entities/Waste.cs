namespace HackathonEquipe6.Core.Entities;

public class Waste : BaseEntity
{
    public Waste(string title, string? description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string? Description { get; set; }
}