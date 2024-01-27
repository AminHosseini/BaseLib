namespace BaseLib.Context.Dtos.RowVersion;

public readonly struct IdRowVersionGet : IEquatable<IdRowVersionGet>
{
    public long Id { get; }

    public string RowVersion { get; }

    public IdRowVersionGet(long id, RowVersionValue rowVersion)
    {
        Id = id;
        RowVersion = rowVersion.ToString();
    }

    public IdRowVersionGet(RowVersionValue rowVersion, long id)
    {
        Id = id;
        RowVersion = rowVersion.ToString();
    }

    public IdRowVersionGet(long id, string rowVersion)
    {
        Id = id;
        RowVersion = rowVersion;
    }

    public IdRowVersionGet(string rowVersion, long id)
    {
        Id = id;
        RowVersion = rowVersion;
    }

    [CompilerGenerated]
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("IdRowVersionGet");
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
        builder.Append((object?)RowVersion);
        return true;
    }

    [CompilerGenerated]
    public static bool operator !=(IdRowVersionGet left, IdRowVersionGet right)
        => !(left == right);

    [CompilerGenerated]
    public static bool operator ==(IdRowVersionGet left, IdRowVersionGet right)
        => left.Equals(right);

    [CompilerGenerated]
    public override int GetHashCode()
        => EqualityComparer<long>.Default.GetHashCode(Id) * -1521134295
            + EqualityComparer<string>.Default.GetHashCode(RowVersion);

    [CompilerGenerated]
    public override bool Equals([AllowNull] object obj)
        => obj is IdRowVersionGet ? Equals((IdRowVersionGet)obj) : false;

    [CompilerGenerated]
    public bool Equals(IdRowVersionGet other)
        => EqualityComparer<long>.Default.Equals(Id, other.Id)
        ? EqualityComparer<string>.Default.Equals(RowVersion, other.RowVersion)
        : false;
}
