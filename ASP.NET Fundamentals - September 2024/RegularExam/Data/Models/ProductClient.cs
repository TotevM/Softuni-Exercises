using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Key]
        [Required]
        public string ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public IdentityUser Client { get; set; }
    }
}
