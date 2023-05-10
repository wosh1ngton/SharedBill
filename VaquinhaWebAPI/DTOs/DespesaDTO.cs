namespace VaquinhaWebAPI.DTOs
{
    public class DespesaDTO
    {
        public DateTime DtItemDespesa           { get; set; }
        public string   DescricaoItemDespesa    { get; set; }
        public decimal  ValorItemDespesa        { get; set; }
        public int      PaganteId               { get; set; }
        public int      PercentualPago          { get; set; }
        public int      TipoItemDespesaId       { get; set; }
        public int      CategoriaItemDespesaId  { get; set; }
    }
}