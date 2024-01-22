﻿namespace Application.Extensions;

public static class NumberExtension
{
    public static string EnglishToPersianNumber(this string englishStr)
    {
        ArgumentException.ThrowIfNullOrEmpty(englishStr);
        Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
        {
            ['0'] = '۰',
            ['1'] = '۱',
            ['2'] = '۲',
            ['3'] = '۳',
            ['4'] = '۴',
            ['5'] = '۵',
            ['6'] = '۶',
            ['7'] = '۷',
            ['8'] = '۸',
            ['9'] = '۹'
        };
        foreach (var item in englishStr)
        {
            englishStr = englishStr.Replace(item, LettersDictionary[item]);
        }
        return englishStr;
    }
}