using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Repositories.Interfaces
{
    public interface IDespesaRepository : IRepository<TipoItemDespesa>
    {
        void CadastrarDespesa(DespesaDTO despesa);
        IQueryable<Pagamento> ListarDespesas();
        void ExcluirDespesa(int id);
        Pagamento GetDespesaById(int id);        
        void UpdateDespesa(ItemDespesa despesa, Pagamento pagamento);
    }
}