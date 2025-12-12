// Archivo: AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using System.Configuration; // Necesitas instalar el paquete NuGet System.Configuration.ConfigurationManager si usas .NET Core

namespace Examen.Modelos
{
    public class AppDbContext : DbContext
    {
        // Definición de las colecciones (DbSet) que mapean a las tablas
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
                // Usamos la instancia SQL Server de tu entorno y Autenticación de Windows
                // Server=JUAN\MSSQLSERVER01;Database=ControlInventarioDB;Integrated Security=True;TrustServerCertificate=True;

                // Opción 1: Leer desde App.config (Recomendado para producción/configuración externa)
                // string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                // Opción 2: Usar la cadena de conexión directa para simplicidad en Windows Forms
                string connectionString =
                    "Server=JUAN\\MSSQLSERVER01;Database=ControlInventarioDB;Integrated Security=True;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Configuración adicional de modelos y restricciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar precisión para decimales (dinero/costo)
            modelBuilder.Entity<Inventario_Model>()
                .Property(p => p.PrecioUnitario)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Entrada_Model>()
                .Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)");

            // Configurar que RUC debe ser único (aunque ya está en SQL, buena práctica)
            modelBuilder.Entity<Proveedor_Model>()
                .HasIndex(p => p.RUC)
                .IsUnique();
        }
    }
}