using DeskMarket.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLen, MinimumLength = ProductNameMinLen)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLen, MinimumLength = ProductDescriptionMinLen)]
        public string Description { get; set; } 

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public string AddedOn { get; set; } 

        [Required]
        public int CategoryId { get; set; } 

        public string SellerId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }

}
