using BooksListMvc2.Data;
using BooksListMvc2.Models;
using BooksListMvc2.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            if(_dbContext.Book.Any(x => x.Title == book.Title)){
                throw new DuplicateNameException("This Item already exists");
            }
            _dbContext.Book.Add(book);
            _dbContext.SaveChanges();
        }

        public Book Find(int id) {
           return _dbContext.Book.FirstOrDefault(obj => obj.Id == id);
        }

        public void UpdateBook(Book book) {
            if(!_dbContext.Book.Any(x => x.Id == book.Id)) {
                throw new NotFoundException("Not Found");
            }
            try {
                _dbContext.Book.Update(book);
                _dbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e){
                throw new DbCurrencyException(e.Message);
            }
            
        }


        public void DeleteBook(Book book) {
            if(!_dbContext.Book.Any(x => x.Id == book.Id)) {
                throw new NotFoundException("Not found");
            }
            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
