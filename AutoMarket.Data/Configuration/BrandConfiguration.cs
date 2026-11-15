namespace AutoMarket.Data.Configuration
{
    using AutoMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = 1, Name = "Audi" },
                new Brand { Id = 2, Name = "BMW" },
                new Brand { Id = 3, Name = "Mercedes-Benz" },
                new Brand { Id = 4, Name = "Volkswagen" },
                new Brand { Id = 5, Name = "Toyota" },
                new Brand { Id = 6, Name = "Honda" },
                new Brand { Id = 7, Name = "Ford" },
                new Brand { Id = 8, Name = "Opel" },
                new Brand { Id = 9, Name = "Skoda" },
                new Brand { Id = 10, Name = "Peugeot" },
                new Brand { Id = 11, Name = "Renault" },
                new Brand { Id = 12, Name = "Hyundai" },
                new Brand { Id = 13, Name = "Kia" },
                new Brand { Id = 14, Name = "Mazda" },
                new Brand { Id = 15, Name = "Volvo" }
                );
        }
    }
}
