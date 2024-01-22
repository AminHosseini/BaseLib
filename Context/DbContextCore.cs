namespace Context;

public abstract class DbContextCore : DbContext
{
    //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    //{
    //    configurationBuilder.Properties<DateOnly>().HaveConversion<MyDateOnlyConverter>().HaveColumnType("date");
    //    configurationBuilder.Properties<DateOnly?>().HaveConversion<NullableDateOnlyConverter>().HaveColumnType("date");
    //}
}
