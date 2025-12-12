
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace Examen.Modelos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Inventario_Model> Productos { get; set; } // Usamos el nombre lógico "Productos" para la tabla
        public DbSet<Proveedor_Model> Proveedores { get; set; }
        public DbSet<Entrada_Model> Entradas { get; set; }

        // Constructor base
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) { }

        // Configuración de la conexión
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString =
                    "Server=JUAN\\MSSQLSERVER01;Database=ControlInventarioDB;Integrated Security=True;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario_Model>()
                .Property(p => p.PrecioUnitario)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Entrada_Model>()
                .Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Proveedor_Model>()
                .HasIndex(p => p.RUC)
                .IsUnique();
        }
    }
}