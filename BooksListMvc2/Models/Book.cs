using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Security.Cryptography;

namespace BooksListMvc2.Models {
    public class Book {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(3, ErrorMessage = "This field must be 3-60 characters")]
        [MaxLength(60, ErrorMessage = "This field must be 3-60 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(3, ErrorMessage = "This field must be 3-60 characters")]
        [MaxLength(60, ErrorMessage = "This field must be 3-60 characters")]
        public string Author { get; set; }

        [Range(1, int.MaxValue, ConvertValueInInvariantCulture = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int? Isbn { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Book() {

        }

        public Book(string title, string author, decimal price, int quantity, Category category) {
            Title = title;
            Author = author;
            Price = price;
            Quantity = quantity;
            Isbn = IsbnGen();
            Category = category;
        }
        
        private int IsbnGen() {
            return RandomNumberGenerator.GetInt32(int.MaxValue);   
        }

      

    }
}
