namespace Context.Dtos.RowVersion;

public readonly struct IdRowVersion : IEquatable<IdRowVersion>
{
    public long Id { get; init; }

    public RowVersionValue RowVersion { get; init; }

    public IdRowVersion(long Id, RowVersionValue RowVersion)
    {
        this.Id = Id;
        this.RowVersion = RowVersion;
    }

    [CompilerGenerated]
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("IdRowVersion");
        stringBuilder.Append(" { ");

        if (PrintMembers(stringBuilder))
            stringBuilder.Append(' ');

        stringBuilder.Append('}');
        return stringBuilder.ToString();
    }

    [CompilerGenerated]
    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append("Id = ");
        builder.Append(Id.ToString());
        builder.Append(", RowVersion = ");
        builder.Append(RowVersion.ToString());
        return true;
    }

    [CompilerGenerated]
    public static bool operator !=(IdRowVersion left, IdRowVersion right)
        => !(left == right);

    [CompilerGenerated]
    public static bool operator ==(IdRowVersion left, IdRowVersion right)
        => left.Equals(right);

    [CompilerGenerated]
    public override int GetHashCode()
        => EqualityComparer<long>.Default.GetHashCode(Id) * -1521134295
            + EqualityComparer<RowVersionValue>.Default.GetHashCode(RowVersion);

    [CompilerGenerated]
    public override bool Equals([AllowNull] object obj)
        => obj is IdRowVersion ? Equals((IdRowVersion)obj) : false;

    [CompilerGenerated]
    public bool Equals(IdRowVersion other)
        => EqualityComparer<long>.Default.Equals(Id, other.Id)
        ? EqualityComparer<RowVersionValue>.Default.Equals(RowVersion, other.RowVersion)
        : false;

    [CompilerGenerated]
    public void Deconstruct(out long Id, out RowVersionValue RowVersion)
    {
        Id = this.Id;
        RowVersion = this.RowVersion;
    }
}
