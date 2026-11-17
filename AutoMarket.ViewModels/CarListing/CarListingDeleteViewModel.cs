namespace AutoMarket.ViewModels.CarListing
{
    public class CarListingDeleteViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public string ManufactureDate { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
