using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWebAPI.Models
{
    [Table("ITEM_DESPESA")]
    public class ItemDespesa
    {        
        public ItemDespesa(
            int id, 
            string descricaoItemDespesa,
            decimal valorItemDespesa, 
            int tipoItemDespesaId, 
            int categoriaItemDespesaId, 
            DateTime dtItemDespesa)
        {
            this.Id = id;
            this.DescricaoItemDespesa = descricaoItemDespesa;
            this.ValorItemDespesa = valorItemDespesa;
            this.TipoItemDespesaId = tipoItemDespesaId;
            this.CategoriaItemDespesaId = categoriaItemDespesaId;
            this.DtItemDespesa = dtItemDespesa;

        }        
       

        [Column("ID_ITEM_DESPESA")]       
        public int Id { get; set; }

        [Column("DS_ITEM_DESPESA")]
        public string DescricaoItemDespesa { get; set; }

        [Column("NR_VALOR")]
        public decimal ValorItemDespesa { get; set; }

        [Column("ID_TIPO_ITEM_DESPESA")]
        public int TipoItemDespesaId { get; set; }

        public TipoItemDespesa? TipoItemDespesa { get; set; }

        [Column("ID_CATEGORIA_ITEM_DESPESA")]
        public int CategoriaItemDespesaId { get; set; }

        public CategoriaItemDespesa? CategoriaItemDespesa { get; set; }


        [Column("DT_ITEM_DESPESA")]
        public DateTime DtItemDespesa { get; set; }
    }
}