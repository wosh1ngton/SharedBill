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
            ItemDespesa id = new ItemDespesa( 
            despesa.DescricaoItemDespesa, despesa.ValorItemDespesa,despesa.TipoItemDespesaId,
            despesa.CategoriaItemDespesaId, despesa.DtItemDespesa);

            _context.Add(id);
            _context.SaveChanges();

            Pagamento p = new Pagamento(5, id.Id, despesa.PaganteId);
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

        public void ExcluirDespesa(int id)
        {
            var pagamento = _context.Pagamentos.SingleOrDefault(x => x.Id == id);
            var itensDespesa = new ItemDespesa();
            if(pagamento != null) {
                itensDespesa = _context.ItensDespesa.SingleOrDefault(x => x.Id == pagamento.ItemDespesaId);
            }

            _context.Remove<ItemDespesa>(itensDespesa!);
            _context.Remove(pagamento!);
            _context.SaveChanges();
        }

        public Pagamento GetDespesaById(int id)
        {
            var despesa = _context.Pagamentos.Where(x => x.Id == id)
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.CategoriaItemDespesa)
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.TipoItemDespesa)
                .Include(x => x.Pagante).AsNoTracking().SingleOrDefault();
            
            return despesa;
        }

        public void UpdateDespesa(ItemDespesa despesa, Pagamento pagamento)
        {           
            
            _context.Entry(despesa).State = EntityState.Modified;  
             
            _context.Entry(pagamento).State = EntityState.Modified;
            _context.SaveChanges();
         
        }
    }
}