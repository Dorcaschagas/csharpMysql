using MySql.Data.MySqlClient;
using System;

namespace csharpMysql.query
{
    public class CargosQuery
    {
        private MySqlConnection connection;

        public CargosQuery(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public void BuscarCargos()
        {
            string query = "SELECT * FROM cargos";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("-------------------------- Cargos Registrados -------------------------------");
                if (reader.HasRows)
                {
                    Console.WriteLine("pk_cargos | Status     | Descricao              | Salário    | Função");
                    Console.WriteLine(new string('-', 77));
                    while (reader.Read())
                    {
                        var ativado = "ativo";
                        if (reader.GetInt32("status") == 0) ativado = "Desativado";
                        Console.WriteLine($"{reader.GetInt32("pk_cargos"),-9} | {ativado,-10} | {reader.GetString("descricao"),-22} | {reader.GetDouble("salario"),-10} | {reader.GetString("funcao"),-10}");
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
        public void BuscarCargosId(int id)
        {
            string query = $"select * from cargos where pk_cargos = {id}";
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

        public void InserirCargos(int status, string descricao, double salario, string funcao)
        {
            string query = "INSERT INTO cargos (status, descricao, salario, funcao) values (@status, @descricao, @salario, @funcao)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@descricao", descricao);
                command.Parameters.AddWithValue("@salario", salario);
                command.Parameters.AddWithValue("@funcao", funcao);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros inseridos com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void EditarCargos(int pk_cargos, int status, string descricao, double salario, string funcao)
        {
            string query = $"UPDATE cargos set status = @status, descricao = @descricao, salario = @salario, funcao = @funcao where pk_cargos = @pk_cargos";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@descricao", descricao);
                command.Parameters.AddWithValue("@salario", salario);
                command.Parameters.AddWithValue("@funcao", funcao);
                command.Parameters.AddWithValue("@pk_cargos", pk_cargos);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"{result} resgistros Editados com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao inserir dados" + ex.Message);
            }
        }
        public void ApagarCargos(int pk_cargos)
        {
            string query = "DELETE FROM cargos WHERE pk_cargos = @pk_cargos";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@pk_cargos", pk_cargos);

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