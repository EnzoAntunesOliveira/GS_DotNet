using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Eletrodomestico> Eletrodomesticos { get; set; }
        public DbSet<Geladeira> Geladeiras { get; set; }
        public DbSet<Microondas> Microondas { get; set; }
        public DbSet<MaquinaLavar> Lavadoras { get; set; }
        public DbSet<Cafeteira> Cafeteiras { get; set; }
        public DbSet<Ventilador> Ventiladores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Eletrodomestico>()
                .HasOne(e => e.Geladeira)
                .WithOne(g => g.Eletrodomestico)
                .HasForeignKey<Geladeira>(g => g.EletrodomesticoId);

            modelBuilder.Entity<Eletrodomestico>()
                .HasOne(e => e.Microondas)
                .WithOne(m => m.Eletrodomestico)
                .HasForeignKey<Microondas>(m => m.EletrodomesticoId);

            modelBuilder.Entity<Eletrodomestico>()
                .HasOne(e => e.Lavadora)
                .WithOne(l => l.Eletrodomestico)
                .HasForeignKey<MaquinaLavar>(l => l.EletrodomesticoId);

            modelBuilder.Entity<Eletrodomestico>()
                .HasOne(e => e.Cafeteira)
                .WithOne(c => c.Eletrodomestico)
                .HasForeignKey<Cafeteira>(c => c.EletrodomesticoId);

            modelBuilder.Entity<Eletrodomestico>()
                .HasOne(e => e.Ventilador)
                .WithOne(v => v.Eletrodomestico)
                .HasForeignKey<Ventilador>(v => v.EletrodomesticoId);
        }
    }
}