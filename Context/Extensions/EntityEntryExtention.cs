using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Context.Extensions;

public static class EntityEntryExtention
{
    //public static Dictionary<string, object?> ToDictionary([NotNull] this EntityEntry entry, Func<PropertyEntry, bool> predicate)
    //    => entry.Properties.Where(predicate).ToDictionary((p) => p.Metadata.Name, (p) => p.CurrentValue);

    //public static Dictionary<string, object?> ToDictionary([NotNull] this EntityEntry entry)
    //    => entry.Properties.ToDictionary((p) => p.Metadata.Name, (p) => p.CurrentValue);

    public static void SetCurrentValue([NotNull] this EntityEntry entry, string propertyName, object? value)
    {
        string propertyName2 = propertyName;
        if (entry.Properties.Any((x) => x.Metadata.Name == propertyName2))
            entry.Property(propertyName2).CurrentValue = value;
    }

    //public static void SetRowVersionCurrentValue([NotNull] this EntityEntry entry, RowVersionValue value)
    //    => entry.SetCurrentValue(ShadowProperty.RowVersion, value.ToByteArray());

    //public static void SetRowVersionCurrentValue([NotNull] this EntityEntry entry, string value)
    //    => entry.SetCurrentValue(ShadowProperty.RowVersion, Convert.FromBase64String(value));

    //public static void SetRowVersionCurrentValue([NotNull] this EntityEntry entry, byte[] value)
    //    => entry.SetCurrentValue(ShadowProperty.RowVersion, value);
}
