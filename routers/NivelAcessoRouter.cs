using csharpMysql.service;

namespace csharpMysql.routers
{
    public class NivelAcessoRouter
    {
        private NivelAcessoService nivelAcessoService;

        public NivelAcessoRouter(NivelAcessoService nivelAcessoService)
        {
            this.nivelAcessoService = nivelAcessoService;
        }

        public void BuscarNivelAcessoRouter()
        {
            nivelAcessoService.BuscarNivelAcesso();
        }
        public void BuscarNivelAcessoIdRouter(int id)
        {
            nivelAcessoService.BuscarNivelAcessoId(id);
        }
        public void InserirNivelAcessoRouter(string descricao, string permissoes)
        {
            nivelAcessoService.InserirNivelAcesso(descricao, permissoes);
        }
        public void EditarNivelAcessoRouter(int pk_nivel, string descricao, string permissoes)
        {
            nivelAcessoService.EditarNivelAcesso(pk_nivel, descricao, permissoes);
        }
        public void ApagarNivelAcessoRouter(int pk_nivel)
        {
            nivelAcessoService.ApagarNivelAcesso(pk_nivel);
        }
    }
}