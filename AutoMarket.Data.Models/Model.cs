namespace AutoMarket.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static AutoMarket.Common.ValidationConstants.Model;

    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;

        public virtual ICollection<CarListing> CarListings { get; set; }
            = new List<CarListing>();
    }
}
