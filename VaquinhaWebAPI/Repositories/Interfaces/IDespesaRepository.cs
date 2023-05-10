using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Repositories.Interfaces
{
    public interface IDespesaRepository : IRepository<TipoItemDespesa>
    {
        void CadastrarDespesa(DespesaDTO despesa);
        IQueryable<Pagamento> ListarDespesas();
    }
}