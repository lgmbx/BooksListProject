using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Models {
    public class Category {

        [Key]
        public int Id { get; set; }
        
        [MinLength(3, ErrorMessage = "This field must be 3-60 characters")]
        [MaxLength(60, ErrorMessage = "This field must be 3-60 characters")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();



        public Category() {

        }
        public Category(string name) {
            Name = name;
        }

        public void AddBook(Book book) {
            Books.Add(book);
        }


    }
}
