using BooksListMvc2.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Data {
    public class SeedingService {

        private readonly AppDbContext _dbContext;
        public SeedingService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Seed() {
            if(_dbContext.Book.Any() || _dbContext.Category.Any()) {
                return;
            }

            Category c1 = new Category("Fantasy");
            Category c2 = new Category("Horror");
            Category c3 = new Category("Fiction");
            Category c4 = new Category("Thriller");

            Book b1 = new Book("The Lord of the Rings 3 Vol", "J.R.R. Tolkien", 80.00m, 3, c1);

            Book b2 = new Book("Eragon", "Christopher Paolini", 43.50m, 2, c1);
            Book b3 = new Book("Eldest", "Christopher Paolini", 44.90m, 1, c1);
            Book b4 = new Book("Brisingr", "Christopher Paolini", 55.00m, 2, c1);

            Book b5 = new Book("The Girl with the Dragon Tattoo", "Stieg Larsson", 60.00m, 5, c4);
            Book b6 = new Book("The Girl Who Played with Fire ", "Stieg Larsson", 30.00m, 3, c4);
            Book b7 = new Book("The Girl Who Kicked the Hornets' Nest", "Stieg Larsson", 45.00m, 4, c4);

            Book b8 = new Book("Nemesis", "Isaac Asimov", 29.99m, 9, c3);
            Book b9 = new Book("Foundation", "Isaac Asimov", 240.00m, 12, c3);

            Book b10 = new Book("Dracula", "Bram Stoker", 120.00m, 6, c2);
            Book b11 = new Book("The Shining", "Stephen King", 70.00m, 6, c2);
            Book b12 = new Book("The Dark Tower 7 Vol", "Stephen King", 360.00m, 6, c2);

            _dbContext.Category.AddRange(c1, c2, c3, c4);
            _dbContext.Book.AddRange(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12);
            _dbContext.SaveChanges();

        }

    }
}
