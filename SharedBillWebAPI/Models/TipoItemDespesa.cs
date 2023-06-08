using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWebAPI.Models
{
    [Table("TIPO_ITEM_DESPESA")]
    public class TipoItemDespesa
    {
        public TipoItemDespesa()
        {
        }      

        [SetsRequiredMembers] 
        public TipoItemDespesa(int id, string nomeTipoItemDespesa)
        {
            this.Id = id;
            this.NomeTipoItemDespesa = nomeTipoItemDespesa;

        }

        [Column("ID_TIPO_ITEM_DESPESA")]
        public int Id { get; set; }

        [Column("NM_TIPO_ITEM_DESPESA")]
        public required string NomeTipoItemDespesa { get; set; }
    }
}