using Microsoft.Extensions.DependencyInjection;
//using BaseLib.Context.Interceptors;

namespace BaseLib.Context.Extensions;

public static class DbContextExtension
{
    //public static IReadOnlyList<EntityEntry> FindChangedEntries(this DbContext context)
    //{
    //    return (from x in context.ChangeTracker.Entries()
    //            where x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted
    //            select x).ToList();
    //}

    //public static byte[] EntityHash<TEntity>(this DbContext context, TEntity entity) where TEntity : class
    //{
    //    return RowIntegrityChecker.Generate(JsonSerializer.Serialize(context.Entry(entity).ToDictionary((p) => p.Metadata.Name != ShadowProperty.RowIntegrity && !p.Metadata.ValueGenerated.HasFlag(ValueGenerated.OnUpdate)), new JsonSerializerOptions
    //    {
    //        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    //    }));
    //}

    //public static string? EntitySerialize<TEntity>(this DbContext context, TEntity entity) where TEntity : class
    //{
    //    return JsonSerializer.Serialize(context.Entry(entity).ToDictionary((p) => p.Metadata.Name != ShadowProperty.RowIntegrity && !p.Metadata.ValueGenerated.HasFlag(ValueGenerated.OnUpdate)), new JsonSerializerOptions
    //    {
    //        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    //    });
    //}

    //public static DbContextOptionsBuilder AddDefaultInterceptors(this DbContextOptionsBuilder builder, IServiceProvider serviceProvider)
    //{
    //    builder.AddInterceptors(serviceProvider.GetRequiredService<MetaDataInterceptor>());
    //    return builder;
    //}
}
