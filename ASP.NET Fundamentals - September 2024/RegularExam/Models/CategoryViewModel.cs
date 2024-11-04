using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(CategoryNameMaxLen, MinimumLength = CategoryNameMinLen)]
        public required string Name { get; set; }
    }
}
