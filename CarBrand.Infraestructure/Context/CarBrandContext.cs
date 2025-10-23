using CarBrand.Infraestructure.Seed;
using CarBrand.Domain.Agregate;
using Microsoft.EntityFrameworkCore;

namespace CarBrand.Infraestructure.Context
{
    public class CarBrandContext : DbContext
    {
        public DbSet<CarBrandEntity> CarBrands { get; set; }

        public CarBrandContext(DbContextOptions<CarBrandContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ejemplo de configuración: nombre de tabla y restricciones
            modelBuilder.Entity<CarBrandEntity>(entity =>
            {
                entity.ToTable("MarcasAutos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.SeedMethod();
        }

    }
}
