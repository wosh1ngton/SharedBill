namespace VaquinhaWebAPI.DTOs
{
    public class DespesaViewModel
    {
        public DateTime DtItemDespesa { get; set; }
        public string DescricaoItemDespesa { get; set; }
        public decimal ValorItemDespesa { get; set; }
        public string Nome { get; set; }
        public int PercentualPago { get; set; }
        public string NomeTipoItemDespesa { get; set; }
        public string NomeCategoriaItemDespesa { get; set; }
    }
}