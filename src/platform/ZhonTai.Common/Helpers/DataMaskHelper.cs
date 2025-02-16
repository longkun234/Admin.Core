﻿using System.Text.RegularExpressions;

namespace ZhonTai.Common.Helpers;

/// <summary>
/// 数据脱敏
/// </summary>
public partial class DataMaskHelper
{
   
    [GeneratedRegex("(\\d{3})\\d{4}(\\d{4})")]
    public static partial Regex PhoneMaskRegex();

    [GeneratedRegex("(?<=.{2})[^@]+(?=.{2}@)")]
    public static partial Regex EmailMaskRegex();

    /// <summary>
    /// 手机号脱敏
    /// </summary>
    /// <param name="input"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static string PhoneMask(string input, string mask = "****")
    {
        if (input.IsNull()) { 
            return input; 
        }

        return PhoneMaskRegex().Replace(input, $"$1{mask}$2");
    }

    /// <summary>
    /// 邮箱脱敏
    /// </summary>
    /// <param name="input"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static string EmailMask(string input, string mask = "****")
    {
        if (input.IsNull())
        {
            return input;
        }

        return EmailMaskRegex().Replace(input, mask);
    }
}