// Arquivo: CryptoHelper.cs

using System.Security.Cryptography;
using System.Text;

namespace SistemaEstoque.DAO
{
    public static class CryptoHelper
    {
        /// <summary>
        /// Calcula o hash SHA256 da string de entrada.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>O hash SHA256 da senha.</returns>
        public static string Hash(string senha)
        {
            // O SHA256 no MySQL espera a string no formato de hex.
            // O método SHA2('TEXTO', 256) do MySQL faz exatamente isso.
            // Para simular isso no C#, usaremos o 'SHA2' puro do MySQL,
            // então não precisamos implementar a lógica complexa de hash no C#.
            // Vamos apenas usar a função nativa do MySQL no DAO.
            // NO ENTANTO, para a segurança do Login, precisamos forçar o hash no DAO.

            // Para simplificar, vou manter a sugestão de usar a função SHA2 do MySQL diretamente no DAO.
            // Mas a inclusão de uma classe para segurança é um bom padrão, então vamos usá-la.

            // Para o contexto do seu sistema, o ideal é usar a função SHA256 do C# e comparar os hashes.

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
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