namespace Domain.Contracts;

public interface IEntity<TKey> : IEntity where TKey : struct
{
    TKey Id { get; set; }
    Guid SerialNumber { get; set; }
}
