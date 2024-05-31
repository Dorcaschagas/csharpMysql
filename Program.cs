using System;
using MySql.Data.MySqlClient;
using csharpMysql.query;
using csharpMysql.service;
using csharpMysql.routers;

namespace csharpMysql
{
    class Program
    {
        static void Main(string[] args)
        {

            // =============================== Banco de Dados =============================
            string connectionString = "Server=localhost;Database=modelagempim;User ID=root;Password=";
            var dbConnection = new DatabaseConnection(connectionString);
            dbConnection.OpenConnection();
            var connection = dbConnection.GetConnection();

            // ================================== Cargos ==================================
            var cargosQuery = new CargosQuery(connection);
            var cargosService = new CargosService(cargosQuery);
            var cargosRouter = new CargosRouter(cargosService);

            // cargosRouter.BuscarCargosRouter();
            // cargosRouter.BuscarCargosIdRouter(2);
            // cargosRouter.InserirCargosRouter(1, "Gerente de Producao", 5250.80, "produtor");
            // cargosRouter.EditarCargosRouter(4, 1, "Efetuar limpeza", 2500.00, "Vendedor");
            // cargosRouter.ApagarCargosRouter(6);

            // ============================ Nível acesso ==================================
            var nivelAcessoQuery = new NivelAcessoQuery(connection);
            var nivelAcessoService = new NivelAcessoService(nivelAcessoQuery);
            var nivelAcessoRouter = new NivelAcessoRouter(nivelAcessoService);

            // nivelAcessoRouter.InserirNivelAcessoRouter("Pode tudo", "tudo");
            // nivelAcessoRouter.BuscarNivelAcessoRouter();
            // nivelAcessoRouter.BuscarNivelAcessoIdRouter(1);
            // nivelAcessoRouter.EditarNivelAcessoRouter(1,"Pode editar, apagar, e inserir", "parcial");
            // nivelAcessoRouter.ApagarNivelAcessoRouter(3);
            
            // ================================ Usuarios ===================================
            var usuariosQuery = new UsuarioQuery(connection);
            var usuariosService = new UsuarioService(usuariosQuery);
            var usuariosRouter = new UsuarioRouter(usuariosService);

            // usuariosRouter.BuscarUsuariosRouter();
            // usuariosRouter.BuscarUsuariosIdRouter(2);
            // usuariosRouter.EditarUsuariosRouter(2, "Pedro", "Pedro@email.com", "1234", 1, 1);
            // usuariosRouter.InserirUsuariosRouter("Maria", "Maria@email.com", "1234", 1, 1);
            // usuariosRouter.ApagarUsuariosRouter(2);

            // ============================ Funcionario =====================================
            // var funcionarioQuery = new FuncionarioQuery(connection);
            // var funcionarioService = new FuncionarioService(funcionarioQuery);
            // var funcionarioRouter = new FuncionarioRouter(funcionarioService);
            





            dbConnection.CloseConnection();
        }
    }
}
