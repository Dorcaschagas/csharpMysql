using csharpMysql.query;

namespace csharpMysql.service{
    public class CargosService{
        private CargosQuery cargosQuery;

        public CargosService(CargosQuery cargosQuery){
            this.cargosQuery = cargosQuery;
        }

        public void BuscarCargosService()
        {
            cargosQuery.BuscarCargos();
        }
        public void BuscarCargosIdService(int id)
        {
            cargosQuery.BuscarCargosId(id);
        }
        public void InserirCargosService(int status, string descricao, double salario, string funcao)
        {
            cargosQuery.InserirCargos(status, descricao, salario, funcao);
        }
        public void EditarCargosService(int pk_cargos, int status, string descricao, double salario, string funcao)
        {
            cargosQuery.EditarCargos(pk_cargos, status, descricao, salario, funcao);
        }
        public void ApagarCargosService(int pk_cargos)
        {
            cargosQuery.ApagarCargos(pk_cargos);
        }

        
    }
}