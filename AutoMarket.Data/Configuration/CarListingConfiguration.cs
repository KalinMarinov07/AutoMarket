namespace AutoMarket.Data.Configuration
{
    using AutoMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Enums;

    public class CarListingConfiguration : IEntityTypeConfiguration<CarListing>
    {
        public void Configure(EntityTypeBuilder<CarListing> builder)
        {
            builder.HasData(
                new CarListing 
                { 
                    Id = 1, 
                    ModelId = 1, 
                    Price = 10000, 
                    ManufactureYear = 2016, 
                    Mileage = 180000, 
                    VehicleType = VehicleType.Hatchback, 
                    EngineType = EngineType.Diesel 
                });
        }
    }
}
