using System.Buffers;

namespace BaseLib.Application.Utility;

public static class PersianNormalizer
{
    [Flags]
    public enum PersianCorrections : long
    {
        None = 0x0L,
        ConvertArabicYeKaf = 0x1L,
        ConvertArabicNumber = 0x2L,
        ConvertEnglishNumber = 0x4L,
        Translate = 0x8L,
        RemoveSpace = 0x10L
    }

    private const int _persianArabicNumberDiff = 144;

    private static readonly char[] _arabicNumbers =
        new char[10] { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };

    private static readonly Dictionary<char, char> _numericArabicPersianMap =
        _arabicNumbers.ToDictionary((key) => key, (value) => (char)(value + 144));

    private static readonly char[] _arabicYe = new char[11]
    {
        'ى', 'ي', 'ؠ', 'ؽ', 'ؾ', 'ؿ', 'ٸ', 'ې', 'ۑ', 'ۍ',
        'ێ'
    };

    private static readonly char[] _arabicKe = new char[4] { 'ك', 'ﮏ', 'ﮐ', 'ﮑ' };

    private const int _persianEnglishNumberDiff = 1728;

    private static readonly Dictionary<char, char> _numericEnglishPersianMap =
        Enumerable.Range(48, 57).ToDictionary((key)
            => (char)key, (value) => (char)(value + 1728));

    private static readonly Dictionary<char, char> _translateMap = new Dictionary<char, char>
    {
        ['ا'] = 'a',
        ['آ'] = 'a',
        ['ب'] = 'b',
        ['پ'] = 'p',
        ['ت'] = 't',
        ['ث'] = 'c',
        ['ج'] = 'g',
        ['چ'] = 'ċ',
        ['ح'] = 'ĥ',
        ['خ'] = 'ķ',
        ['د'] = 'd',
        ['ذ'] = 'ž',
        ['ر'] = 'r',
        ['ز'] = 'z',
        ['ژ'] = 'ƶ',
        ['س'] = 's',
        ['ش'] = 'ŝ',
        ['ص'] = 'ś',
        ['ض'] = 'ż',
        ['ط'] = 'ť',
        ['ظ'] = 'ź',
        ['ع'] = 'e',
        ['غ'] = 'ġ',
        ['ف'] = 'f',
        ['ق'] = 'q',
        ['ک'] = 'k',
        ['ك'] = 'k',
        ['ﮏ'] = 'k',
        ['ﮐ'] = 'k',
        ['ﮑ'] = 'k',
        ['گ'] = 'ķ',
        ['ل'] = 'l',
        ['م'] = 'm',
        ['ن'] = 'n',
        ['و'] = 'v',
        ['ه'] = 'h',
        ['ی'] = 'y',
        ['ئ'] = 'y',
        ['ء'] = 'y',
        ['ى'] = 'y',
        ['ي'] = 'y',
        ['ؠ'] = 'y',
        ['ؽ'] = 'y',
        ['ؾ'] = 'y',
        ['ؿ'] = 'y',
        ['ٸ'] = 'y',
        ['ې'] = 'y',
        ['ۑ'] = 'y',
        ['ۍ'] = 'y',
        ['ێ'] = 'y',
        ['٠'] = '0',
        ['١'] = '1',
        ['٢'] = '2',
        ['٣'] = '3',
        ['٤'] = '4',
        ['٥'] = '5',
        ['٦'] = '6',
        ['٧'] = '7',
        ['٨'] = '8',
        ['٩'] = '9',
        ['۰'] = '0',
        ['۱'] = '1',
        ['۲'] = '2',
        ['۳'] = '3',
        ['۴'] = '4',
        ['۵'] = '5',
        ['۶'] = '6',
        ['۷'] = '7',
        ['۸'] = '8',
        ['۹'] = '9'
    };

    public static ReadOnlySpan<char> NormalizeIt(this ReadOnlySpan<char> input,
        PersianCorrections corrections = PersianCorrections.ConvertArabicYeKaf
        | PersianCorrections.ConvertArabicNumber)
    {
        if (input.Length == 0)
            return Span<char>.Empty;

        bool flag = corrections.HasFlag(PersianCorrections.ConvertArabicYeKaf);
        bool flag2 = corrections.HasFlag(PersianCorrections.ConvertArabicNumber);
        bool flag3 = corrections.HasFlag(PersianCorrections.ConvertEnglishNumber);
        bool flag4 = corrections.HasFlag(PersianCorrections.Translate);
        bool num = corrections.HasFlag(PersianCorrections.RemoveSpace);

        Span<char> span = new Span<char>(input.ToArray());
        int length = span.Length;
        if (num)
            span = RemoveWhitespaces(span);

        length = span.Length;
        for (int i = 0; i < length; i++)
        {
            char c = span[i];
            if (flag2 && _arabicNumbers.Contains(c))
            {
                span[i] = _numericArabicPersianMap[c];
                continue;
            }

            char value = c;
            if (flag && _arabicYe.Contains(value))
            {
                span[i] = 'ی';
                continue;
            }

            char value2 = c;
            if (flag && _arabicKe.Contains(value2))
            {
                span[i] = 'ک';
                continue;
            }

            char c2 = c;
            if (c2 >= '0' && c2 <= '9' && flag3)
            {
                span[i] = _numericEnglishPersianMap[c2];
                continue;
            }

            char key = c;
            if (flag4 && _translateMap.ContainsKey(key))
                span[i] = _translateMap[key];
        }

        return span;
    }

    private static Span<char> RemoveWhitespaces(Span<char> input)
    {
        char[] array = ArrayPool<char>.Shared.Rent(input.Length);
        try
        {
            return RemoveWhitespacesSpanHelper(input, array.AsSpan(0, input.Length));
        }
        finally
        {
            ArrayPool<char>.Shared.Return(array);
        }
    }

    private static Span<char> RemoveWhitespacesSpanHelper(Span<char> input, Span<char> dest)
    {
        int num = 0;
        Span<char> span = input;
        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];
            if (!char.IsWhiteSpace(c))
                dest[num++] = c;
        }

        if (input.Length != num)
            return dest.Slice(0, num);

        return input;
    }

    public static ReadOnlySpan<char> ReplaceArabic(this ReadOnlySpan<char> input,
        PersianCorrections extra = PersianCorrections.ConvertArabicYeKaf | PersianCorrections.ConvertArabicNumber)
        => input.NormalizeIt(PersianCorrections.ConvertArabicYeKaf | PersianCorrections.ConvertArabicNumber | extra);

    public static ReadOnlySpan<char> ReplaceArabic(this string? input,
        PersianCorrections extra = PersianCorrections.ConvertArabicYeKaf | PersianCorrections.ConvertArabicNumber)
        => NormalizeIt(input, PersianCorrections.ConvertArabicYeKaf | PersianCorrections.ConvertArabicNumber | extra);

    public static ReadOnlySpan<char> ReplaceEnglishNumber(this ReadOnlySpan<char> input)
        => input.NormalizeIt(PersianCorrections.ConvertEnglishNumber);

    public static ReadOnlySpan<char> ReplaceEnglishNumber(this string? input)
        => NormalizeIt(input, PersianCorrections.ConvertEnglishNumber);

    public static ReadOnlySpan<char> TranslateIt(this ReadOnlySpan<char> input)
        => input.NormalizeIt(PersianCorrections.Translate | PersianCorrections.RemoveSpace);

    public static ReadOnlySpan<char> TranslateIt(this string? input)
        => NormalizeIt(input, PersianCorrections.Translate | PersianCorrections.RemoveSpace);
}