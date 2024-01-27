namespace BaseLib.Context;

public static class ShadowProperty
{
    public static readonly string RowVersion = "_RowVersion";

    public static readonly string IsDeleted = "_IsDeleted";

    public static readonly string DeletedByUser = "_DeletedByUser";

    public static readonly string DeleteDate = "_DeleteDate";

    public static readonly string IsDisabled = "_IsDisabled";

    public static readonly string DisabledByUser = "_DisabledByUser";

    public static readonly string DisableDate = "_DisableDate";

    public static readonly string IsFirst = $"_{nameof(IsFirst)}";

    public static readonly string IsLast = $"_{nameof(IsLast)}";
}
