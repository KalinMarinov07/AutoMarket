using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace AutoMarket.ViewModels.CarListing
{
    public class CarListingIndexViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public double Price { get; set; }

        public string ManufactureDate { get; set; } = null!;

        public int Mileage { get; set; }

        public string VehicleType { get; set; } = null!;

        public string EngineType { get; set; } = null!;

        public string? Description { get; set; }
    }
}
