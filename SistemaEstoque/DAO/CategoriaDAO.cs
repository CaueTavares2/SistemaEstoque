using System.Collections.Generic;
using MySqlConnector;
using SistemaEstoque.DAO;

namespace SistemaEstoque.DAO
{
    public class CategoriaDAO
    {
        public List<string> ObterCategorias()
        {
            var lista = new List<string>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                // MUDANÇA ESSENCIAL AQUI: Ordena as categorias pelo ID
                // Isso garante que a ordem no ComboBox será (ID 1, ID 2, ID 3, ID 4, ID 5)
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
            return lista;
        }
    }
}