namespace Domain.Entities;

public abstract class BaseEntity : BaseEntity<long>
{
    protected BaseEntity()
    {
    }

    protected BaseEntity(long id) : base(id)
    {
        Id = id;
    }
}
