namespace HackathonEquipe6.Core.Entities;

public class CompanySegment : BaseEntity
{
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}