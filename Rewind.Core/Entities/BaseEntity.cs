namespace HackathonEquipe6.Core.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public void SetDeleted()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }

}