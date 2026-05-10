using HackathonEquipe6.Core.Enums;

namespace HackathonEquipe6.Core.Entities;

public class Park : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public string DocumentNumber { get; set; }
    public string Owner { get; set; }
    public DateTime? OperationStartDate { get; set; }
    public decimal AuthorizedPowerKw { get; set; }
    public decimal InspectedPowerKw { get; set; }
    public OriginTypeEnum Origin { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public CurtailmentRiskLevel? CurtailmentRiskLevel { get; set; }
    public virtual List<ParkWaste> ParkWaste { get; set; }
    
}