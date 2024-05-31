using MySql.Data.MySqlClient;
using System;

namespace csharpMysql.query
{
    public class NivelAcessoQuery
    {
        private MySqlConnection connection;

        public NivelAcessoQuery(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public void BuscarNivelAcesso()
        {
            string query = "Select * From Nivelacesso"; 
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("-------------------------- NivelAcesso Registrados -------------------------------");
                if (reader.HasRows)
                {
                    Console.WriteLine("pk_nivel | Descricao     | Permissão");
                    Console.WriteLine(new string('-', 80));
                    while (reader.Read())
                    {
                        
                        Console.WriteLine($"{reader.GetInt32("pk_nivel"),-8} | {reader.GetString("descricao"),-13} | {reader.GetString("permissoes"),-10}");
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
        public void BuscarNivelAcessoId(int id)
        {
            string query = $"select * from Nivelacesso where pk_nivel = {id}";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine("---------------- Busca por Id ----------------");
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i) == "status")
                        {
                            string Ativado = reader.GetInt32(i) == 1 ? "ativo" : "Desativado";
                            Console.WriteLine($"{reader.GetName(i)}: {Ativado}");
                        }
                        else
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }
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

        public void InserirNivelAcesso(string descricao, string permissoes)
        {
            string query = "INSERT INTO NivelAcesso (descricao, permissoes) values (@descricao, @permissoes)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@descricao", descricao);
                command.Parameters.AddWithValue("@permissoes", permissoes);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros inseridos com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void EditarNivelAcesso(int pk_nivel, string descricao, string permissoes)
        {
            string query = $"UPDATE NivelAcesso set descricao = @descricao, permissoes = @permissoes where pk_nivel = @pk_nivel";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@descricao", descricao);
                command.Parameters.AddWithValue("@permissoes", permissoes);
                command.Parameters.AddWithValue("@pk_nivel", pk_nivel);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros Editados com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void ApagarNivelAcesso(int pk_nivel)
        {
            string query = "DELETE FROM NivelAcesso WHERE pk_nivel = @pk_nivel";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@pk_nivel", pk_nivel);

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