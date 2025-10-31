using System;
using System.Linq;

namespace SistemaEstoque.Utils
{
    public static class ValidacaoHelper
    {
        public static bool ValidarCNPJ(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cnpj.All(d => d == cnpj[0]))
                return false;

            // Cálculo do primeiro dígito verificador
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Cálculo do segundo dígito verificador
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados conferem com os informados
            return int.Parse(cnpj[12].ToString()) == digito1 &&
                   int.Parse(cnpj[13].ToString()) == digito2;
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }

        public static string LimparCNPJ(string cnpj)
        {
            return new string(cnpj.Where(char.IsDigit).ToArray());
        }

        public static string SanitizarInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Remove ou codifica caracteres perigosos
            return input.Replace("<", "&lt;")
                        .Replace(">", "&gt;")
                        .Replace("\"", "&quot;")
                        .Replace("'", "&#x27;")
                        .Replace("&", "&amp;");
        }
    }
}