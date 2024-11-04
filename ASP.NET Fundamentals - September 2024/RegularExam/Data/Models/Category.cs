using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLen, MinimumLength = CategoryNameMinLen)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
