// Arquivo: CryptoHelper.cs (Adicione esta classe ao seu projeto)
using System.Security.Cryptography;
using System.Text;
using System;

namespace SistemaEstoque.Utils
{
    public static class CryptoHelper
    {
        public static string ComputeSha256Hash(string rawString)
        {
            if (string.IsNullOrEmpty(rawString))
            {
                return string.Empty;
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawString));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}