using System.Diagnostics.CodeAnalysis;

namespace BaseLib.Domain.Entities;

/// <summary>
/// پیاده سازی موجودیت با نوع عمومی دارای آیدی
/// </summary>
/// <typeparam name="TKey">نوع</typeparam>
public abstract class BaseEntity<TKey> : IEntity<TKey>, IEntity where TKey : struct
{
    /// <summary>
    /// آیدی
    /// </summary>
    public TKey Id { get; set; }
    //public Guid SerialNumber { get; set; }

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
    protected BaseEntity(TKey id)
    {
        Id = id;
    }

    public override bool Equals([AllowNull] object obj)
    {
        if (obj is null)
            return false;

        BaseEntity<TKey>? baseEntity = obj as BaseEntity<TKey>;
        if ((object)baseEntity! is null)
            return false;

        if ((object)this == baseEntity)
            return true;

        if (GetUnproxiedType(this) != GetUnproxiedType(baseEntity))
            return false;

        if (IsTransient() || baseEntity.IsTransient())
        {
            return false;
        }

        return Id.Equals(baseEntity.Id);
    }

    private bool IsTransient() => Id.Equals(default(TKey));

    public static bool operator ==(BaseEntity<TKey> a, BaseEntity<TKey> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(BaseEntity<TKey> a, BaseEntity<TKey> b) => !(a == b);

    public override int GetHashCode() => (GetUnproxiedType(this).ToString() + Id).GetHashCode();

    internal static Type GetUnproxiedType(object obj)
    {
        Type type = obj.GetType();
        string text = type.ToString();

        if (text.Contains("Castle.Proxies.") || text.EndsWith("Proxy"))
            return type.BaseType ?? type;

        return type;
    }
}
