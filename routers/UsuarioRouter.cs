using csharpMysql.service;

namespace csharpMysql.routers
{
    public class UsuarioRouter
    {
        private UsuarioService usuarioService;

        public UsuarioRouter(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public void BuscarUsuariosRouter()
        {
            usuarioService.BuscarUsuariosService();
        }
        public void BuscarUsuariosIdRouter(int id)
        {
            usuarioService.BuscarUsuariosIdService(id);
        }
        public void InserirUsuariosRouter(string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioService.InserirUsuariosService(nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void EditarUsuariosRouter(int pk_usuario, string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioService.EditarUsuariosService(pk_usuario, nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void ApagarUsuariosRouter(int pk_usuario)
        {
            usuarioService.ApagarUsuariosService(pk_usuario);
        }

    }

}