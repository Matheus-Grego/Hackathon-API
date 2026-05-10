using HackathonEquipe6.Core.Entities;
using HackathonEquipe6.Core.Enums;

namespace HackathonEquipe6.Application.Models;

public class ParkDetailsViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? ZipCode { get; set; }
    public List<TelefoneDto> Phones { get; set; }
    public string? Email { get; set; }
    public string DocumentNumber { get; set; }
    public string Owner { get; set; }
    public DateTime? OperationStartDate { get; set; }
    public decimal AuthorizedPowerKw { get; set; }
    public decimal InspectedPowerKw { get; set; }
    public OriginTypeEnum Origin { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<ParkWasteViewModel> ParkWastes { get; set; }
    public CurtailmentRiskLevel? CurtailmentRiskLevel { get; set; }

    
    public static ParkDetailsViewModel FromEntity(Park entity)  => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Address = entity.Address,
        City = entity.City,
        State = entity.State,
        ZipCode = entity.ZipCode,
        Email = entity.Email,
        DocumentNumber = entity.DocumentNumber,
        Owner = entity.Owner,
        OperationStartDate = entity.OperationStartDate,
        AuthorizedPowerKw = entity.AuthorizedPowerKw,
        InspectedPowerKw = entity.InspectedPowerKw,
        Origin = entity.Origin,
        Latitude = entity.Latitude,
        Longitude = entity.Longitude,
        CurtailmentRiskLevel = entity.CurtailmentRiskLevel,
        
        ParkWastes = entity.ParkWaste?.Select(pw => new ParkWasteViewModel
        {
            Quantity = pw.Quantity,
            PricePerTon = pw.PricePerTon,
            CalculationType = pw.CalculationType,
            CO2ReductionTons =  pw.CO2ReductionTons,
            Waste = pw.Waste == null ? null : new WasteViewModel
            {
                Title = pw.Waste.Title,
            }
        }).ToList() ?? []
    };
}

public class ParkWasteViewModel
{
    public decimal Quantity { get; set; }
    public decimal PricePerTon { get; set; }
    public ParkWasteEnum CalculationType { get; set; }
    public WasteViewModel Waste { get; set; }
    public decimal? CO2ReductionTons { get; set; }

}

public class WasteViewModel
{
    public string Title { get; set; }
}