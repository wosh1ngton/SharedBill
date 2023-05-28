namespace VaquinhaWebAPI.DTOs
{
    public class DespesaDTO
    {
        public int      PagamentoId             { get; set; }
        public DateTime DtItemDespesa           { get; set; }
        public string   DescricaoItemDespesa    { get; set; }
        public double  ValorItemDespesa        { get; set; }
        public int      ItemDespesaId           {get; set;}
        public int      PaganteId               { get; set; }
        public int      PercentualPago          { get; set; }
        public int      TipoItemDespesaId       { get; set; }
        public int      CategoriaItemDespesaId  { get; set; }
        
        public double? ValorAReceber { 
            get 
                {
                    var percentualAReceber =  (1 - (PercentualPago * 0.01));
                    return ValorItemDespesa * percentualAReceber;
                }
            
        }
    }
}