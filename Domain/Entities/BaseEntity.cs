namespace BaseLib.Domain.Entities;

/// <summary>
/// موجودیت اصلی مورد استفاده با آیدی از نوع لانگ
/// </summary>
public abstract class BaseEntity : BaseEntity<long>
{
    /// <summary>
    /// سازنده کلاس
    /// </summary>
    protected BaseEntity()
    {
    }

    /// <summary>
    /// سازنده کلاس با آیدی
    /// </summary>
    /// <param name="id">آیدی</param>
    protected BaseEntity(long id) : base(id)
    {
        Id = id;
    }
}
