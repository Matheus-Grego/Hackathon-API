namespace HackathonEquipe6.Core.Entities;

public class Park : BaseEntity
{
    public string Name { get; set; }
    public string DocumentNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public virtual List<ParkWaste> ParkWaste { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}