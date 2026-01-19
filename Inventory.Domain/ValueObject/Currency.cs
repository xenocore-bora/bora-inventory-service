using System.Data;

namespace Inventory.Domain.ValueObject;

public sealed record Currency
{
    public string Code { get; }

    public static Currency PEN => From("PEN");
    public static Currency USD => From("USD");
    
    private Currency(string code)
    {
        Code = code;
    }

    public static Currency From(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new NoNullAllowedException("Currency Code is empty");
        return new Currency(code.ToUpper());
    }
};