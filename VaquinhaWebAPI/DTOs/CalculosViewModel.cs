using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.DTOs
{
    public class CalculoViewModel
    {
        public double TotalPorMes { get; set; }
        public double MesTotalizado { get; set; }
        public Pagante? Pagante { get; set; }
    }
}