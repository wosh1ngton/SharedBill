using Microsoft.EntityFrameworkCore;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Data
{


    public class VaquinhaContext : DbContext
    {
        public VaquinhaContext(DbContextOptions<VaquinhaContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaItemDespesa> CategoriasItemDespesa { get; set; } = null!;
        public DbSet<TipoItemDespesa> TiposItemDespesa { get; set; } = null!;
        public DbSet<Pagante> Pagantes { get; set; } = null!;
        public DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public DbSet<ItemDespesa> ItensDespesa { get; set; } = null!;
       
    }
}