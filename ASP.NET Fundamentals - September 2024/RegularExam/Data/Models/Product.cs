using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLen, MinimumLength = ProductNameMinLen)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLen, MinimumLength = ProductDescriptionMinLen)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal),MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; }

        [Required]
        public IdentityUser Seller { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = DateFormat, ApplyFormatInEditMode = true)]
        public DateTime AddedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
