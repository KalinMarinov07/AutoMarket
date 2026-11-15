namespace AutoMarket.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AutoMarket.Common.ValidationConstants.Brand;

    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Model> Models { get; set; }
            = new HashSet<Model>();
    }
}
