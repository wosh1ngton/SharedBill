using Microsoft.EntityFrameworkCore;
using VaquinhaWebAPI.Data;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories.Interfaces;

namespace VaquinhaWebAPI.Repositories
{
    public class DespesaRepository : Repository<TipoItemDespesa>, IDespesaRepository
    {
        protected readonly VaquinhaContext _context;
        public DespesaRepository(VaquinhaContext vaquinhaContext) : base(vaquinhaContext)
        {
            _context = vaquinhaContext;
        }

        public void CadastrarDespesa(DespesaDTO despesa)
        {
            ItemDespesa id = new ItemDespesa(0, 
            despesa.DescricaoItemDespesa, despesa.ValorItemDespesa,despesa.TipoItemDespesaId,
            despesa.CategoriaItemDespesaId, despesa.DtItemDespesa);

            _context.Add(id);
            _context.SaveChanges();

            Pagamento p = new Pagamento(0, 5, id.Id, despesa.PaganteId);
            _context.Add(p);
            _context.SaveChanges();
        }

        public IQueryable<Pagamento> ListarDespesas()
        {
            var despesas = _context.Pagamentos
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.CategoriaItemDespesa)
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.TipoItemDespesa)
                .Include(x => x.Pagante).AsQueryable();
            
            return despesas;                

        }
    }
}