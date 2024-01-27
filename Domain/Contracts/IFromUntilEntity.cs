namespace BaseLib.Domain.Contracts;

public interface IFromUntilEntity
{
    DateOnly FromDate { get; set; }
    DateOnly UntilDate { get; set; }
}
