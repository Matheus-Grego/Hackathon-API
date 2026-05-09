using HackathonEquipe6.Core.Entities;

namespace HackathonEquipe6.Application.Models;

public class ParkViewModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    
    public string DocumentNumber { get; set; }
    public string Owner { get; set; }
    public DateTime? OperationStartDate { get; set; }
    public decimal AuthorizedPowerKw { get; set; }
    public decimal InspectedPowerKw { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public virtual List<ParkWaste> ParkWaste { get; set; }
    
    
    public static ParkViewModel FromEntity(Park entity)
    {
        return new ParkViewModel
        {
            Name = entity.Name,
            Address = entity.Address,
            City = entity.City,
            State = entity.State,
            ZipCode = entity.ZipCode,
            Phone = entity.Phone,
            Email = entity.Email,
            DocumentNumber = entity.DocumentNumber,
            Owner = entity.Owner,
            OperationStartDate = entity.OperationStartDate,
            AuthorizedPowerKw = entity.AuthorizedPowerKw,
            InspectedPowerKw = entity.InspectedPowerKw,
            Latitude = entity.Latitude,
            Longitude = entity.Longitude,
            ParkWaste = entity.ParkWaste
        };
    }

    public Park ToEntity(string password)
    {
        return new Park
        {
            Name = this.Name,
            Address = this.Address,
            City = this.City,
            State = this.State,
            ZipCode = this.ZipCode,
            Phone = this.Phone,
            Email = this.Email,
            Password = password,
            DocumentNumber = this.DocumentNumber,
            Owner = this.Owner,
            OperationStartDate = this.OperationStartDate,
            AuthorizedPowerKw = this.AuthorizedPowerKw,
            InspectedPowerKw = this.InspectedPowerKw,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            ParkWaste = this.ParkWaste
        };
    }

}