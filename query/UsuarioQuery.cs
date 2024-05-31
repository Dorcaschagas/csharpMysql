using MySql.Data.MySqlClient;
using System;

namespace csharpMysql.query
{
    public class UsuarioQuery
    {
        private MySqlConnection connection;

        public UsuarioQuery(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public void BuscarUsuarios()
        {
            string query = "Select * From usuarios";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("--------------------------  Registrados -------------------------------");
                if (reader.HasRows)
                {
                    Console.WriteLine("pk_usuario |nome|email|senha|nivelAcesso_pk_nivel|cargos_pk_cargos");
                    Console.WriteLine(new string('-', 80));
                    while (reader.Read())
                    {

                        Console.WriteLine($"{reader.GetInt32("pk_usuario"),-8} | {reader.GetString("nome"),-13} | {reader.GetString("email"),-10} {reader.GetString("senha")} | {reader.GetInt32("nivelAcesso_pk_nivel")} | {reader.GetInt32("cargos_pk_cargos")}");
                    }
                }
                Console.WriteLine(new string('-', 77));

                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
        }
        public void BuscarUsuariosId(int id)
        {
            string query = $"select * from usuarios where pk_usuario = {id}";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine("---------------- Busca por Id ----------------");
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                    }
                    Console.WriteLine("----------------------------------------------");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
        }

        public void InserirUsuarios(string nome , string email , string senha , int nivelAcesso_pk_nivel , int cargos_pk_cargos)
        {
            string query = "INSERT INTO usuarios (nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos) values (@nome, @email, @senha, @nivelAcesso_pk_nivel, @cargos_pk_cargos)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@nivelAcesso_pk_nivel", nivelAcesso_pk_nivel);
                command.Parameters.AddWithValue("@cargos_pk_cargos", cargos_pk_cargos);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros inseridos com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void EditarUsuarios(int pk_usuario , string nome , string email , string senha , int nivelAcesso_pk_nivel , int cargos_pk_cargos)
        {
            
            string query = $"UPDATE usuarios set nome = @nome, email = @email, senha = @senha, nivelAcesso_pk_nivel = @nivelAcesso_pk_nivel, cargos_pk_cargos = @cargos_pk_cargos where pk_usuario = @pk_usuario";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                 command.Parameters.AddWithValue("@pk_usuario", pk_usuario);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@nivelAcesso_pk_nivel", nivelAcesso_pk_nivel);
                command.Parameters.AddWithValue("@cargos_pk_cargos", cargos_pk_cargos);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros Editados com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void ApagarUsuarios(int pk_usuario)
        {
            string query = "DELETE FROM usuarios WHERE pk_usuario = @pk_usuario";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@pk_usuario", pk_usuario);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistro Apagado com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
    }
}

