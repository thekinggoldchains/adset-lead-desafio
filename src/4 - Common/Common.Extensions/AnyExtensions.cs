public static class AnyExtensions
{
    public static bool IsAny<T>(this ICollection<T> obj)
    {
        return obj is not null && obj.Count > 0;
    }

    public static bool IsAny<T>(this IEnumerable<T> obj)
    {
        return obj is not null && obj.Any();
    }

    public static bool IsNotAny<T>(this ICollection<T> obj)
    {
        return !obj.IsAny();
    }

    public static bool IsNotAny<T>(this IEnumerable<T> obj)
    {
        return !obj.IsAny();
    }
}
