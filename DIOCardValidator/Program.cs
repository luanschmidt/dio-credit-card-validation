class Program
{
    static void Main()
    {
        Console.WriteLine("Credit Card Validator");
        Console.WriteLine("---------------------");

        while (true)
        {
            Console.Write("\nEnter credit card number (or 'exit'): ");
            string? input = Console.ReadLine();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                break;

            var result = ValidateCard(input ?? string.Empty);

            Console.WriteLine($"Brand   : {result.Brand}");
            Console.WriteLine($"Valid   : {result.IsValid}");
            Console.WriteLine($"Message : {result.Message}");
        }
    }

    private static CreditCardValidationResult ValidateCard(string cardNumber)
    {
        var brand = CardBrandRegexDetector.Detect(cardNumber);
        bool luhnValid = LuhnValidator.IsValid(cardNumber);

        return new CreditCardValidationResult
        {
            Brand = brand,
            IsValid = brand != CardBrand.Unknown && luhnValid,
            Message = luhnValid
                ? "Credit card number is valid."
                : "Invalid credit card number."
        };
    }
}
