//using Microsoft.EntityFrameworkCore.Diagnostics;
//using BaseLib.Context.Extensions;

//namespace BaseLib.Context.Interceptors;

//public class MetaDataInterceptor : SaveChangesInterceptor
//{
//    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,
//        InterceptionResult<int> result)
//    {
//        ArgumentNullException.ThrowIfNull(eventData?.Context);
//        BeforeSaveTriggers(eventData.Context);
//        return result;
//    }

//    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
//        InterceptionResult<int> result, CancellationToken cancellationToken = default)
//    {
//        ArgumentNullException.ThrowIfNull(eventData?.Context);
//        BeforeSaveTriggers(eventData.Context);
//        return new ValueTask<InterceptionResult<int>>(result);
//    }

//    private void BeforeSaveTriggers([NotNull] DbContext context)
//    {
//        var canDisabledEntities = context.ChangeTracker.Entries()
//            .Where(x => x.Entity is ICanDisable).ToList();

//        foreach (var canDisabledEntity in canDisabledEntities)
//        {
//            var currentDisableValue = canDisabledEntity.Property(ShadowProperty.IsDisabled).CurrentValue;
//            if (currentDisableValue is bool disableValue)
//            {
//                if (disableValue)
//                {
//                    canDisabledEntity.SetCurrentValue(ShadowProperty.DisableDate, DateTimeOffset.UtcNow);

//                    // This 1 must later be changed by a real user
//                    canDisabledEntity.SetCurrentValue(ShadowProperty.DisabledByUser, 1);
//                }
//                else
//                {
//                    canDisabledEntity.SetCurrentValue(ShadowProperty.DisableDate, null);
//                    canDisabledEntity.SetCurrentValue(ShadowProperty.DisabledByUser, null);
//                }
//            }
//        }
//    }
//}
