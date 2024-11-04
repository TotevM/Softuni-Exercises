﻿using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public string? ImageUrl { get; set; } 
        public string CategoryName { get; set; }
        public DateTime AddedOn { get; set; } 
        public string Seller { get; set; }
        public bool HasBought { get; set; }
        public bool IsSeller { get; set; }
    }
}
