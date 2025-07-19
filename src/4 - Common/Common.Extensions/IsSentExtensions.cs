public static class IsSentExtensions
{
    public static bool IsSent(this Guid? value)
    {
        return value != null && value != default && value.Value != default;
    }
    public static bool IsSent(this Guid value)
    {
        return value != default;
    }

    public static bool IsSent(this short value)
    {
        return value != default;
    }

    public static bool IsSent(this short? value)
    {
        return value != null && value != default && value.Value != default;
    }

    public static bool IsSent(this byte[] value)
    {
        return value != default;
    }

    public static bool IsSent(this byte? value)
    {
        return value != null && value != default && value.Value != default;
    }

    public static bool IsSent(this byte value)
    {
        return value != default;
    }

    public static bool IsSent(this int value)
    {
        return value != default;
    }

    public static bool IsSent(this int? value)
    {
        return value != default;
    }

    public static bool IsSent(this int[] values)
    {
        return values != default && values.Length > 0;
    }

    public static bool IsSent(this decimal value)
    {
        return value != default;
    }

    public static bool IsSent(this decimal? value)
    {
        return value != default;
    }

    public static bool IsSent(this string value)
    {
        return value.IsNotNullOrEmpty();
    }

    public static bool IsSent(this float? value)
    {
        return value != default;
    }

    public static bool IsSent(this float value)
    {
        return value != default;
    }

    public static bool IsSent(this bool value)
    {
        return value != default;
    }
    public static bool IsSent(this bool? value)
    {
        return value != default;
    }
    public static bool IsSent(this DateTime value)
    {
        return value != default;
    }

    public static bool IsSent(this DateTime? value)
    {
        return value != default && value.Value != default;
    }
}
