namespace BaseLib.Domain.Contracts;

/// <summary>
/// رابط موجودیت با نوع عمومی دارای آیدی
/// </summary>
/// <typeparam name="TKey">نوع</typeparam>
public interface IEntity<TKey> : IEntity where TKey : struct
{
    /// <summary>
    /// آیدی
    /// </summary>
    TKey Id { get; set; }

    ///// <summary>
    ///// شماره سریال برای ارتباط با سرویس خارجی
    ///// </summary>
    //Guid SerialNumber { get; set; }
}
