namespace HackathonEquipe6.Core.Entities;

public class CompanyWaste
{
    public Guid CompanyId { get; set; }
    public Guid WasteId { get; set; }
    public virtual Company Company { get; set; }
    public virtual Waste Waste { get; set; }
}