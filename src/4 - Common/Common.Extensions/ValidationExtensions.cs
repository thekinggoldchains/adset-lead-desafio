using System.Text;
using System.Text.RegularExpressions;


public static class ValidationExtensions
{
    public static bool IsNumber(this string value)
    {
        return _IsNumber(value);
    }

    public static bool IsNumber(this object value)
    {
        return _IsNumber(value);
    }

    private static bool _IsNumber(object value)
    {
        if (value != null && value.ToString() == "-") return false;
        var valueString = Convert.ToString(value);
        var regex = new Regex(@"^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:\.\d+)?$");

        if (valueString.IsNullOrEmpty())
            return false;

        if (regex.IsMatch(valueString.Replace(",", ".")))
            return !(valueString.Length > 29);

        return false;
    }

    public static bool IsEmail(this string value)
    {
        return Regex.IsMatch(value,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
    }

    public static bool IsDigit(this string value)
    {
        foreach (var item in value)
        {
            if (!char.IsDigit(item))
                return false;
        }

        return true;
    }

    public static bool IsDate(this object value)
    {
        DateTime date;
        Decimal dec;

        var isDecimal = decimal.TryParse(Convert.ToString(value), out dec);

        if (!isDecimal)
            return DateTime.TryParse(Convert.ToString(value), out date);

        return false;
    }

    public static bool IsDate(this string value)
    {
        DateTime date;
        return DateTime.TryParse(value, out date);
    }

    public static bool IsCNPJ(this string cnpj)
    {
        cnpj = RemoveNonDigits(cnpj);
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;
        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        tempCnpj = cnpj.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cnpj.EndsWith(digito);
    }

    public static bool IsCPF(this string cpf)
    {
        cpf = RemoveNonDigits(cpf);
        string valor = cpf.Replace(".", "");
        valor = valor.Replace("-", "");
        valor = valor.Trim();

        if (valor.Length != 11)
            return false;

        bool igual = true;
        for (int i = 1; i < 11 && igual; i++)
            if (valor[i] != valor[0])
                igual = false;

        if (igual || valor == "12345678909")
            return false;

        int[] numeros = new int[11];

        for (int i = 0; i < 11; i++)
            numeros[i] = int.Parse(
              valor[i].ToString());

        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        int resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else
            if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }

    public static bool IsCreditCard(this string numero)
    {
        string numString;
        int soma = 0;

        if (numero.Length <= 15)
            for (int i = 0; i <= numero.Length - 1; i++)
            {
                numString = (numero.Substring(i, 1));

                if (i % 2 == 0)
                    soma += (int.Parse(numString) * 1);
                else
                    if ((int.Parse(numString) * 2) > 9)
                    soma += ((int.Parse(numString) * 2) - 9);
                else
                    soma += ((int.Parse(numString) * 2));
            }

        if (numero.Length >= 16)
            for (int i = 0; i <= numero.Length - 1; i++)
            {
                numString = (numero.Substring(i, 1));

                if (i % 2 == 0)
                    if ((int.Parse(numString) * 2) > 9)
                        soma += ((int.Parse(numString) * 2) - 9);
                    else
                        soma += ((int.Parse(numString) * 2));
                else
                    soma += (int.Parse(numString) * 1);
            }

        if (soma % 10 == 0)
            return true;
        else
            return false;
    }

    public static bool IsStrongPassword(this string pass, int length = 6, int strong = 3)
    {
        var hasLetter = Regex.IsMatch(pass, @"([A-Za-z])") ? 1 : 0;
        var hasNumber = Regex.IsMatch(pass, @"\d") ? 1 : 0;
        var hasEspecial = Regex.IsMatch(pass, @"[!@#$%^&*()_+\-=\[\]{};':" + @"\|,.<>\/?]+") ? 1 : 0;

        return (hasLetter + hasNumber + hasEspecial) >= strong && pass.Length >= length;
    }

    private static string RemoveNonDigits(string text)
    {
        StringBuilder newText = new(text.Length);
        foreach (var c in text) if (!char.IsDigit(c)) newText.Append(c);
        return newText.ToString();
    }
}
