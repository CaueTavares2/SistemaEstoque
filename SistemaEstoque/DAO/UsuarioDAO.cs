using System;

using MySqlConnector;

using System.Windows.Forms;

namespace SistemaEstoque.DAO

{

    public class UsuarioDAO

    {

        public bool ValidarLogin(string login, string senha)

        {

            try

            {

                using (var conn = Database.GetConnection())

                {

                    conn.Open();

                    string sql = "SELECT COUNT(*) FROM usuario WHERE login=@login AND senha=@senha";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@login", login);

                    cmd.Parameters.AddWithValue("@senha", senha);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

        }

    }

}