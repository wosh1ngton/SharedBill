using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.DTOs
{
    public class PercentuaisViewModel
    {
        public double TotalAPagar { get; set; }
        public double? TotalAReceber { get; set; }
        public double MesTotalizado { get; set; }
        public Pagante? Pagante { get; set; }
    }
}