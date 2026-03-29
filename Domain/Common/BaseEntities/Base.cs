namespace Domain.Common.BaseEntities;

public abstract class Base<T>
{
    public T Id { get; set; } = default!;
    
    public bool IsDeleted { get; protected set; }
    public bool IsActive { get; protected set; } = true;

    public DateTime CreatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; }
    
    public DateTime? UpdatedAt { get; protected set; }
    public Guid? UpdatedBy { get; protected set; }
    
    public DateTime? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }

    protected void SetCreated(Guid userGuid)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userGuid;
        IsActive = true;
        IsDeleted = false;
    }

    protected void Touch(Guid userGuid)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userGuid;
    }

    public void Deactivate(Guid userGuid)
    {
        IsActive = false;
        Touch(userGuid);
    }

    public void Activate(Guid userGuid)
    {
        IsActive = true;
        Touch(userGuid);
    }

    public void Delete(Guid userGuid)
    {
        IsDeleted = true;
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = userGuid;
    }
}
