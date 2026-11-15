namespace AutoMarket.Data.Models
{
    using AutoMarket.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static AutoMarket.Common.ValidationConstants.CarListing;

    public class CarListing
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public Model Model { get; set; } = null!;

        [Column(TypeName = PriceColumnType)]
        public double Price { get; set; }

        public int? ManufactureMonth { get; set; }

        public int ManufactureYear { get; set; }

        public int Mileage { get; set; }

        public VehicleType VehicleType { get; set; }

        public EngineType EngineType { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }
    }
}
