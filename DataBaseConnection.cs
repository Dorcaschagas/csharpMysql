//Fazendo a conexao com o banco de dados
//abrindo conexao e fechando!

using MySql.Data.MySqlClient; 
using System;

namespace csharpMysql
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection(){
            return connection;
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexao aberta com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao abrir conexão" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Conexão fechada com sucesso!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar conexão" + ex.Message);
            }
        }
    }
}