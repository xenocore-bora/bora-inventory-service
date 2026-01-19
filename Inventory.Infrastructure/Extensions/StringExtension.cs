namespace Inventory.Infrastructure.Extensions;

public static class StringExtension
{
    public static string ToSnakeCase(this string str)
    {
        IEnumerable<char> Convert(IEnumerator<char> enumerator)
        {
            if(!enumerator.MoveNext())
                yield break;
            yield return char.ToLower(enumerator.Current);
            while (enumerator.MoveNext())
            {
                if (char.IsUpper(enumerator.Current))
                    yield return '_';
                yield return char.ToLower(enumerator.Current);
            }
        }
        return new string(Convert(str!.GetEnumerator()).ToArray());
    }
}