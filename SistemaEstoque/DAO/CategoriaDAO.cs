// CategoriaDAO.cs

using System; // Necessário para Exception
using System.Collections.Generic;
using MySqlConnector;
using SistemaEstoque.Logger;
using SistemaEstoque.DAO;


namespace SistemaEstoque.DAO
{
    public class CategoriaDAO
    {
        public List<string> ObterCategorias()
        {
            var lista = new List<string>();
            try // NOVO: Bloco try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT nome FROM categoria ORDER BY idcategoria";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(reader.GetString("nome"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Loga o erro
                LogManager.WriteLog(ex.Message, "Falha ao obter lista de categorias do banco de dados.");
                throw; // Re-lança para que o Form possa tratar (e.g., exibir mensagem)
            }
            return lista;
        }
    }
}