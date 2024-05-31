using csharpMysql.query;

namespace csharpMysql.service
{
    public class NivelAcessoService
    {
        private NivelAcessoQuery nivelAcessoQuery;

        public NivelAcessoService(NivelAcessoQuery nivelAcessoQuery)
        {
            this.nivelAcessoQuery = nivelAcessoQuery;
        }

        public void BuscarNivelAcesso()
        {
            nivelAcessoQuery.BuscarNivelAcesso();
        }
        public void BuscarNivelAcessoId(int id)
        {
            nivelAcessoQuery.BuscarNivelAcessoId(id);
        }
        public void InserirNivelAcesso(string descricao, string permissoes)
        {
            nivelAcessoQuery.InserirNivelAcesso(descricao, permissoes);
        }
        public void EditarNivelAcesso(int pk_nivel, string descricao, string permissoes)
        {
            nivelAcessoQuery.EditarNivelAcesso(pk_nivel, descricao, permissoes);
        }
        public void ApagarNivelAcesso(int pk_nivel)
        {
            nivelAcessoQuery.ApagarNivelAcesso(pk_nivel);
        }
    }
}