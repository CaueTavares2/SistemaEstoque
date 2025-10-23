using MySqlConnector;

namespace SistemaEstoque.DAO

{

    public static class Database

    {

        // ATENÇÃO: Ajuste a senha (Pwd) se a sua for diferente.

        public static string ConnectionString = "Server=localhost;Database=bd_sistema_estoque;Uid=root;Pwd=utfpr;";

        public static MySqlConnection GetConnection()

        {

            return new MySqlConnection(ConnectionString);

        }

    }

}