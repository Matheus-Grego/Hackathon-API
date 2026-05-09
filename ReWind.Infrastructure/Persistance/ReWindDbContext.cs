using HackathonEquipe6.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackathonEquipe6.Infrastructure.Persistance;

public class ReWindDbContext : DbContext
{
    public ReWindDbContext(DbContextOptions <ReWindDbContext> options) : base(options)
    {
        
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Park> Parks { get; set; }
    public DbSet<ParkWaste> ParkWastes { get; set; }
    public DbSet<Waste> Wastes { get; set; }
    public DbSet<CompanyWaste> CompanyWastes { get; set; }
    public DbSet<CompanySegment> CompanySegments { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Company>(e =>
        {
            e.HasKey(u => u.Id);
            
            e.HasMany(u => u.WantedWaste)
                .WithOne(us => us.Company)
                .HasForeignKey(us => us.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasMany(u => u.CompanySegments)
                .WithOne(s => s.Company)
                .HasForeignKey(us => us.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

        });
        builder.Entity<Park>(e =>
        {
            e.HasKey(u => u.Id);
            
            e.HasMany(u => u.ParkWaste)
                .WithOne(us => us.Park)
                .HasForeignKey(us => us.ParkId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        builder.Entity<ParkWaste>(e =>
        {
            e.HasKey(u => u.Id);
        });
        builder.Entity<Waste>(e =>
        {
            e.HasKey(u => u.Id);
        });
        
        builder.Entity<CompanyWaste>(e =>
        {
            e.HasKey(u => u.Id);
        });
        
        builder.Entity<CompanySegment>(e =>
        {
            e.HasKey(u => u.Id);
        });
        
        
        base.OnModelCreating(builder);
    }
}