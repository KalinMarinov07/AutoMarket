namespace AutoMarket.ViewModels.CarListing
{
    using AutoMarket.ViewModels.Brand;
    using AutoMarket.ViewModels.Model;
    using AutoMarket.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    using static AutoMarket.Common.ValidationConstants.CarListing;

    public class CarListingInputModel
    {
        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ModelId { get; set; }

        public EngineType EngineType { get; set; }

        public VehicleType VehicleType { get; set; }

        public int? ManufactureMonth { get; set; }

        public int ManufactureYear { get; set; }

        public double Price { get; set; }

        public int Mileage { get; set; }

        [Url]
        [StringLength(ImageUrlMaxLength, MinimumLength = DescriptionMinLength)]
        public string? ImageUrl { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public IEnumerable<BrandDropdownViewModel> Brands { get; set; }
            = new List<BrandDropdownViewModel>();

        public IEnumerable<ModelDropdownViewModel> Models { get; set; }
            = new List<ModelDropdownViewModel>();
    }
}
