namespace AutoMarket.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AutoMarket.Common.ValidationConstants.Model;

    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public int BrandId { get; set; }
    }
}
