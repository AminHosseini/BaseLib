using BaseLib.Application.Extensions;

namespace BaseLib.Application.Utility;

public static class ValidationMessages
{
    public static string MaximumCharactersMessage(int charCount)
        => $"حداکثر تعداد کاراکترهای مجاز {charCount.ToString(CultureInfo.InvariantCulture).EnglishToPersianNumber()} میباشد";

    public const string NullMessage = "این فیلد نمیتواند خالی باشد";
    public const string ZeroMessage = "لطفا مقدار دیگری را برای این فیلد انتخاب کنید";
    public const string SelectFromEnumListMessage = "لطفا یکی از موارد موجود در لیست را انتخاب نمایید";
    public const string ChooseAnotherEnumValueMessage = "مقدار انتخاب شده معتبر نیست";
    public const string PlaceNumberInFieldOnlyMessage = "این فیلد فقط میتواند شامل اعداد شود";
    public const string BothCanNotBeTrueAtOnce = "هردو مقدار نمیتوانند همزمان انتخاب شوند";
}
