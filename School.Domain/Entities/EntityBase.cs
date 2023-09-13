namespace School.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }
}