namespace Domain.Entities;

public abstract class BaseFromUntilEntity : BaseEntity, IFromUntilEntity
{
    public DateOnly FromDate { get; set; }
    public DateOnly UntilDate { get; set; }
}
