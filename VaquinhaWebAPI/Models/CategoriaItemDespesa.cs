using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWebAPI.Models 
{
    [Table("CATEGORIA_ITEM_DESPESA")]
    public class CategoriaItemDespesa 
    {  
        
        public CategoriaItemDespesa(int id, string nomeCategoriaItemDespesa)
        {
            this.Id = id;
            this.NomeCategoriaItemDespesa = nomeCategoriaItemDespesa;
        }

        [Column("ID_CATEGORIA_ITEM_DESPESA")]
        public int Id { get; set; }
        
        [Column("NM_CATEGORIA_ITEM_DESPESA")]
        public string NomeCategoriaItemDespesa { get; set; }
    }
}