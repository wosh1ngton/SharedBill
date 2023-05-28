using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Repositories.Interfaces
{
    public interface IDespesaRepository : IRepository<TipoItemDespesa>
    {
        void CadastrarDespesa(DespesaDTO despesa);
        IQueryable<Pagamento> ListarDespesas(int? ano);
        void ExcluirDespesa(int id);
        Pagamento GetDespesaById(int id);
        void UpdateDespesa(ItemDespesa despesa, Pagamento pagamento);
        IEnumerable<MesAno> GetMesesComDespesa(int ano);
        IEnumerable<int> GetAnosComDespesas();
        IEnumerable<CalculoViewModel> GetTotais(int? ano, int? mes);
        IEnumerable<PercentuaisViewModel> GetTotalReceber(int? ano);
        //IEnumerable<DespesaDTO> GetTotalReceber(int? ano);

    }
}