using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWebAPI.Models
{
    [Table("PAGANTE")]
    public class Pagante
    {    
        public Pagante(int id, string nomePagante, string sobrenomePagante)
        {
            this.Id = id;
            this.NomePagante = nomePagante;
            this.SobrenomePagante = sobrenomePagante;
        }
        [Column("ID_PAGANTE")]
        public int Id { get; set; }        

        [Column("NM_NOME")]
        public string NomePagante { get; set; }

        [Column("NM_SOBRENOME")]
        public string? SobrenomePagante { get; set; }
    }
}