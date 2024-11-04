using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using DeskMarket.Common;
using DeskMarket.Data.Models;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Models
{
    public class AddProductView
    {
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

        [DataType(DataType.Date)] 
        public required string AddedOn { get; set; } = DateTime.Now.ToString(ModelValidationConstants.DateFormat);

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
