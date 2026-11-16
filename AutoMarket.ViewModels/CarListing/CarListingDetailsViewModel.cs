using System.ComponentModel.DataAnnotations;

namespace AutoMarket.ViewModels.CarListing
{
    public class CarListingDetailsViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string ManufactureDate { get; set; } = null!;

        public string Mileage { get; set; } = null!;

        public string VehicleType { get; set; } = null!;

        public string EngineType { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
