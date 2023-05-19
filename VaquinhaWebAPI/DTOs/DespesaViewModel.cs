namespace VaquinhaWebAPI.DTOs
{
    public class DespesaViewModel
    {
        public    int     PagamentoId {get; set;}
        public DateTime DtItemDespesa { get; set; }
        public string DescricaoItemDespesa { get; set; }
        public decimal ValorItemDespesa { get; set; }
        public int ItemDespesaId {get; set;}
        public int PaganteId { get; set; }
        public string NomePagante { get; set; }
        public int PercentualPago { get; set; }
        public string NomeTipoItemDespesa { get; set; }
        public string NomeCategoriaItemDespesa { get; set; }
    }
}