using Microsoft.EntityFrameworkCore.Metadata;
using BaseLib.Domain.Contracts;

namespace BaseLib.Context.Extensions;

public static class ModelBuilderExtension
{
    private static Type[] GetEntityTypes<T>(this ModelBuilder modelBuilder, out bool isEmpty)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, "modelBuilder");
        isEmpty = false;
        Type[] array = (from entity in modelBuilder.Model.GetEntityTypes()
                        where typeof(T)!.IsAssignableFrom(entity.ClrType) && !entity.IsOwned()
                        select entity.ClrType).ToArray();
        if (array == null || array.Length <= 0)
        {
            isEmpty = true;
            return Enumerable.Empty<Type>().ToArray();
        }

        return array;
    }

    private static IMutableEntityType[] GetEntities<T>(this ModelBuilder modelBuilder, out bool isEmpty)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, "modelBuilder");
        isEmpty = false;
        IMutableEntityType[] array = (from entity in modelBuilder.Model.GetEntityTypes()
                                      where typeof(T)!.IsAssignableFrom(entity.ClrType) && !entity.IsOwned()
                                      select entity).ToArray();
        if (array == null || array.Length <= 0)
        {
            isEmpty = true;
            return Enumerable.Empty<IMutableEntityType>().ToArray();
        }

        return array;
    }

    public static ModelBuilder ApplyEntity(this ModelBuilder modelBuilder)
    {
        bool isEmpty;
        Type[] entityTypes = modelBuilder.GetEntityTypes<IEntity<long>>(out isEmpty);
        if (isEmpty)
            return modelBuilder;

        foreach (Type type in entityTypes)
        {
            modelBuilder.Entity(type).HasKey("Id");
            //modelBuilder.Entity(type).Property<Guid>("SerialNumber").HasDefaultValueSql("(newsequentialid())")
            //    .HasComment("شماره سریال برای ارتباط با باقی سیستم ها")
            //    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplyRowVersion(this ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, "modelBuilder");
        Type[] array = (from entity in modelBuilder.Model.GetEntityTypes()
                        where typeof(IEntity)!.IsAssignableFrom(entity.ClrType) && !entity.IsOwned()
                        select entity.ClrType).ToArray();
        if (array == null || array.Length <= 0)
            return modelBuilder;

        foreach (Type type in array)
            modelBuilder.Entity(type).Property<byte[]>(ShadowProperty.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasComment("بررسی همزمانی");

        return modelBuilder;
    }

    public static ModelBuilder ApplyFromUntil(this ModelBuilder modelBuilder)
    {
        bool isEmpty;
        IMutableEntityType[] entities = modelBuilder.GetEntities<IFromUntilEntity>(out isEmpty);
        if (isEmpty)
            return modelBuilder;

        foreach (IMutableEntityType mutableEntityType in entities)
        {
            modelBuilder.Entity(mutableEntityType.Name).Property<DateOnly>("FromDate").HasDefaultValue(DateOnly.MinValue);
            modelBuilder.Entity(mutableEntityType.Name).Property<DateOnly>("UntilDate").HasDefaultValue(DateOnly.MaxValue);
            mutableEntityType.AddCheckConstraint("CK_" + mutableEntityType.GetTableName() + "_FromUntil", "(UntilDate>=FromDate)");
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplySoftDelete(this ModelBuilder modelBuilder)
    {
        bool isEmpty;
        IMutableEntityType[] entities = modelBuilder.GetEntities<IHaveSoftDelete>(out isEmpty);
        if (isEmpty)
            return modelBuilder;

        foreach (IMutableEntityType mutableEntityType in entities)
        {
            modelBuilder.Entity(mutableEntityType.Name).Property<bool>(ShadowProperty.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity(mutableEntityType.Name).Property<long?>(ShadowProperty.DeletedByUser)
                .HasComment("کاربر حذف کننده");

            modelBuilder.Entity(mutableEntityType.Name).Property<DateTimeOffset?>(ShadowProperty.DeleteDate)
                .HasComment("تاریخ حذف");
        }

        return modelBuilder;
    }

    //public static ModelBuilder ApplyDisable(this ModelBuilder modelBuilder)
    //{
    //    bool isEmpty;
    //    IMutableEntityType[] entities = modelBuilder.GetEntities<ICanDisable>(out isEmpty);
    //    if (isEmpty)
    //        return modelBuilder;

    //    foreach (IMutableEntityType mutableEntityType in entities)
    //    {
    //        modelBuilder.Entity(mutableEntityType.Name).Property<bool>(ShadowProperty.IsDisabled).HasDefaultValue(false)
    //            .HasComment("آیا غیرفعال است");

    //        modelBuilder.Entity(mutableEntityType.Name).Property<Guid?>(ShadowProperty.DisabledByUser)
    //            .HasComment("کاربر غیرفعال کننده");

    //        modelBuilder.Entity(mutableEntityType.Name).Property<DateTimeOffset?>(ShadowProperty.DisableDate)
    //            .HasComment("تاریخ غیرفعال");
    //    }

    //    return modelBuilder;
    //}

    public static ModelBuilder ApplyCreationDate(this ModelBuilder modelBuilder)
    {
        bool isEmpty;
        IMutableEntityType[] entities = modelBuilder.GetEntities<IHaveCreationInfo>(out isEmpty);
        if (isEmpty)
            return modelBuilder;

        foreach (IMutableEntityType mutableEntityType in entities)
        {
            modelBuilder.Entity(mutableEntityType.Name).Property<DateTimeOffset>(ShadowProperty.CreationDate)
                .HasDefaultValue(DateTimeOffset.UtcNow).HasComment("تاریخ ساخت");

            // This 1 must later be changed by a real user
            modelBuilder.Entity(mutableEntityType.Name).Property<long>(ShadowProperty.CreatedByUser)
                .HasDefaultValue(1).HasComment("کاربر سازنده");
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplyAll(this ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder, "modelBuilder");
        return modelBuilder
            .ApplyEntity()
            .ApplyRowVersion()
            .ApplyFromUntil()
            .ApplySoftDelete()
            .ApplyCreationDate();
        //.ApplyDisable();
    }
}
