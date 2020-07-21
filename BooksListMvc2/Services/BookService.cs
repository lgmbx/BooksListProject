using BooksListMvc2.Data;
using BooksListMvc2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Services {
    public class BookService {

        //injection
        private readonly AppDbContext _dbContext;
        public BookService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }


        //methods
        public List<Book> FindAll() {
            return _dbContext.Book.Include(x => x.Category).ToList();
        }

        public void AddBook(Book book) {
            _dbContext.Book.Add(book);
             _dbContext.SaveChanges();
        }
    }
}
