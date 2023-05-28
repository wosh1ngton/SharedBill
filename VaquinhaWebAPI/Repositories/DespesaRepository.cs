using System.Globalization;
using Microsoft.EntityFrameworkCore;
using VaquinhaWeb.Util;
using VaquinhaWebAPI.Data;
using VaquinhaWebAPI.DTOs;
using VaquinhaWebAPI.Models;
using VaquinhaWebAPI.Repositories.Interfaces;
using VaquinhaWebAPI.Util;

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

            Pagamento p = new Pagamento(despesa.PercentualPago, id.Id, despesa.PaganteId);
            _context.Add(p);
            _context.SaveChanges();
        }

        public IQueryable<Pagamento> ListarDespesas(int? ano)
        {
            var despesas = _context.Pagamentos
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.CategoriaItemDespesa)
                .Include(x => x.ItemDespesa)
                    .ThenInclude(x => x.TipoItemDespesa)
                .Include(x => x.Pagante).Where(x => x.ItemDespesa.DtItemDespesa.Year == ano).AsQueryable();
            
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

        public IEnumerable<MesAno> GetMesesComDespesa(int ano)       
        {

            var resultado = _context.ItensDespesa.Where(x => x.DtItemDespesa.Year == ano)                
                .Select(x => new MesAno() {
                    MesInteiro = x.DtItemDespesa.Month,
                    MesString = x.DtItemDespesa.ToString("MMMM", new CultureInfo("pt-BR")),
                    Ano = x.DtItemDespesa.Year                                       
                }).AsEnumerable()
                .OrderBy(x => x.MesInteiro).ThenBy(x => x.Ano)
                .Distinct(new MesComparer());               
              

           return resultado;                     
            
        }

        public IEnumerable<int> GetAnosComDespesas()
        {
            return _context.ItensDespesa.OrderBy(x => x.DtItemDespesa.Year)
                    .Select(x => x.DtItemDespesa.Year).ToArray().Distinct();                 
                   
        }        

        public IEnumerable<CalculoViewModel> GetTotais(int? ano, int? mes)
        {
            var despesas = from p in _context.Pagamentos
                .Include(x => x.ItemDespesa)
                .Include(x => x.Pagante)
                where p.ItemDespesa.DtItemDespesa.Year == ano
                group p by new {p.ItemDespesa.DtItemDespesa.Month, p.PaganteId }
                into g
                select new CalculoViewModel {
                    MesTotalizado = g.Key.Month,
                    TotalPorMes = g.Sum(x => x.ItemDespesa.ValorItemDespesa),
                    Pagante = (from pag in _context.Pagantes where pag.Id == g.Key.PaganteId select pag).SingleOrDefault()
                                      
                };           
            
            return despesas;  
        }
    
        public IEnumerable<PercentuaisViewModel> GetTotalReceber(int? ano)
        {

            var despesas = from p in _context.Pagamentos 
                join id in _context.ItensDespesa on p.ItemDespesaId equals id.Id
                join pag in _context.Pagantes on p.PaganteId equals pag.Id                                         
                where p.ItemDespesa.DtItemDespesa.Year == ano                 
                group p by new { id.DtItemDespesa.Month, pag.Id } into g
                select new PercentuaisViewModel {                   
                   MesTotalizado = g.Key.Month,
                   TotalAReceber = (from val in g 
                    select val.ItemDespesa.ValorItemDespesa *  (1 - (val.PercentualPago * 0.01))).Sum(),
                    Pagante = (from pag in _context.Pagantes where pag.Id == g.Key.Id select pag).SingleOrDefault(),                                     
                }; 
           
            return despesas;
        }
    }
}