using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Enums;

namespace HackathonEquipe6.Application.Models;

public class ParkViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal AuthorizedPowerKw { get; set; }
    public decimal InspectedPowerKw { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public CurtailmentRiskLevel? CurtailmentRiskLevel { get; set; }    
    public virtual List<ParkWaste> ParkWaste { get; set; }
    public OperationTypeEnum? OperationType { get; set; }
    public decimal? TotalCO2ReductionTons { get; set; }
    
    
    public static ParkViewModel FromEntity(Park entity)
    {
        return new ParkViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            AuthorizedPowerKw = entity.AuthorizedPowerKw,
            InspectedPowerKw = entity.InspectedPowerKw,
            Latitude = entity.Latitude,
            Longitude = entity.Longitude,
            ParkWaste = entity.ParkWaste,
            CurtailmentRiskLevel =  entity.CurtailmentRiskLevel,
            OperationType = entity.OperationType,
            TotalCO2ReductionTons = entity.TotalCO2ReductionTons
        };
    }

    public Park ToEntity(string password)
    {
        return new Park
        {
            Name = this.Name,
            AuthorizedPowerKw = this.AuthorizedPowerKw,
            InspectedPowerKw = this.InspectedPowerKw,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            ParkWaste = this.ParkWaste
            
        };
    }

}