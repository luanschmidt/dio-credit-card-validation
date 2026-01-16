using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class CardBrandRegexDetector
{
    private static readonly Dictionary<CardBrand, Regex> CardRegexMap = new()
    {
        { CardBrand.Visa, new Regex(@"^4\d{12}(\d{3})?(\d{3})?$") },

        { CardBrand.Mastercard, new Regex(
            @"^(5[1-5]\d{14}|2(2[2-9]\d{2}|[3-6]\d{3}|7(0\d{2}|1\d{2}|20\d))\d{10})$") },

        { CardBrand.AmericanExpress, new Regex(@"^3[47]\d{13}$") },

        { CardBrand.DinersClub, new Regex(@"^3(0[0-5]|[68]\d)\d{11}$") },

        { CardBrand.Discover, new Regex(
            @"^(6011\d{12}(\d{3})?|65\d{14}(\d{3})?|64[4-9]\d{13}(\d{3})?|622(12[6-9]|1[3-9]\d|[2-8]\d{2}|9(0\d|1\d|2[0-5]))\d{10}(\d{3})?)$") },

        { CardBrand.JCB, new Regex(@"^35(2[8-9]|[3-8]\d)\d{12}(\d{3})?$") },

        { CardBrand.Elo, new Regex(
            @"^(4011(78|79)\d{10}|431274\d{10}|438935\d{10}|451416\d{10}|457(393|631|632)\d{10}|504175\d{10}|5067(0\d|1\d|2\d|3\d|4\d|5\d|6\d|7[0-8])\d{10}|509\d{13}|627780\d{10}|636297\d{10}|636368\d{10}|6500(3[1-9]|4\d|5[0-1])\d{10}|6504(0[5-9]|[1-3]\d)\d{10}|65048(5|6|7|8)\d{11}|6505(4[1-9]|[5-8]\d)\d{10}|6507(0\d|1[0-8])\d{10}|65072[0-7]\d{10}|6509(0[1-9]|[1-7]\d)\d{10}|65165[2-9]\d{10}|6550(0\d|1\d)\d{10})$") },

        { CardBrand.Hipercard, new Regex(@"^(384100|384140|384160|606282)\d{10}$") },

        { CardBrand.Aura, new Regex(@"^50\d{14}$") }
    };

    public static CardBrand Detect(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return CardBrand.Unknown;

        string digitsOnly = new string(cardNumber.Where(char.IsDigit).ToArray());

        foreach (var entry in CardRegexMap)
        {
            if (entry.Value.IsMatch(digitsOnly))
                return entry.Key;
        }

        return CardBrand.Unknown;
    }
}
