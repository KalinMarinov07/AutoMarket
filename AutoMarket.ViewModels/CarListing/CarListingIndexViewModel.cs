using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace AutoMarket.ViewModels.CarListing
{
    public class CarListingIndexViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
