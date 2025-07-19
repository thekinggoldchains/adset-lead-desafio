public static class UtilsExtensions
{
    public static string GenerateRandomCode(this string s, int lenght = 5)
    {
        Random r = new();

        for (int j = 0; j < lenght; j++)
        {
            int i = r.Next(3);
            int ch;
            switch (i)
            {
                case 1:
                    ch = r.Next(0, 9);
                    s += ch.ToString();
                    break;
                case 2:
                    ch = r.Next(65, 90);
                    s += Convert.ToChar(ch).ToString();
                    break;
                case 3:
                    ch = r.Next(97, 122);
                    s += Convert.ToChar(ch).ToString();
                    break;
                default:
                    ch = r.Next(97, 122);
                    s += Convert.ToChar(ch).ToString();
                    break;
            }
            r.NextDouble();
            r.Next(100, 1999);
        }
        return s;
    }

    public static string SimpleEncryptString(this string text, string keyString)
    {
        return $"{text}_{keyString}".ToBase64();
    }

    public static string SimpleDecryptString(this string encrString, string keyString)
    {
        return encrString.FromBase64().Replace($"_{keyString}", string.Empty);
    }





}
