namespace BaseLib.Domain.Entities;

/// <summary>
/// موجودیت اصلی مورد استفاده با تاریخ شروع و پایان و آیدی از نوع لانگ
/// </summary>
public abstract class BaseFromUntilEntity : BaseEntity, IFromUntilEntity
{
    public DateOnly FromDate { get; set; }
    public DateOnly UntilDate { get; set; }
}
