using Microsoft.EntityFrameworkCore;
using VaquinhaWebAPI.Models;

namespace VaquinhaWebAPI.Data 
{
    public class VaquinhaContext : DbContext
    {
        public VaquinhaContext(DbContextOptions<VaquinhaContext> options) : base(options)
        {
            
        }

        public DbSet<CategoriaItemDespesa> CategoriasItemDespesa { get; set; } = null!;
        public DbSet<TipoItemDespesa> TiposItemDespesa { get; set; } = null!;
        public DbSet<Pagante> Pagantes { get; set; } = null!;
        public DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public DbSet<ItemDespesa> ItensDespesa { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {            

            builder.Entity<CategoriaItemDespesa>()
                .HasData(new List<CategoriaItemDespesa>() {
                    new CategoriaItemDespesa(1, "Supermercado"),
                    new CategoriaItemDespesa(2, "Carne"),
                    new CategoriaItemDespesa(3, "Outros")
                });
            builder.Entity<TipoItemDespesa>()
                .HasData(new List<TipoItemDespesa>() {
                    new TipoItemDespesa(1, "Custeio Mensal"),
                    new TipoItemDespesa(2, "Outros")
                });
            builder.Entity<Pagante>()
                .HasData(new List<Pagante>() {
                    new Pagante(1, "Woshington", "Silva"),
                    new Pagante(2, "Charline", "Rocha")
                });

            builder.Entity<ItemDespesa>()
                .HasData(new List<ItemDespesa>() {
                    new ItemDespesa(1, "Pão de Açúcar", 250,    1, 1, new DateTime(2023, 5, 25)),
                    new ItemDespesa(2, "Swift",         350,    2, 1, new DateTime(2023, 3, 25)),
                    new ItemDespesa(3, "Viagem",        50,     1, 2, new DateTime(2023, 2, 21)),
                    new ItemDespesa(4, "Pão de Açúcar", 58,     2, 1, new DateTime(2023, 4, 25)),
                    new ItemDespesa(5, "HortiFrutti",   20,     1, 2, new DateTime(2022, 8, 2)),
                    new ItemDespesa(6, "Pão de Açúcar", 250,    2, 2, new DateTime(2022, 1, 18)),
                });
       
            builder.Entity<Pagamento>()
                .HasData(new List<Pagamento>() {
                    new Pagamento(1, 60, 1, 1),
                    new Pagamento(2, 60, 2, 1),
                    new Pagamento(3, 60, 3, 1),
                    new Pagamento(4, 70, 4, 1),
                    new Pagamento(5, 40, 1, 2),
                    new Pagamento(6, 40, 2, 2),
                    new Pagamento(7, 40, 3, 2),
                    new Pagamento(8, 30, 4, 2),
                });

            builder.Entity<Pagamento>()
                .HasKey(p => new {p.PaganteId, p.ItemDespesaId});
        }
    }
}