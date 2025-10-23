using CarBrand.Domain.Agregate;
using Microsoft.EntityFrameworkCore;

namespace CarBrand.Infraestructure.Seed
{
    public static class Seed
    {
        public static void SeedMethod(this ModelBuilder builder)
        {
            builder.Entity<CarBrandEntity>().HasData(
                new CarBrandEntity
                {
                    Id = new Guid("25eab2b3-f2f9-428c-9abf-24d8306a9678"),
                    Name = "Toyota",
                    Country = "Japan"
                },
                new CarBrandEntity
                {
                    Id = new Guid("b42b52a8-ebbf-4ff6-a504-7a7eb0d4207f"),
                    Name = "Hyundai",
                    Country = "South Korea"
                },
                new CarBrandEntity
                {
                    Id = new Guid("1bfef6ab-3c97-4bb6-8040-4aba216fb247"),
                    Name = "BMW",
                    Country = "Germany"
                }
            );
        }
    }
}
