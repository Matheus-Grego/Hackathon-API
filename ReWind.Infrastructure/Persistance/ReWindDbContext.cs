using HackathonEquipe6.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackathonEquipe6.Infrastructure.Persistance;

public class ReWindDbContext : DbContext
{
    public readonly DbContextOptions<ReWindDbContext> _dbContextOptions;
    public ReWindDbContext(DbContextOptions <ReWindDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Company> Company { get; set; }
    public DbSet<Park> Park { get; set; }
    public DbSet<ParkWaste>  ParkWaste { get; set; }
    public DbSet<Waste>  Waste { get; set; }
    public DbSet<CompanyWaste> CompanyWaste { get; set; }
    public DbSet<CompanySegment> CompanySegment { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Company>(e =>
        {
            e.HasKey(u => u.Id);
            
            e.HasMany(u => u.WantedWaste)
                .WithOne(us => us.Company)
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
        
        base.OnModelCreating(builder);
    }
}