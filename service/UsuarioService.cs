using csharpMysql.query;

namespace csharpMysql.service
{
    public class UsuarioService
    {
        private UsuarioQuery usuarioQuery;

        public UsuarioService(UsuarioQuery usuarioQuery)
        {
            this.usuarioQuery = usuarioQuery;
        }

        public void BuscarUsuariosService()
        {
            usuarioQuery.BuscarUsuarios();
        }
        public void BuscarUsuariosIdService(int id)
        {
            usuarioQuery.BuscarUsuariosId(id);
        }
        public void InserirUsuariosService(string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioQuery.InserirUsuarios(nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void EditarUsuariosService(int pk_usuario, string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioQuery.EditarUsuarios(pk_usuario, nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void ApagarUsuariosService(int pk_usuario)
        {
            usuarioQuery.ApagarUsuarios(pk_usuario);
        }

    }
}