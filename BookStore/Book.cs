using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.DAL
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        public int Pages { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int YearPublished { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        public bool IsSequel { get; set; }
    }
}
