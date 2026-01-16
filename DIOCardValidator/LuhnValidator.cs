public static class LuhnValidator
{
    public static bool IsValid(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return false;

        string digitsOnly = ExtractDigits(cardNumber);

        if (digitsOnly.Length == 0)
            return false;

        int checksumTotal = 0;
        bool shouldDouble = false;

        for (int index = digitsOnly.Length - 1; index >= 0; index--)
        {
            int digit = digitsOnly[index] - '0';

            if (shouldDouble)
                digit = DoubleAndNormalize(digit);

            checksumTotal += digit;
            shouldDouble = !shouldDouble;
        }

        return checksumTotal % 10 == 0;
    }

    private static string ExtractDigits(string input)
    {
        return new string(input.Where(char.IsDigit).ToArray());
    }

    private static int DoubleAndNormalize(int digit)
    {
        int doubled = digit * 2;
        return doubled > 9 ? doubled - 9 : doubled;
    }
}
