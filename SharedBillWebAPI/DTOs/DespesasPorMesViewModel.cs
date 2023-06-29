using VaquinhaWebAPI.DTOs;

namespace SharedBillWebApi.DTOs 
{
    public class DespesasPorMesViewModel 
    {
        public int Mes { get; set; }
        public List<DespesaViewModel> Despesas = new List<DespesaViewModel>();
    }
}