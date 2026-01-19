namespace Inventory.Domain.ValueObject;

public sealed record Price
{
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }

    private Price()
    {
        Amount = 0.00m;
        Currency = Currency.USD;
    }

    private Price(decimal amount, string currencyCode)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Price amount must be greater than zero");
        Amount = amount;
        Currency = Currency.From(currencyCode);
    }

    private Price(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Price amount must be greater than zero");
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Price amount must be greater than zero");
        return new Price(amount, currency);
    }
}