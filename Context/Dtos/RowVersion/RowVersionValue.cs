namespace Context.Dtos.RowVersion;

public readonly struct RowVersionValue : IParsable<RowVersionValue>, IEquatable<RowVersionValue>
{
    private readonly byte[] _value;

    public string RowVersion { get; }

    public RowVersionValue(string value)
    {
        _value = Convert.FromBase64String(Uri.UnescapeDataString(value));
        RowVersion = value;
    }

    public RowVersionValue(byte[] value)
    {
        _value = value;
        RowVersion = Convert.ToBase64String(value);
    }

    public static implicit operator byte[](RowVersionValue d)
        => d._value;

    public byte[] ToByteArray()
        => _value;

    public static implicit operator string(RowVersionValue d)
        => d.RowVersion;

    public override string ToString()
        => RowVersion;

    public static implicit operator RowVersionValue(string v)
        => new RowVersionValue(v);

    public static RowVersionValue FromString(string v)
        => new RowVersionValue(v);

    public static implicit operator RowVersionValue(byte[] v)
        => new RowVersionValue(v);

    public static RowVersionValue FromByteArray(byte[] v)
        => new RowVersionValue(v);

    public static RowVersionValue Parse(string s, IFormatProvider? provider)
        => !TryParse(s, provider, out var result)
        ? throw new ArgumentException("Could not parse the given value.", "s")
        : result;

    static RowVersionValue IParsable<RowVersionValue>.Parse(string s, IFormatProvider? provider)
        => Parse(s, provider);

    public static bool TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out RowVersionValue result)
    {
        result = default;
        if (s == null)
            return false;

        result = FromString(Uri.UnescapeDataString(s));
        return true;
    }

    static bool IParsable<RowVersionValue>.TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out RowVersionValue result)
        => TryParse(s, provider, out result);

    [CompilerGenerated]
    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append("RowVersion = ");
        builder.Append((object?)RowVersion);
        return true;
    }

    [CompilerGenerated]
    public static bool operator !=(RowVersionValue left, RowVersionValue right)
        => !(left == right);

    [CompilerGenerated]
    public static bool operator ==(RowVersionValue left, RowVersionValue right)
        => left.Equals(right);

    [CompilerGenerated]
    public override int GetHashCode()
        => EqualityComparer<byte[]>.Default.GetHashCode(_value) * -1521134295
        + EqualityComparer<string>.Default.GetHashCode(RowVersion);

    [CompilerGenerated]
    public override bool Equals([AllowNull] object obj)
        => obj is RowVersionValue
        ? Equals((RowVersionValue)obj)
        : false;

    [CompilerGenerated]
    public bool Equals(RowVersionValue other)
        => EqualityComparer<byte[]>.Default.Equals(_value, other._value)
        ? EqualityComparer<string>.Default.Equals(RowVersion, other.RowVersion)
        : false;
}
