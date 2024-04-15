﻿using System.ComponentModel.DataAnnotations;

namespace TicketMovie.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter product name.")]
        [StringLength(50, ErrorMessage = "Product name must not exceed 50 characters")]
        public string Name { get; set; }
        [Range(0.01, 1000000.00)]
        public decimal Price { get; set; }


        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<ProductImage>? Images { get; set; }
        public int CategoryId { get; set; }
        public DateTime ShowTime { get; set; }
        public Category? Category { get; set; }
        public List<Showtime>? Showtimes { get; set; }


    }
}
