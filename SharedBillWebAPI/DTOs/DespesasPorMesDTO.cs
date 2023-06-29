using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.DTOs 
{
    public class DespesasPorMesDTO
    {
        public int Mes { get; set; }
        public IEnumerable<Pagamento> Despesas { get; set; }
    }
}