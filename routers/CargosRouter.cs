using csharpMysql.service;

namespace csharpMysql.routers
{
    public class CargosRouter
    {
        private CargosService cargosService;

        public CargosRouter(CargosService cargosService)
        {
            this.cargosService = cargosService;
        }

        public void BuscarCargosRouter()
        {
            cargosService.BuscarCargosService();
        }
        public void BuscarCargosIdRouter(int id)
        {
            cargosService.BuscarCargosIdService(id);
        }
        public void InserirCargosRouter(int status, string descricao, double salario, string funcao)
        {
            cargosService.InserirCargosService(status, descricao, salario, funcao);
        }
        public void EditarCargosRouter(int pk_cargos, int status, string descricao, double salario, string funcao)
        {
            cargosService.EditarCargosService(pk_cargos, status, descricao, salario, funcao);
        }
        public void ApagarCargosRouter(int pk_cargos)
        {
            cargosService.ApagarCargosService(pk_cargos);
        }

    }

}