namespace BaseLib.Context;

/// <summary>
/// ویژگی/ستون های عمومی موجودیت ها
/// </summary>
public static class ShadowProperty
{
    /// <summary>
    /// برای جلوگیری از مشکل همزمانی
    /// </summary>
    public static readonly string RowVersion = "_RowVersion";

    /// <summary>
    /// آیا حذف شده است؟
    /// </summary>
    public static readonly string IsDeleted = "_IsDeleted";

    /// <summary>
    /// کاربر حذف کننده
    /// </summary>
    public static readonly string DeletedByUser = "_DeletedByUser";

    /// <summary>
    /// تاریخ حذف
    /// </summary>
    public static readonly string DeleteDate = "_DeleteDate";

    /// <summary>
    /// غیرفعال شده است؟
    /// </summary>
    public static readonly string IsDisabled = "_IsDisabled";

    /// <summary>
    /// کاربر غیرفعال کننده
    /// </summary>
    public static readonly string DisabledByUser = "_DisabledByUser";

    /// <summary>
    /// تاریخ غیر فعال شدن
    /// </summary>
    public static readonly string DisableDate = "_DisableDate";

    /// <summary>
    /// اولی؟
    /// </summary>
    public static readonly string IsFirst = $"_{nameof(IsFirst)}";

    /// <summary>
    /// آخری؟
    /// </summary>
    public static readonly string IsLast = $"_{nameof(IsLast)}";

    /// <summary>
    /// تاریخ ساخت
    /// </summary>
    public static readonly string CreationDate = $"_{nameof(CreationDate)}";

    /// <summary>
    /// کاربر سازنده
    /// </summary>
    public static readonly string CreatedByUser = $"_{nameof(CreatedByUser)}";
}
