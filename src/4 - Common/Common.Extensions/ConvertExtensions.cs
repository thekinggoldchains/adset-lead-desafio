using System.Text.RegularExpressions;

public static class ConvertExtensions
{
    public static string ToCurrency(this decimal value)
    {
        return string.Format("{0:N2}", value);
    }
    public static string ToCurrency(this decimal? value)
    {
        return string.Format("{0:N2}", value);
    }
    public static string ToPercentage(this decimal instance)
    {
        return (instance / 100).ToString("p");
    }
    public static string ToPercentage(this decimal? instance)
    {
        if (instance.IsNull())
            return "";
        else
            return ToPercentage(instance.Value);
    }
    public static DateTime ToDate(this string value)
    {
        try
        {
            DateTime result;
            DateTime.TryParse(value, out result);
            return result;
        }
        catch
        {
            return new DateTime();
        }
    }
    public static int ToInt(this string zipCode)
    {
        try
        {
            return Convert.ToInt32(zipCode);
        }
        catch
        {
            return 0;
        }
    }
    public static int ToInt(this decimal valor)
    {
        try
        {
            return Convert.ToInt32(valor);
        }
        catch
        {
            return 0;
        }
    }
    public static int ToInt(this decimal? valor)
    {
        try
        {
            return Convert.ToInt32(valor.Value);
        }
        catch
        {
            return 0;
        }
    }
    public static string ToUpperCase(this string str)
    {
        if (str == null)
            return null;

        if (str == string.Empty)
            return string.Empty;

        return str.ToUpper();
    }

    public static string OnlyDigits(this string str)
    {
        return new Regex(@"[^\d]").Replace(str, "");
    }

    public static string ToFormatCPFCNPJ(this string _cpf_cnpj)
    {
        if (_cpf_cnpj.IsSent() == false) return string.Empty;
        if (_cpf_cnpj.Length == 11)
            return Regex.Replace(_cpf_cnpj, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        else
            return Regex.Replace(_cpf_cnpj, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
    }

    public static string ToBase64(this string text)
    {
        byte[] b = System.Text.Encoding.ASCII.GetBytes(text);
        string encrypted = Convert.ToBase64String(b);
        return encrypted;
    }

    public static string FromBase64(this string encrString)
    {
        byte[] b;
        string decrypted;
        try
        {
            b = Convert.FromBase64String(encrString);
            decrypted = System.Text.Encoding.ASCII.GetString(b);
        }
        catch
        {
            decrypted = "";
        }
        return decrypted;
    }
}
