// Arquivo: CryptoHelper.cs (Para hashear senhas no C#)

using System.Security.Cryptography;
using System.Text;

namespace SistemaEstoque.DAO
{
    public static class CryptoHelper
    {
        /// <summary>
        /// Calcula o hash SHA256 da string de entrada (senha).
        /// O resultado é uma string hexadecimal de 64 caracteres, compatível com o SHA2(..., 256) do MySQL.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>O hash SHA256 da senha.</returns>
        public static string Hash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string de entrada para um array de bytes e calcula o hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Converte o array de bytes do hash para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // "x2" formata o byte em hexadecimal minúsculo
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString(); // Retorna o hash final de 64 caracteres
            }
        }
    }
}