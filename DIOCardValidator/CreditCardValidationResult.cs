public class CreditCardValidationResult
{
    public bool IsValid { get; set; }
    public CardBrand Brand { get; set; }
    public string Message { get; set; } = string.Empty;
}
