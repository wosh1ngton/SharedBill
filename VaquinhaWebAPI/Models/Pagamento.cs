using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWebAPI.Models
{
    [Table("PAGAMENTO")]
    public class Pagamento
    {  
        public Pagamento(int id, int percentualPago, int itemDespesaId, int paganteId)
        {
            this.Id = id;
            this.PercentualPago = percentualPago;
            this.ItemDespesaId = itemDespesaId;
            this.PaganteId = paganteId;

        }

        [Column("ID_PAGAMENTO")]
        public int Id { get; set; }

        [Column("NR_PERCENTUAL_PAGO")]
        public int PercentualPago { get; set; }

        [Column("ID_ITEM_DESPESA")]
        public int ItemDespesaId { get; set; }

        public ItemDespesa ItemDespesa { get; set; }

        [Column("ID_PAGANTE")]
        public int PaganteId { get; set; }

        public Pagante Pagante { get; set; }

    }
}