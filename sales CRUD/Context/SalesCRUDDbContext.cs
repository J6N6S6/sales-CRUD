using Microsoft.EntityFrameworkCore;
using Sales_CRUD.Models;

namespace Sales_CRUD.Context
{
    public class SalesCRUDDbContext : DbContext
    {
        public SalesCRUDDbContext(DbContextOptions<SalesCRUDDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<ProdutoTipo> ProdutoTipos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendas> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendas>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(c => c.Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendas>()
                .HasOne<Vendedor>()
                .WithMany()
                .HasForeignKey(v => v.Vendedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendas>()
                .HasOne<Produto>()
                .WithMany()
                .HasForeignKey(p => p.Produto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendedor>()
                .HasOne<Filial>()
                .WithMany()
                .HasForeignKey(f => f.Filial)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Filial>()
                .HasOne<Vendedor>()
                .WithMany()
                .HasForeignKey(v  => v.VendedorResponsavel)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produto>()
                .HasOne<ProdutoTipo>()
                .WithMany()
                .HasForeignKey(p => p.Tipo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produto>()
                .HasOne<Filial>()
                .WithMany()
                .HasForeignKey(f => f.Filial)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
