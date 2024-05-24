using BaseLib.Application.Extensions;

namespace BaseLib.Application.Utility;

public static class ValidationMessages
{
    public static string MaximumCharactersMessage(int charCount)
        => $"حداکثر تعداد کاراکترهای مجاز {charCount.ToString(CultureInfo.InvariantCulture).EnglishToPersianNumber()} میباشد";

    public static string MaximumCharactersForListMembersMessage(int charCount)
        => $"حداکثر تعداد کاراکترهای مجاز برای هرکدام {charCount.ToString(CultureInfo.InvariantCulture).EnglishToPersianNumber()} میباشد";

    public static string MaximumListCountMessage(int charCount)
        => $"حداکثر تعداد مجاز {charCount.ToString(CultureInfo.InvariantCulture).EnglishToPersianNumber()} میباشد";

    public static string MaximumFileSize(long size)
        => $"اندازه فایل باید حداکثر {size.ToString(CultureInfo.InvariantCulture).EnglishToPersianNumber()} مگابایت باشد";

    public static string AllowedFileFormats(string allowedFormats)
        => $"هستید {allowedFormats} فقط مجاز به آپلود فایل با فرمت های";

    public const string NullMessage = "این فیلد نمیتواند خالی باشد";
    public const string ZeroMessage = "لطفا مقدار دیگری را برای این فیلد انتخاب کنید";
    public const string SelectFromEnumListMessage = "لطفا یکی از موارد موجود در لیست را انتخاب نمایید";
    public const string ChooseAnotherEnumValueMessage = "مقدار انتخاب شده معتبر نیست";
    public const string PlaceNumberInFieldOnlyMessage = "این فیلد فقط میتواند شامل اعداد شود";
    public const string BothCanNotBeTrueAtOnce = "هردو مقدار نمیتوانند همزمان انتخاب شوند";
}
