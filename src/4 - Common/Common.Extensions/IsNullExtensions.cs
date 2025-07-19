public static class IsNullExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
    {
        return obj.IsNull() || !obj.Any();
    }

    public static bool IsNull(this object obj)
    {
        return obj == null;
    }

    public static bool IsNotNull(this object obj)
    {
        return obj != null;
    }

    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
    }
}
