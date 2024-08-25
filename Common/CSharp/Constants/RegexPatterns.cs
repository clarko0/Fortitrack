using System.Text.RegularExpressions;

namespace Common.Constants;
public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")]
    public static partial Regex EmailValidationPattern();

    [GeneratedRegex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
    public static partial Regex PasswordStrengthValidationPattern();
}