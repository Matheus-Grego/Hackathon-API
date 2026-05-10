using HackathonEquipe6.Core.Enums;

namespace HackathonEquipe6.Core.Entities;

public class ParkWaste : BaseEntity
{
    public Guid ParkId { get; set; }
    public Guid WasteId { get; set; }
    public virtual Park Park { get; set; }
    public virtual Waste Waste { get; set; }
    public decimal Quantity { get; set; }
    public decimal PricePerTon { get; set; }
    public ParkWasteEnum CalculationType { get; set; }
    public decimal? CO2ReductionTons { get; set; }
}