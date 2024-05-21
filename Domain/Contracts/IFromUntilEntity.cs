namespace BaseLib.Domain.Contracts;

/// <summary>
/// رابط موجودیت  دارای تاریخ شروع و پایان
/// </summary>
public interface IFromUntilEntity
{
    /// <summary>
    /// تاریخ شروع
    /// </summary>
    DateOnly FromDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    DateOnly UntilDate { get; set; }
}
